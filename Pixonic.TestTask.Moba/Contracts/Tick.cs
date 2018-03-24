using System;

namespace Pixonic.TestTask.Moba.Contracts
{
    public class Tick
    {
        #region Public Fields

        public Vector2[] HeroesMovement = new Vector2[4];
        public TimeSpan LastTickDeltaTime;

        #endregion Public Fields
    }
}