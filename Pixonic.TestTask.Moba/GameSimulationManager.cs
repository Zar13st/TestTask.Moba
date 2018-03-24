using Pixonic.TestTask.Moba.Contracts;
using Pixonic.TestTask.Moba.Interfaces;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba
{
    public class GameSimulationManager : IGameSimulationManager
    {
        #region Private Fields

        private readonly IGameSimulation _gameSimulation;
        private readonly IMatchMaker _matchMaker;
        private bool _isMatchCreated;

        #endregion Private Fields

        #region Public Constructors

        public GameSimulationManager(IMatchMaker matchMaker, IGameSimulation gameSimulation)
        {
            Contract.Assert(matchMaker != null, "matchMaker!=null");
            Contract.Assert(gameSimulation != null, "gameSimulation!=null");

            _matchMaker = matchMaker;
            _gameSimulation = gameSimulation;
        }

        #endregion Public Constructors

        #region Public Properties

        public bool GameOver => _gameSimulation.GameOver;

        #endregion Public Properties

        #region Public Methods

        public void CreateMatch()
        {
            var heroList = _matchMaker.GetHeroesList();

            _gameSimulation.InsertHeroList(heroList);

            _isMatchCreated = true;
        }

        public void TickHandler(Tick tick)
        {
            Contract.Assert(_isMatchCreated = true, "_isMatchCreated = true");

            _gameSimulation.TickHandler(tick);
        }

        #endregion Public Methods
    }
}