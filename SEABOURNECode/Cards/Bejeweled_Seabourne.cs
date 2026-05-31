using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Rare skill that grants the player all gems temporarily next turn, ignoring slot restrictions.
    /// </summary>
    public class Bejeweled_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Bejeweled";
        public override string Name => "Bejeweled";
        public override string Description => "Next turn, temporarily gain all gems (ignoring gem slots).";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Bejeweled";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply an effect that gives the player all six gem buffs next turn regardless of gem slots
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 1 to 0
            EnergyCost.UpgradeBy(-1);
        }
    }
}