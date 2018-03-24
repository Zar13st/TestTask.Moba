namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IOnAttackEffect
    {
        #region Public Methods

        void ApplyOnAttack(IHero attackingHero, IHero attackedHero);

        #endregion Public Methods
    }
}