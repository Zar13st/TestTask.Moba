using Pixonic.TestTask.Moba.Heroes;
using System.Collections.Generic;

namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IConfigsProvider
    {
        #region Public Methods

        Dictionary<HeroType, HeroConfig> GetConfigs();

        #endregion Public Methods
    }
}