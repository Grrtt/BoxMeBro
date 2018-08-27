namespace BMB.Core.Dependency
{
    using System.IO;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public static class Registration
    {
        private static IWindsorContainer windsorContainer;

        public static IWindsorContainer Instance => windsorContainer ?? (windsorContainer = new WindsorContainer());

        public static void RegisterDependencies()
        {
            AssemblyFilter currentDirectoryAssemblyFilter = GetCurrentDirectoryAssemblyFilter();
            RegisterDirectory(currentDirectoryAssemblyFilter);
        }

        private static AssemblyFilter GetCurrentDirectoryAssemblyFilter()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return new AssemblyFilter(currentDirectory);
        }

        private static void RegisterDirectory(AssemblyFilter directoryAssemblyFilter)
        {
            Instance.Install(FromAssembly.InDirectory(directoryAssemblyFilter));
        }
    }
}