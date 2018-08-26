namespace BMB.Core.Dependency
{
    public static class DependencyResolver
    {
        public static T Resolve<T>()
        {
            return DependencyRegistration.Instance.Resolve<T>();
        }
    }
}