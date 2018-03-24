using Pixonic.TestTask.Moba.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba.Heroes
{
    public class Hero : IHero
    {
        #region Public Constructors

        public Hero(HeroConfig config, int id, Team team)
        {
            Contract.Assert(config != null, "config!=null");

            HealthPoints = config.HealthPoints;
            MovementSpeed = config.MovementSpeed;
            AutoAttackRange = config.AutoAttackRange;
            AutoAttackDamage = config.AutoAttackDamage;
            AutoAttackInterval = config.AutoAttackInterval;
            HeroType = config.HeroType;
            Id = id;
            Team = team;
        }

        #endregion Public Constructors

        #region Public Properties

        public int Id { get; }
        public Team Team { get; }
        public HeroType HeroType { get; }

        public double AutoAttackDamage { get; set; }
        public double AutoAttackInterval { get; private set; }
        public double AutoAttackRange { get; }
        public double HealthPoints { get; private set; }
        public double MovementSpeed { get; set; }
        public double NextAutoAttackTimeInSeconds { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }

        public bool CanAttack => NextAutoAttackTimeInSeconds <= 0;
        public bool IsAlive => HealthPoints > 0;

        public List<IOnTickStartAbility> OnTickStartAbilities { get; } = new List<IOnTickStartAbility>();
        public List<IOnAttackAbility> OnAttackAbilities { get; } = new List<IOnAttackAbility>();

        public Dictionary<int, IAbilityEffect> PreFightEffectByType { get; } = new Dictionary<int, IAbilityEffect>();
        public Dictionary<int, IAbilityEffect> OnTickEndEffectByType { get; } = new Dictionary<int, IAbilityEffect>();

        #endregion Public Properties

        #region Public Methods

        public void ApplyDamage(double damage)
        {
            HealthPoints -= damage;
        }

        public void AutoAttack(IHero targetHero)
        {
            Contract.Assert(targetHero!=null, "targetHero!=null");
            Contract.Assert(CanAttack, "CanAttack");

            foreach (var effect in PreFightEffectByType)
            {
                effect.Value.Activate();
            }

            foreach (var ability in OnAttackAbilities)
            {
                ability.Apply(targetHero);
            }

            NextAutoAttackTimeInSeconds += AutoAttackInterval;

            targetHero.ApplyDamage(AutoAttackDamage);
        }

        public void CleanAllEffects()
        {
            foreach (var effect in PreFightEffectByType)
            {
                effect.Value.Сlean();
            }

            foreach (var effect in OnTickEndEffectByType)
            {
                effect.Value.Сlean();
            }
        }

        public void DecreaseAutoAttackSpeed(double factor)
        {
            AutoAttackInterval *= factor;
            NextAutoAttackTimeInSeconds *= factor;
        }

        public void IncreaseAutoAttackSpeed(double factor)
        {
            AutoAttackInterval /= factor;
            NextAutoAttackTimeInSeconds /= factor;
        }

        public void Move(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

        public void ShiftNextAutoAttackTime(TimeSpan dt)
        {
            if (NextAutoAttackTimeInSeconds > 0)
            {
                NextAutoAttackTimeInSeconds -= dt.TotalSeconds;
            }
        }

        #endregion Public Methods
    }
}