using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace SEABOURNE.SEABOURNECode.Cards
{
    /// <summary>
    /// Base class for all Seabourne cards.  This class provides a minimal
    /// implementation of the STS2 <see cref="CustomCardModel"/> API while
    /// exposing a virtual <see cref="EnergyGain"/> property so derived
    /// classes can override it.  Cards should override <see cref="OnPlay"/>
    /// to implement their behaviour and <see cref="OnUpgrade"/> to change
    /// values on upgrade.  You can access primary damage and block values
    /// via <see cref="PrimaryDamage"/> and <see cref="PrimaryBlock"/>.
    /// </summary>
    public abstract class SeabourneCard : CustomCardModel
    {
        protected SeabourneCard(int cost, CardType type, CardRarity rarity, TargetType target)
            : base(cost, type, rarity, target)
        {
        }

        /// <summary>
        /// The amount of energy refunded when this card is played.  By default
        /// cards do not refund energy; override this in derived classes as
        /// necessary.
        /// </summary>
        public virtual int EnergyGain => 0;

        /// <summary>
        /// Provides the canonical dynamic variables for this card.  Derived
        /// classes should override to return one or more <see cref="DynamicVar"/>
        /// instances (e.g. <see cref="DamageVar"/>, <see cref="BlockVar"/>).
        /// </summary>
        protected virtual IEnumerable<DynamicVar> CanonicalVars => Array.Empty<DynamicVar>();

        /// <summary>
        /// Provides the canonical tags for this card.  Derived classes can
        /// override to tag their card with <see cref="CardTag.Strike"/>,
        /// <see cref="CardTag.Defend"/>, etc.
        /// </summary>
        protected virtual HashSet<CardTag> CanonicalTags => new();

        /// <summary>
        /// Gets the primary damage variable for this card, defaulting to zero
        /// if no damage var is present.
        /// </summary>
        protected DamageVar PrimaryDamage
        {
            get
            {
                if (DynamicVars.TryGetValue("Damage", out var dyn) && dyn is DamageVar dmg)
                    return dmg;
                return new DamageVar(0m, ValueProp.Move);
            }
        }

        /// <summary>
        /// Gets the primary block variable for this card, defaulting to zero
        /// if no block var is present.
        /// </summary>
        protected BlockVar PrimaryBlock
        {
            get
            {
                if (DynamicVars.TryGetValue("Block", out var dyn) && dyn is BlockVar blk)
                    return blk;
                return new BlockVar(0m, ValueProp.Move);
            }
        }

        /// <summary>
        /// Override of <see cref="CardModel.Play"/> to invoke derived
        /// implementation of <see cref="OnPlay"/>.  This override preserves
        /// energy-gain semantics by adding the energy returned from
        /// <see cref="EnergyGain"/> back to the player after the card
        /// completes.
        /// </summary>
        protected override async Task Play(PlayerChoiceContext choiceContext, CardPlay cardPlay)
        {
            await OnPlay(choiceContext, cardPlay);
            // refund energy if specified
            var gain = EnergyGain;
            if (gain > 0)
            {
                // gain energy via common action; fallback to reflection if CommonActions is unavailable
                // This call may require the CommonActions helper from BaseLib, but we try to find it
                try
                {
                    var commonActionsType = Type.GetType("BaseLib.Utils.CommonActions, BaseLib");
                    var gainEnergyMethod = commonActionsType?.GetMethod("GainEnergy");
                    gainEnergyMethod?.Invoke(null, new object?[] { cardPlay.Card.Owner, gain });
                }
                catch
                {
                    // ignore if energy helper not available
                }
            }
        }

        /// <summary>
        /// Derived classes must implement their play behaviour here.  This
        /// method is called by the framework when the card is played.
        /// </summary>
        protected abstract Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play);

        /// <summary>
        /// Derived classes can override to adjust dynamic vars on upgrade.
        /// Called automatically when the card is upgraded.
        /// </summary>
        protected virtual void OnUpgrade() { }
    }
}