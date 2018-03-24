using System.Collections.Generic;

namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IMatchMaker
    {
        #region Public Methods

        List<IHero> GetHeroesList();

        #endregion Public Methods
    }
}