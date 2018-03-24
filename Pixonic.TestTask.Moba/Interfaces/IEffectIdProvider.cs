using Pixonic.TestTask.Moba.Skills;

namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IEffectIdProvider
    {
        #region Public Methods

        int GetId(EffectName name, int heroId);

        #endregion Public Methods
    }
}