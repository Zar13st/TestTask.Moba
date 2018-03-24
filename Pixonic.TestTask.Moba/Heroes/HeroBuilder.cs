using Pixonic.TestTask.Moba.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Pixonic.TestTask.Moba.Heroes
{
    public class HeroBuilder : IHeroBuilder
    {
        #region Private Fields

        private readonly IConfigsProvider _configsProvider;
        private readonly Random _random = new Random();
        private readonly IHeroAbilityProvider _heroAbilityProvider;
        private Dictionary<HeroType, HeroConfig> _heroConfigs;

        #endregion Private Fields

        #region Public Constructors

        public HeroBuilder(IConfigsProvider configsProvider, IHeroAbilityProvider heroAbilityProvider)
        {
            Contract.Assert(configsProvider != null, "configsProvider!=null");
            Contract.Assert(heroAbilityProvider != null, "heroAbilityProvider!=null");

            _configsProvider = configsProvider;
            _heroAbilityProvider = heroAbilityProvider;
        }

        #endregion Public Constructors

        #region Public Methods

        public IHero Build(int id, Team team)
        {
            Contract.Assert(_heroConfigs != null, "_heroConfigs!=null");
            Contract.Assert(_heroConfigs.Any(), "_heroConfigs.Any()");

            var heroType = (HeroType)_random.Next(0, _heroConfigs.Count);

            var config = _heroConfigs[heroType];

            IHero hero = new Hero(config, id, team);

            _heroAbilityProvider.AddAbilitiesToConfig(ref hero);

            return hero;
        }

        public void PrepeareConfigs()
        {
            _heroConfigs = _configsProvider.GetConfigs();
        }

        #endregion Public Methods
    }
}