namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IEffectBuilder
    {
        #region Public Properties

        int EffectId { get; }

        #endregion Public Properties

        #region Public Methods

        IAbilityEffect GetEffectForHero(IHero hero);

        #endregion Public Methods
    }
}