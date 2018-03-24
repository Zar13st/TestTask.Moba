using Ninject;
using Pixonic.TestTask.Moba;
using Pixonic.TestTask.Moba.Interfaces;

namespace IoC.GameSimulation
{
    public class GameSimulationContainer
    {
        #region Public Methods

        public IGameSimulationManager Begin()
        {
            var kernel = new StandardKernel();

            kernel.Load(new GameSimulationModule());

            var gameSimulationManager = kernel.Get<GameSimulationManager>();

            return gameSimulationManager;
        }

        #endregion Public Methods
    }
}