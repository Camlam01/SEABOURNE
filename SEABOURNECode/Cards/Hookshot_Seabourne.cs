using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Rare attack that fires the cannon and reloads any cannonballs that were fired. When upgraded
    /// the energy cost is reduced.
    /// </summary>
    public class Hookshot_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Hookshot";
        public override string Name => "Hookshot";
        public override string Description => "Fire the cannon and reload all fired cannonballs.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/Hookshot";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: Fire the cannon at the target and then reload all previously fired cannonballs into the cannon.
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 2 to 1 on upgrade
            EnergyCost.UpgradeBy(-1);
        }
    }
}