using Pixonic.TestTask.Moba.Interfaces;
using System;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba.Skills.SlowingMovementAttack
{
    public class SlowingMovementDebuffBuilder : IEffectBuilder
    {
        #region Private Fields

        private readonly TimeSpan _duration;
        private readonly IIntervalFromLastTickProvider _intervalFromLastTickProvider;
        private readonly EffectName _name = EffectName.SlowingMovementDebuff;
        private readonly double _slowingRate;

        #endregion Private Fields

        #region Public Constructors

        public SlowingMovementDebuffBuilder(IEffectIdProvider effectIdProvider, IIntervalFromLastTickProvider intervalFromLastTickProvider, int sourseHeroId, double slowingRate, TimeSpan duration)
        {
            Contract.Assert(slowingRate >= 1, "slowingRate >= 1");
            Contract.Assert(duration >= TimeSpan.Zero, "duration >= TimeSpan.Zero");
            Contract.Assert(intervalFromLastTickProvider != null, "intervalFromLastTickProvider !=null");
            Contract.Assert(sourseHeroId >= 0, "sourseHeroId >= 0");
            Contract.Assert(effectIdProvider != null, "effectIdProvider !=null");

            EffectId = effectIdProvider.GetId(_name, sourseHeroId);

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

            return new SlowingMovementDebuff(hero, _intervalFromLastTickProvider, _slowingRate, _duration);
        }

        #endregion Public Methods
    }
}