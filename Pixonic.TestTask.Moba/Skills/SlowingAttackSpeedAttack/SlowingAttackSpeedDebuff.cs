using Pixonic.TestTask.Moba.Interfaces;
using System;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba.Skills.SlowingAttackSpeedAttack
{
    public class SlowingAttackSpeedDebuff : IAbilityEffect
    {
        #region Private Fields

        private readonly TimeSpan _duration;
        private readonly IIntervalFromLastTickProvider _intervalFromLastTickProvider;
        private readonly double _slowingRate;
        private readonly IAutoAttackSpeedChangeable _targetHero;
        private bool _isEnabled;
        private bool _isEnabledAtThisTick;
        private bool _isHeroUnderEffect;
        private TimeSpan _restOfDurationTime;

        #endregion Private Fields

        #region Public Constructors

        public SlowingAttackSpeedDebuff(IAutoAttackSpeedChangeable targetHero, IIntervalFromLastTickProvider intervalFromLastTickProvider, double slowingRate, TimeSpan duration)
        {
            Contract.Assert(targetHero != null, "targetHero!=null");
            Contract.Assert(intervalFromLastTickProvider != null, "intervalFromLastTickProvider!=null");
            Contract.Assert(slowingRate > 1, "slowingRate > 1");
            Contract.Assert(duration > TimeSpan.Zero, "duration > TimeSpan.Zero");

            _targetHero = targetHero;
            _intervalFromLastTickProvider = intervalFromLastTickProvider;
            _slowingRate = slowingRate;
            _duration = duration;
        }

        #endregion Public Constructors

        #region Public Properties

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value)
                {
                    _isEnabledAtThisTick = true;
                    _restOfDurationTime = _duration;
                }
                _isEnabled = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public void Activate()
        {
            if (!IsEnabled)
            {
                return;
            }

            if (!_isEnabledAtThisTick)
            {
                _restOfDurationTime -= _intervalFromLastTickProvider.IntervalFromLastTick;
            }
            else
            {
                _isEnabledAtThisTick = false;
            }

            if (!_isHeroUnderEffect)
            {
                _isHeroUnderEffect = true;

                _targetHero.DecreaseAutoAttackSpeed(_slowingRate);
            }
        }

        public void Сlean()
        {
            if (!IsEnabled || _restOfDurationTime > TimeSpan.Zero)
            {
                return;
            }

            _targetHero.IncreaseAutoAttackSpeed(_slowingRate);

            IsEnabled = false;

            _isHeroUnderEffect = false;
        }

        #endregion Public Methods
    }
}