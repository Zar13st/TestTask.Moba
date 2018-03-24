using Pixonic.TestTask.Moba.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba
{
    public class MatchMaker : IMatchMaker
    {
        #region Private Fields

        private readonly IHeroBuilder _heroBuilder;

        private int _nextHeroId;

        #endregion Private Fields

        #region Public Constructors

        public MatchMaker(IHeroBuilder heroBuilder)
        {
            Contract.Assert(heroBuilder != null, "heroBuilder!=null");

            _heroBuilder = heroBuilder;
        }

        #endregion Public Constructors

        #region Public Methods

        public List<IHero> GetHeroesList()
        {
            var heroList = new List<IHero>();

            _nextHeroId = 0;

            _heroBuilder.PrepeareConfigs();

            BuildTeam(Team.Red, ref heroList);

            BuildTeam(Team.Blue, ref heroList);

            return heroList;
        }

        #endregion Public Methods

        #region Private Methods

        private void BuildTeam(Team team, ref List<IHero> heroList)
        {
            for (var i = 0; i < GameConsts.HeroesInTeamCount; i++)
            {
                var hero = _heroBuilder.Build(_nextHeroId, team);

                heroList.Add(hero);

                _nextHeroId++;
            }
        }

        #endregion Private Methods
    }
}