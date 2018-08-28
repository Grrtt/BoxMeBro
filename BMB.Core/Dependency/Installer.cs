namespace BMB.Core.Dependency
{
    using System.IO;

    using BoxManagement;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterServicesInNamespace("BMB.Core", container);
            RegisterServicesInNamespace("BMB.Core.Keyboard", container);
            RegisterServicesInNamespace("BMB.Core.Process", container);
            RegisterServiceAsSingleton<IBoxRepository, BoxRepository>(container);
        }

        private static AssemblyFilter GetCurrentDirectory()
        {
            return new AssemblyFilter(Directory.GetCurrentDirectory());
        }

        private void RegisterServiceAsSingleton<TService, TImplementation>(IWindsorContainer container)
            where TService : class where TImplementation : TService
        {
            container.Register(Component.For<TService>().ImplementedBy<TImplementation>().LifestyleSingleton());
        }

        private void RegisterServicesInNamespace(string nameSpace, IWindsorContainer container)
        {
            container.Register(
                Classes.FromAssemblyInDirectory(GetCurrentDirectory()).InNamespace(nameSpace)
                       .WithServiceAllInterfaces());
        }
    }
}