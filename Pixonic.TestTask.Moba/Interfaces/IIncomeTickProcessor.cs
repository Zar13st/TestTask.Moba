using Pixonic.TestTask.Moba.Contracts;
using System.Collections.Generic;

namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IIncomeTickProcessor
    {
        #region Public Methods

        void InsertHeroList(List<IHero> heroes);

        void ProcessTick(Tick tick);

        #endregion Public Methods
    }
}