using UnityDevConsole;
using UnityDevConsole.Settings;
using UnityEngine;
using Zenject;

public static class AppModule
{
    public static DeveloperConsole DeveloperConsole { get; private set; }

    [RuntimeInitializeOnLoadMethod]
    static void AutoInitialize ()
    {
        if (ConsoleSettings.Instance.AutoInitialize)
            Initialize();
    }

    static void Initialize ()
    {
        if (DeveloperConsole != null)
            return;

        DiContainer ctx = ProjectContext.Instance.Container;
        DeveloperConsoleInstaller.Install(ProjectContext.Instance.Container);
        DeveloperConsole = ctx.Resolve<DeveloperConsole>();
    }
}
