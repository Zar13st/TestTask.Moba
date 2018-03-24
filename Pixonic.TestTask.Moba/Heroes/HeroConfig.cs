using Pixonic.TestTask.Moba.Interfaces;
using System.Collections.Generic;

namespace Pixonic.TestTask.Moba.Heroes
{
    public class HeroConfig
    {
        #region Public Properties

        public float AutoAttackRange { get; set; }
        public double AutoAttackInterval { get; set; }
        public float AutoAttackDamage { get; set; }
        public float HealthPoints { get; set; }
        public HeroType HeroType { get; set; }
        public float MovementSpeed { get; set; }
        public List<IOnAttackAbility> OnAttackAbilities { get; set; } = new List<IOnAttackAbility>();
        public List<IOnTickStartAbility> OnTickStartAbilities { get; set; } = new List<IOnTickStartAbility>();
        public double StartPositionX { get; set; }

        public double StartPositionY { get; set; }

        #endregion Public Properties
    }
}