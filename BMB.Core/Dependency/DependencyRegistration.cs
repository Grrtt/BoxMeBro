namespace BMB.Core.Dependency
{
    using System.IO;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public static class DependencyRegistration
    {
        private static IWindsorContainer windsorContainer;

        public static IWindsorContainer Instance => windsorContainer ?? (windsorContainer = new WindsorContainer());

        public static void RegisterDependencies()
        {
            AssemblyFilter currentDirectoryAssemblyFilter = GetCurrentDirectoryAssemblyFilter();
            Instance.Install(FromAssembly.InDirectory(currentDirectoryAssemblyFilter));
        }

        private static AssemblyFilter GetCurrentDirectoryAssemblyFilter()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return new AssemblyFilter(currentDirectory);
        }
    }
}