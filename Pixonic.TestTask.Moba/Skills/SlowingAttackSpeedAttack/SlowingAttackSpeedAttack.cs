using Pixonic.TestTask.Moba.Interfaces;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba.Skills.SlowingAttackSpeedAttack
{
    public class SlowingAttackSpeedAttack : IOnAttackAbility
    {
        #region Private Fields

        private readonly IEffectBuilder _effectBuilder;

        #endregion Private Fields

        #region Public Constructors

        public SlowingAttackSpeedAttack(IEffectBuilder effectBuilder)
        {
            Contract.Assert(effectBuilder != null, "effectBuilder!=null");

            _effectBuilder = effectBuilder;
        }

        #endregion Public Constructors

        #region Public Methods

        public void Apply(IHero targetHero)
        {
            Contract.Assert(targetHero != null, "targetHero!=null");

            if (!targetHero.OnTickEndEffectByType.ContainsKey(_effectBuilder.EffectId))
            {
                targetHero.OnTickEndEffectByType[_effectBuilder.EffectId] = _effectBuilder.GetEffectForHero(targetHero);
            }

            targetHero.OnTickEndEffectByType[_effectBuilder.EffectId].IsEnabled = true;
        }

        #endregion Public Methods
    }
}