using System;

namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IIntervalFromLastTickService : IIntervalFromLastTickProvider
    {
        #region Public Methods

        void SetIntervalFromLastTick(TimeSpan interval);

        #endregion Public Methods
    }
}