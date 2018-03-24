namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IMoveable
    {
        #region Public Properties

        double MovementSpeed { get; set; }

        #endregion Public Properties

        #region Public Methods

        void Move(double dx, double dy);

        #endregion Public Methods
    }
}