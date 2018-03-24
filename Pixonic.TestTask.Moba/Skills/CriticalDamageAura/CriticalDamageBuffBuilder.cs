using Pixonic.TestTask.Moba.Interfaces;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba.Skills.CriticalDamageAura
{
    public class CriticalDamageBuffBuilder : IEffectBuilder
    {
        #region Private Fields

        private readonly double _damageMultiplier;
        private readonly EffectName _name = EffectName.CriticalDamageBuff;

        #endregion Private Fields

        #region Public Constructors

        public CriticalDamageBuffBuilder(IEffectIdProvider effectIdProvider, int sourseHeroId, double damageMultiplier)
        {
            Contract.Assert(effectIdProvider != null, "effectIdProvider !=null");
            Contract.Assert(damageMultiplier >= 1, "damageMultiplier >= 1");
            Contract.Assert(sourseHeroId >= 0, "sourseHeroId >= 0");

            EffectId = effectIdProvider.GetId(_name, sourseHeroId);

            _damageMultiplier = damageMultiplier;
        }

        #endregion Public Constructors

        #region Public Properties

        public int EffectId { get; }

        #endregion Public Properties

        #region Public Methods

        public IAbilityEffect GetEffectForHero(IHero hero)
        {
            Contract.Assert(hero != null, "hero !=null");

            return new CriticalDamageBuff(hero, _damageMultiplier);
        }

        #endregion Public Methods
    }
}