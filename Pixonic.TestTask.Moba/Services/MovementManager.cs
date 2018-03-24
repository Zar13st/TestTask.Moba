using Pixonic.TestTask.Moba.Contracts;
using Pixonic.TestTask.Moba.Interfaces;
using System;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba.Services
{
    public class MovementManager : IMovementManager
    {
        #region Public Methods

        public void MoveHero(IMoveable hero, TimeSpan dt, Vector2 movementVector)
        {
            Contract.Assert(hero != null, "hero!=null");
            Contract.Assert(movementVector != null, "movementVector!=null");

            var distance = dt.TotalSeconds * hero.MovementSpeed;

            var dx = distance * movementVector.X;

            var dy = distance * movementVector.Y;

            hero.Move(dx, dy);
        }

        #endregion Public Methods
    }
}