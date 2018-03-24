using Pixonic.TestTask.Moba.Interfaces;
using System;

namespace Pixonic.TestTask.Moba.Services
{
    public class IntervalFromLastTickService : IIntervalFromLastTickService
    {
        #region Public Properties

        public TimeSpan IntervalFromLastTick { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public void SetIntervalFromLastTick(TimeSpan interval)
        {
            IntervalFromLastTick = interval;
        }

        #endregion Public Methods
    }
}