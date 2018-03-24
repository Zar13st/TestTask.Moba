using Pixonic.TestTask.Moba.Heroes;
using Pixonic.TestTask.Moba.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba.Skills.CriticalDamageAura
{
    public class CriticalDamageAura : IOnTickStartAbility
    {
        #region Private Fields

        private readonly IEffectBuilder _effectBuilder;

        private readonly IHero _sourceHero;
        private readonly double _sqrActivationRange;

        #endregion Private Fields

        #region Public Constructors

        public CriticalDamageAura(IHero sourceHero, IEffectBuilder effectBuilder, double range)
        {
            Contract.Assert(sourceHero != null, "sourceHero!=null");
            Contract.Assert(effectBuilder != null, "effectBuilder!=null");
            Contract.Assert(range >= 0, "range >= 0");

            _effectBuilder = effectBuilder;
            _sqrActivationRange = range * range;
            _sourceHero = sourceHero;
        }

        #endregion Public Constructors

        #region Public Methods

        public void Apply(List<IHero> heroes)
        {
            Contract.Assert(heroes != null, "heroes!=null");

            foreach (var targetHero in heroes)
            {
                if (_sourceHero.Team != targetHero.Team)
                {
                    continue;
                }

                if (!targetHero.PreFightEffectByType.ContainsKey(_effectBuilder.EffectId))
                {
                    targetHero.PreFightEffectByType[_effectBuilder.EffectId] = _effectBuilder.GetEffectForHero(targetHero);
                }

                var sqrDistance = _sourceHero.SqrDistanceTo(targetHero);

                targetHero.PreFightEffectByType[_effectBuilder.EffectId].IsEnabled = sqrDistance <= _sqrActivationRange;
            }
        }

        #endregion Public Methods
    }
}