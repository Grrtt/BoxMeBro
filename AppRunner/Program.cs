namespace AppRunner
{
    using System;
    using System.Windows.Forms;

    using BMB.Core;
    using BMB.Core.Dependency;

    internal class Program
    {
        private static void Main()
        {
            //IntPtr consoleWindowsHandle = Kernel32.GetConsoleWindow();
            //User32.ShowWindow(consoleWindowsHandle, User32.SW_HIDE);

            DependencyRegistration.RegisterDependencies();

            BMBApplication bmb = Resolve<BMBApplication>();

            bmb.Start();
            Application.Run();
            bmb.Stop();
        }

        private static T Resolve<T>()
        {
            return DependencyResolver.Resolve<T>();
        }
    }
}