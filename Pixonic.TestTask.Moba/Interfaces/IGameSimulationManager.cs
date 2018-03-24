using Pixonic.TestTask.Moba.Contracts;

namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IGameSimulationManager
    {
        #region Public Methods

        void CreateMatch();

        void TickHandler(Tick tick);

        bool GameOver { get; }

        #endregion Public Methods
    }
}