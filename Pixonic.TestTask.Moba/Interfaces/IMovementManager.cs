using Pixonic.TestTask.Moba.Contracts;
using System;

namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IMovementManager
    {
        #region Public Methods

        void MoveHero(IMoveable hero, TimeSpan dt, Vector2 movementVector);

        #endregion Public Methods
    }
}