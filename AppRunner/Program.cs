namespace AppRunner
{
    using BMB.Core;
    using BMB.Core.Dependency;

    internal class Program
    {
        private static void Main()
        {
            DependencyRegistration.RegisterDependencies();
            BMBApplication bmb = Resolve<BMBApplication>();

            bmb.Start();
        }

        private static T Resolve<T>()
        {
            return DependencyResolver.Resolve<T>();
        }
    }
}