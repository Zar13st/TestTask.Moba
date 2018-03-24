namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IAutoAttackSpeedChangeable
    {
        #region Public Methods

        void DecreaseAutoAttackSpeed(double factor);

        void IncreaseAutoAttackSpeed(double factor);

        #endregion Public Methods
    }
}