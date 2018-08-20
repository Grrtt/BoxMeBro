namespace BMB.Core.Dependency
{
    using System.IO;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterServicesInDirectory(Directory.GetCurrentDirectory(), container);
        }

        private void RegisterServicesInDirectory(string directory, IWindsorContainer container)
        {
            container.Register(
                Classes.FromAssemblyInDirectory(new AssemblyFilter(directory)).Pick().WithServiceAllInterfaces());
        }
    }
}