using Pixonic.TestTask.Moba.Contracts;
using System.Collections.Generic;

namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IGameSimulation
    {
        #region Public Methods

        void InsertHeroList(List<IHero> heroes);

        void TickHandler(Tick tick);

        bool GameOver { get; }

        #endregion Public Methods
        }
}