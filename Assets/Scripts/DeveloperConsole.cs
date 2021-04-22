using UnityDevConsole.Controllers.Console;
using UnityDevConsole.Controllers.Hint;
using UnityDevConsole.Controllers.Input;
using UnityDevConsole.Models.Command;
using UnityDevConsole.Models.Console;

public class DeveloperConsole
{
    public IConsoleModel Console { get; }
    public ICommandsCollectionModel CommandsCollectionModel { get; }
    public IConsoleInputDetectorModel InputDetectorModel { get; }
    public ConsoleUIController ConsoleUIController { get; }
    public ConsoleHintUIController ConsoleHintUIController { get; }

    public DeveloperConsole (
        IConsoleModel model,
        ICommandsCollectionModel commandsCollectionModel,
        IConsoleInputDetectorModel inputDetectorModel,
        ConsoleUIController consoleUIController,
        ConsoleHintUIController consoleHintUIController
    )
    {
        Console = model;
        CommandsCollectionModel = commandsCollectionModel;
        InputDetectorModel = inputDetectorModel;
        ConsoleUIController = consoleUIController;
        ConsoleHintUIController = consoleHintUIController;
    }

    public void Clear () => Console?.ClearOutput();

    public void RegisterRuntimeCommand (
        string commandName,
        string methodName,
        object context,
        bool developerOnly,
        bool hidden
    )
    {
        Console.RegisterRuntimeCommand(commandName, methodName, context, developerOnly, hidden);
    }

    public void UnregisterRuntimeCommand (string commandName)
        => Console.UnregisterRuntimeCommand(commandName);

    public object ExecuteCommand (string commandName, string[] args)
        => Console.ExecuteCommand(commandName, args);

    public void Log (object message) => Console.Log(message);
}
