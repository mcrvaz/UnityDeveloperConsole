using System;
using Zenject;

namespace UnityDevConsole.Controllers.Input
{
    public interface IConsoleInputDetectorModel : IInitializable, IDisposable
    {
        event Action OnToggleVisibility;
        event Action OnSubmit;
        event Action OnMoveUp;
        event Action OnMoveDown;
        event Action OnEscape;
    }
}
