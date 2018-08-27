namespace BMB.Core.Dependency
{
    public static class Resolver
    {
        public static T Resolve<T>()
        {
            return Registration.Instance.Resolve<T>();
        }
    }
}