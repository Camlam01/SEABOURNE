using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Cards;
using SEABOURNE.SEABOURNECode.Powers;

namespace SEABOURNE.SEABOURNECode.Utils;

public static class SeaborneCardRuntime
{
    private static int lastFiredCannonballs;

    public static void SetCost(CardModel card, int newCost)
    {
        card.CanonicalStarCost = newCost;
        card.BaseStarCost = newCost;
        card.CurrentStarCost = newCost;
    }

    public static Task Cast(CardPlay play, int amount)
    {
        return CommonActions.GainPower(play.Card, play, new CastPower(), SeabornePowerRuntime.ModifyCast(play.Owner, amount));
    }

    public static async Task Reel(CardPlay play, int amount)
    {
        var reelAmount = SeabornePowerRuntime.ModifyReel(play.Owner, amount);
        var cast = SeabornePowerRuntime.GetPower<CastPower>(play.Owner);

        if (cast == null || reelAmount <= 0 || play.Owner.DiscardPile.Count == 0) return;

        var start = cast.GetHookIndexFromTopOfDiscard(play.Owner.DiscardPile.Count);
        var reeled = new List<CardModel>();

        for (var i = start; i >= 0 && reeled.Count < reelAmount; i--)
        {
            var card = play.Owner.DiscardPile[i];
            play.Owner.DiscardPile.RemoveAt(i);
            play.Owner.Hand.Add(card);
            reeled.Add(card);
        }

        await CommonActions.RemovePower(play.Card, play, cast, cast.Amount);

        var fortitude = SeabornePowerRuntime.GetPower<FishermansFortitudePower>(play.Owner);
        if (fortitude != null && reeled.Count > 0)
        {
            await CommonActions.CardBlock(play.Card, play, fortitude.BlockPerReeledCard * reeled.Count);
        }

        var rod = SeabornePowerRuntime.GetPower<EnchantedRodPower>(play.Owner);
        if (rod != null && rod.CanImbueReeledCard() && reeled.Count > 0)
        {
            reeled[0].ApplyPowerInternal(new ImbuedPower(), 1);
            rod.MarkUsed();
        }

        foreach (var card in reeled)
        {
            if (card.Powers.OfType<WetCardPower>().Any() && card is ISeaborneWetCard wetCard)
            {
                await wetCard.OnReeled(play);
            }
        }
    }

    public static Task AcquireGem(CardPlay play, object gem) => CommonActions.GainPower(play.Card, play, gem, 1);
    public static Task LoadCannon(CardPlay play, decimal baseDamage) => CommonActions.GainPower(play.Card, play, new LoadedCannonballPower(), 1);

    public static async Task FireCannon(CardPlay play, decimal baseDamage, bool targetOnly)
    {
        var loaded = SeabornePowerRuntime.Amount<LoadedCannonballPower>(play.Owner);
        lastFiredCannonballs = loaded;

        if (loaded <= 0)
        {
            await CommonActions.CardDamageToAllEnemies(play.Card, play, 8m);
            return;
        }

        for (var i = 0; i < loaded; i++)
        {
            var damage = baseDamage + SeabornePowerRuntime.Amount<ShardyShrapnelPower>(play.Owner);
            if (SeabornePowerRuntime.HasPower<ExplosiveGunpowderPower>(play.Owner)) damage *= 2m;
            damage *= 1m + i * 0.2m;
            damage = SeabornePowerRuntime.ModifyDamage(play.Owner, damage);

            if (targetOnly) await CommonActions.CardDamage(play.Card, play, Math.Ceiling(damage));
            else await CommonActions.CardDamageToAllEnemies(play.Card, play, Math.Ceiling(damage));
        }

        var cannonballs = SeabornePowerRuntime.GetPower<LoadedCannonballPower>(play.Owner);
        if (cannonballs != null) await CommonActions.RemovePower(play.Card, play, cannonballs, cannonballs.Amount);

        var gunpowder = SeabornePowerRuntime.GetPower<ExplosiveGunpowderPower>(play.Owner);
        if (gunpowder != null) await CommonActions.RemovePower(play.Card, play, gunpowder, gunpowder.Amount);
    }

    public static async Task AddCannonballs(CardPlay play, int count)
    {
        for (var i = 0; i < count; i++)
        {
            await CommonActions.MakeCardInHand(play.Card, play, new CannonballCard());
        }
    }

    public static Task ReloadLastFiredCannonballs(CardPlay play)
    {
        return lastFiredCannonballs <= 0 ? Task.CompletedTask : CommonActions.GainPower(play.Card, play, new LoadedCannonballPower(), lastFiredCannonballs);
    }

    public static Task LoadAllCannonballsInHand(CardPlay play)
    {
        var cannonballs = play.Owner.Hand.Where(card => card.GetType().Name == nameof(CannonballCard)).ToList();
        foreach (var card in cannonballs)
        {
            play.Owner.Hand.Remove(card);
            play.Owner.DiscardPile.Add(card);
        }

        return cannonballs.Count == 0 ? Task.CompletedTask : CommonActions.GainPower(play.Card, play, new LoadedCannonballPower(), cannonballs.Count);
    }

    public static Task ImbueFirstCardInHand(CardPlay play, int amount)
    {
        var card = play.Owner.Hand.FirstOrDefault();
        if (card != null && !card.Powers.OfType<UnimbuedPower>().Any()) card.ApplyPowerInternal(new ImbuedPower(), amount);
        return Task.CompletedTask;
    }

    public static Task GiveWetToFirstCardInHand(CardPlay play, int amount)
    {
        play.Owner.Hand.FirstOrDefault()?.ApplyPowerInternal(new WetCardPower(), amount);
        return Task.CompletedTask;
    }

    public static async Task GainRandomGem(CardPlay play)
    {
        object gem = Random.Shared.Next(6) switch
        {
            0 => new RubyGemPower(),
            1 => new SapphireGemPower(),
            2 => new EmeraldGemPower(),
            3 => new AmberGemPower(),
            4 => new OpalGemPower(),
            _ => new DiamondGemPower(),
        };

        await AcquireGem(play, gem);
    }

    public static async Task FireAllGems(CardPlay play, decimal damagePerGem)
    {
        var count = play.Owner.Powers.Count(power => power is RubyGemPower or SapphireGemPower or EmeraldGemPower or AmberGemPower or OpalGemPower or DiamondGemPower);
        for (var i = 0; i < count; i++) await CommonActions.CardDamageToAllEnemies(play.Card, play, damagePerGem);
    }

    public static Task DiscardTopDraw(CardPlay play, int count)
    {
        for (var i = 0; i < count && play.Owner.DrawPile.Count > 0; i++)
        {
            var card = play.Owner.DrawPile[0];
            play.Owner.DrawPile.RemoveAt(0);
            play.Owner.DiscardPile.Add(card);
        }
        return Task.CompletedTask;
    }

    public static Task Wash(CardPlay play, int count)
    {
        var cards = play.Owner.DrawPile.Take(count).ToList();
        foreach (var card in cards)
        {
            card.ApplyPowerInternal(new ImbuedPower(), 1);
            play.Owner.DrawPile.Remove(card);
            play.Owner.DiscardPile.Add(card);
        }
        return Task.CompletedTask;
    }

    public static int CardsInHand(CardPlay play) => play.Owner.Hand.Count;
    public static int CurrentCast(CardPlay play) => SeabornePowerRuntime.Amount<CastPower>(play.Owner);
    public static int CurrentWaterwall(CardPlay play) => SeabornePowerRuntime.Amount<WaterwallPower>(play.Owner);

    public static int EnergyOnHookedCard(CardPlay play)
    {
        var cast = SeabornePowerRuntime.GetPower<CastPower>(play.Owner);
        if (cast == null || play.Owner.DiscardPile.Count == 0) return 0;

        var index = cast.GetHookIndexFromTopOfDiscard(play.Owner.DiscardPile.Count);
        return index < 0 ? 0 : play.Owner.DiscardPile[index].CurrentStarCost;
    }
}
