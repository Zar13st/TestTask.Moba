using Pixonic.TestTask.Moba.Interfaces;
using System;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba.Skills.CriticalDamageAura
{
    public class CriticalDamageBuff : IAbilityEffect
    {
        #region Private Fields

        private readonly double _damageMultiplier;
        private readonly Random _random = new Random();
        private readonly IAutoAttackDamageChangeable _targetHero;
        private bool _proc;

        #endregion Private Fields

        #region Public Constructors

        public CriticalDamageBuff(IAutoAttackDamageChangeable hero, double damageMultiplier)
        {
            Contract.Assert(hero != null, "hero!=null");
            Contract.Assert(damageMultiplier > 1, "damageMultiplier > 1");

            _targetHero = hero;
            _damageMultiplier = damageMultiplier;
        }

        #endregion Public Constructors

        #region Public Properties

        public bool IsEnabled { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void Activate()
        {
            if (!IsEnabled)
            {
                return;
            }

            _proc = TryProc();

            if (_proc)
            {
                _targetHero.AutoAttackDamage *= _damageMultiplier;
            }
        }

        public void Сlean()
        {
            if (!IsEnabled)
            {
                return;
            }

            if (_proc)
            {
                _targetHero.AutoAttackDamage /= _damageMultiplier;
                _proc = false;
            }
        }

        #endregion Public Methods

        #region Private Methods

        private bool TryProc()
        {
            var random0Or1 = _random.Next(0, 2);

            return random0Or1 != 0;
        }

        #endregion Private Methods
    }
}