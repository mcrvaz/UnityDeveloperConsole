using UnityDevConsole.Controllers.Console;
using UnityDevConsole.Controllers.Hint;
using UnityDevConsole.Controllers.Input;
using UnityDevConsole.Models.Command;
using UnityDevConsole.Models.Command.Parser;
using UnityDevConsole.Models.Console;
using UnityDevConsole.Models.Console.Hint;
using UnityDevConsole.Settings;
using UnityDevConsole.Views;
using UnityDevConsole.Views.Hint;
using Zenject;

namespace UnityDevConsole
{
    public class DeveloperConsoleInstaller : Installer<DeveloperConsoleInstaller>
    {
        public override void InstallBindings ()
        {
            InstallGeneric();
            InstallSettings();
            InstallModels();
            InstallControllers();
            InstallViews();

            Container.BindInterfacesAndSelfTo<DeveloperConsole>().AsSingle();
        }

        void InstallGeneric ()
        {
            Container.Bind<IInput>().To<UnityInput>().AsSingle();
        }

        void InstallSettings ()
        {
            Container.Bind<IConsoleSettings>()
                .To<ConsoleSettings>()
                .FromScriptableObjectResource(ConsoleSettings.SETTINGS_NAME)
                .AsSingle();
        }

        void InstallModels ()
        {
            Container.Bind<ICommandRunnerModel>().To<CommandRunnerModel>().AsSingle();
            Container.Bind<ICommandParser>().To<CommandParserModel>().AsSingle();
            Container.Bind<ITypeParserModel>().To<TypeParserModel>().AsSingle();
            Container.Bind<IConsoleOutputModel>().To<ConsoleOutputModel>().AsSingle();
            Container.Bind<IConsoleInputHistoryModel>().To<ConsoleInputHistoryModel>().AsSingle();
            Container.Bind<ICommandsCollectionModel>().To<CommandsCollectionModel>().AsSingle();
            Container.Bind<IConsoleCommandFactory>().To<ConsoleCommandFactory>().AsSingle();
            Container.Bind<IConsoleHintModel>().To<ConsoleHintModel>().AsSingle();
            Container.Bind<IConsoleInputDetectorModel>().To<ConsoleInputDetectorModel>().AsSingle();
            Container.Bind(typeof(IConsoleStateProvider), typeof(IConsoleModel))
                .To<ConsoleModel>()
                .AsSingle();
        }

        void InstallControllers ()
        {
            Container.Bind<ConsoleUIController>().AsSingle().NonLazy();
            Container.Bind<ConsoleHintUIController>().AsSingle().NonLazy();
        }

        void InstallViews ()
        {
            Container.Bind<IConsoleHintEntryUIViewFactory>().To<ConsoleHintEntryUIViewFactory>()
                .AsSingle();
            Container.Bind<IConsoleUIView>()
                .To<ConsoleUIView>()
                .FromMethod(
                    (ctx) => ConsoleUIViewFactory.Create(ctx.Container.Resolve<IConsoleSettings>())
                )
                .AsCached();
            Container.Bind<ICoroutineRunner>().To<IConsoleUIView>().FromResolve();
            Container.Bind<IHintUIView>().FromResolveGetter<IConsoleUIView>(x => x.HintUI)
                .AsSingle();
        }
    }
}
