namespace StartR.Web.App_Start
{
    using ServiceStack.Configuration;

    using StructureMap;

    public class StructureMapContainerAdapter : IContainerAdapter
    {
        public T TryResolve<T>()
        {
            return ObjectFactory.TryGetInstance<T>();
        }

        public T Resolve<T>()
        {
            return ObjectFactory.TryGetInstance<T>();
        }
    }
}