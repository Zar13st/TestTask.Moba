using Pixonic.TestTask.Moba.Interfaces;
using System;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba.Skills.SlowingAttackSpeedAttack
{
    public class SlowingAttackSpeedDebuffBuilder : IEffectBuilder
    {
        #region Private Fields

        private readonly TimeSpan _duration;
        private readonly IIntervalFromLastTickProvider _intervalFromLastTickProvider;
        private readonly EffectName _name = EffectName.SlowingAttackSpeedDebuff;
        private readonly double _slowingRate;

        #endregion Private Fields

        #region Public Constructors

        public SlowingAttackSpeedDebuffBuilder(IEffectIdProvider effectIdProvider, IIntervalFromLastTickProvider intervalFromLastTickProvider, double slowingRate, TimeSpan duration)
        {
            Contract.Assert(effectIdProvider != null, "effectIdProvider !=null");
            Contract.Assert(slowingRate >= 1, "slowingRate >= 1");
            Contract.Assert(duration >= TimeSpan.Zero, "duration >= TimeSpan.Zero");
            Contract.Assert(intervalFromLastTickProvider != null, "intervalFromLastTickProvider !=null");

            EffectId = effectIdProvider.GetId(_name, 0);

            _intervalFromLastTickProvider = intervalFromLastTickProvider;
            _slowingRate = slowingRate;
            _duration = duration;
        }

        #endregion Public Constructors

        #region Public Properties

        public int EffectId { get; }

        #endregion Public Properties

        #region Public Methods

        public IAbilityEffect GetEffectForHero(IHero hero)
        {
            Contract.Assert(hero != null, "hero !=null");

            return new SlowingAttackSpeedDebuff(hero, _intervalFromLastTickProvider, _slowingRate, _duration);
        }

        #endregion Public Methods
    }
}