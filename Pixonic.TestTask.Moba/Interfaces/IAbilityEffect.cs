namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IAbilityEffect
    {
        #region Public Properties

        bool IsEnabled { get; set; }

        #endregion Public Properties

        #region Public Methods

        void Activate();

        void Сlean();

        #endregion Public Methods
    }
}