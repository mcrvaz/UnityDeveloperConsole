using System.Collections.Generic;
using Zenject;

namespace UnityDevConsole.Models.Command
{
    public interface ICommandsCollectionModel : IInitializable
    {
        IReadOnlyDictionary<string, ICommandModel> Commands { get; }

        bool RegisterRuntimeCommand (
            string commandName,
            string methodName,
            object context,
            bool developerOnly,
            bool hidden
        );

        void UnregisterRuntimeCommand (string commandName);
    }
}
