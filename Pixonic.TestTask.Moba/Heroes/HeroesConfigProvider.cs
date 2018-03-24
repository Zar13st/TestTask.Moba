using Pixonic.TestTask.Moba.Interfaces;
using System.Collections.Generic;

namespace Pixonic.TestTask.Moba.Heroes
{
    public class HeroesConfigProvider : IConfigsProvider
    {
        #region Public Methods

        public Dictionary<HeroType, HeroConfig> GetConfigs()
        {
            var configs = new Dictionary<HeroType, HeroConfig>();

            var fighterHeroConfig = new HeroConfig()
            {
                HealthPoints = 100,
                MovementSpeed = 2,
                AutoAttackRange = 2,
                AutoAttackDamage = 5,
                AutoAttackInterval = 1,
                HeroType = HeroType.Fighter,
            };

            configs[HeroType.Fighter] = fighterHeroConfig;

            var rangeHeroConfig = new HeroConfig()
            {
                HealthPoints = 100,
                MovementSpeed = 2,
                AutoAttackRange = 10,
                AutoAttackDamage = 2,
                AutoAttackInterval = 1,
                HeroType = HeroType.Range,
            };

            configs[HeroType.Range] = rangeHeroConfig;

            var supportHeroConfig = new HeroConfig()
            {
                HealthPoints = 100,
                MovementSpeed = 2,
                AutoAttackRange = 2,
                AutoAttackDamage = 2,
                AutoAttackInterval = 1,
                HeroType = HeroType.Support,
            };

            configs[HeroType.Support] = supportHeroConfig;

            return configs;
        }

        #endregion Public Methods
    }
}