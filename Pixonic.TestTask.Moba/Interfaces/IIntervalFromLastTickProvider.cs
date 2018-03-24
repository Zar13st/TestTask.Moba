using System;

namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IIntervalFromLastTickProvider
    {
        #region Public Properties

        TimeSpan IntervalFromLastTick { get; }

        #endregion Public Properties
    }
}