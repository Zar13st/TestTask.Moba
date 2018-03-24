namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IHeroBuilder
    {
        #region Public Methods

        IHero Build(int id, Team team);

        void PrepeareConfigs();

        #endregion Public Methods
    }
}