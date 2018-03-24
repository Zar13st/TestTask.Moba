using System.Collections.Generic;

namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IOnTickStartAbility
    {
        #region Public Methods

        void Apply(List<IHero> heroes);

        #endregion Public Methods
    }
}