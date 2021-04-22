using System;
using System.Threading.Tasks;
using UnityDevConsole.Controllers.Console;
using UnityDevConsole.Controllers.Hint;
using UnityDevConsole.Controllers.Input;
using UnityDevConsole.Models.Command;
using UnityDevConsole.Models.Console;
using Zenject;

public class DeveloperConsole : IInitializable
{
    readonly IConsoleModel model;
    readonly ICommandsCollectionModel commandsCollectionModel;
    readonly IConsoleInputDetectorModel inputDetectorModel;
    readonly ConsoleUIController consoleUIController;
    readonly ConsoleHintUIController consoleHintUIController;

    public DeveloperConsole (
        IConsoleModel model,
        ICommandsCollectionModel commandsCollectionModel,
        IConsoleInputDetectorModel inputDetectorModel,
        ConsoleUIController consoleUIController,
        ConsoleHintUIController consoleHintUIController
    )
    {
        this.model = model;
        this.commandsCollectionModel = commandsCollectionModel;
        this.inputDetectorModel = inputDetectorModel;
        this.consoleUIController = consoleUIController;
        this.consoleHintUIController = consoleHintUIController;
    }

    [Inject]
    public void Initialize ()
    {
        Task.Run(commandsCollectionModel.Initialize);
    }

    public void Clear () => model?.ClearOutput();

    public void RegisterRuntimeCommand (
        string commandName,
        string methodName,
        object context,
        bool developerOnly,
        bool hidden
    )
    {
        model.RegisterRuntimeCommand(commandName, methodName, context, developerOnly, hidden);
    }

    public void UnregisterRuntimeCommand (string commandName)
        => model.UnregisterRuntimeCommand(commandName);

    public object ExecuteCommand (string commandName, string[] args)
        => model.ExecuteCommand(commandName, args);

    public void Log (object message) => model.Log(message);
}
