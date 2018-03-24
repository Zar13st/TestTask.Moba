using Pixonic.TestTask.Moba.Interfaces;
using Pixonic.TestTask.Moba.Skills;

namespace Pixonic.TestTask.Moba.Services
{
    public class EffectIdProvider : IEffectIdProvider
    {
        #region Public Methods

        public int GetId(EffectName name, int heroId)
        {
            return (int)name * 10 + heroId;
        }

        #endregion Public Methods
    }
}