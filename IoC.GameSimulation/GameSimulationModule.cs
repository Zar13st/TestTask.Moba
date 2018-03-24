using Ninject.Modules;
using Pixonic.TestTask.Moba;
using Pixonic.TestTask.Moba.Heroes;
using Pixonic.TestTask.Moba.Interfaces;
using Pixonic.TestTask.Moba.Services;

namespace IoC.GameSimulation
{
    public class GameSimulationModule : NinjectModule
    {
        #region Public Methods

        public override void Load()
        {
            Bind<IMatchMaker>().To<MatchMaker>().InSingletonScope();

            Bind<IGameSimulation>().To<Pixonic.TestTask.Moba.GameSimulation>().InSingletonScope();

            Bind<IHeroBuilder>().To<HeroBuilder>().InSingletonScope();

            Bind<IConfigsProvider>().To<HeroesConfigProvider>().InSingletonScope();

            Bind<IHeroAbilityProvider>().To<HeroAbilityProvider>().InSingletonScope();

            Bind<IIntervalFromLastTickService>().To<IntervalFromLastTickService>().InSingletonScope();

            Bind<IIncomeTickProcessor>().To<IncomeTickProcessor>().InSingletonScope();

            Bind<IMovementManager>().To<MovementManager>().InSingletonScope();

            Bind<IEffectIdProvider>().To<EffectIdProvider>().InSingletonScope(); 

            Bind<IAutoAttackTargetProvider>().To<AutoAttackTargetProvider>().InSingletonScope();
        }

        #endregion Public Methods
    }
}