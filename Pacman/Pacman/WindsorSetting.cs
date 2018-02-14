using Castle.MicroKernel.Registration;
using Castle.Windsor;
using OperationManager.CheckerManager;
using OperationManager.DataManager;
using OperationManager.GameManager;
using OperationManager.Interface;
using OperationManager.StoreDataManager;
using OperationManager.Update;
using PacmanGame.GameManager;
using PacmanGame.ReportManager;

namespace PacmanGame
{
    public static class WindsorSetting
    {
        public static WindsorContainer RegisterContainer()
        {
            var container = new WindsorContainer();

            container.Register(Component.For<ISqLiteConnection>().ImplementedBy<SqLiteConnection>());
            container.Register(Component.For<IGenerateChecker>().ImplementedBy<GenerateChecker>());
            container.Register(Component.For<IReportGenerate>().ImplementedBy<ReportGenerate>());
            container.Register(Component.For<IBeforeGameStartRun>().ImplementedBy<BeforeGameStartRun>());
            container.Register(Component.For<IReproduce>().ImplementedBy<Reproduce>());
            container.Register(Component.For<IStoreData>().ImplementedBy<StoreData>());
            container.Register(Component.For<IGame>().ImplementedBy<Game>());
            container.Register(Component.For<IGameResult>().ImplementedBy<GameResult>());
            container.Register(Component.For<IRunTheGame>().ImplementedBy<RunTheGame>());
            container.Register(Component.For<IUpgradeFromOldDatabase>().ImplementedBy<UpgradeFromOldDatabase>());
            container.Register(Component.For<IRandomProvider>().ImplementedBy<RandomProvider>());
            container.Register(Component.For<IGeneration>().ImplementedBy<TheFirstGeneration>().Named("First"));
            container.Register(Component.For<IGeneration>().ImplementedBy<NextGeneration>().Named("Next"));
            //container.Register(Component.For<>().ImplementedBy<>());


            return container;
        }
    }
}
