using System;

namespace Pixonic.TestTask.Moba.Skills
{
    public static class SkillsConsts
    {
        #region Public Properties

        public static double CriticalDamageAuraDamageMultiplier { get; } = 2.0;
        public static double CriticalDamageAuraRange { get; } = 5.0;
        public static TimeSpan SlowingAttackSpeedDebuffDuration { get; } = TimeSpan.FromSeconds(1);
        public static double SlowingAttackSpeedDebuffRate { get; } = 1.5;
        public static TimeSpan SlowingMovementDebuffDuration { get; } = TimeSpan.FromSeconds(1);
        public static double SlowingMovementDebuffRate { get; } = 2.0;

        #endregion Public Properties
    }
}