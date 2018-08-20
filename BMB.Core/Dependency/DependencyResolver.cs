namespace BMB.Core.Dependency
{
    public class DependencyResolver
    {
        public static T Resolve<T>()
        {
            return DependencyRegistration.Instance.Resolve<T>();
        }
    }
}