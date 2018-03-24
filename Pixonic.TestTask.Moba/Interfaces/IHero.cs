using Pixonic.TestTask.Moba.Heroes;
using System;
using System.Collections.Generic;

namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IHero : ICoordinateProvider, IMoveable, IAutoAttackSpeedChangeable, IAutoAttackDamageChangeable
    {
        #region Public Properties

        int Id { get; }
        Team Team { get; }
        HeroType HeroType { get; }

        double AutoAttackInterval { get; }
        double AutoAttackRange { get; }
        double NextAutoAttackTimeInSeconds { get; }
        double HealthPoints { get; }

        bool CanAttack { get; }
        bool IsAlive { get; }

        List<IOnAttackAbility> OnAttackAbilities { get; }
        List<IOnTickStartAbility> OnTickStartAbilities { get; }

        Dictionary<int, IAbilityEffect> OnTickEndEffectByType { get; }
        Dictionary<int, IAbilityEffect> PreFightEffectByType { get; }

        #endregion Public Properties

        #region Public Methods

        void AutoAttack(IHero targetHero);

        void CleanAllEffects();

        void ShiftNextAutoAttackTime(TimeSpan dt);

        void ApplyDamage(double damage);

        #endregion Public Methods
    }
}