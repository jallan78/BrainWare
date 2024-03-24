using Data.Repositories;
using Domain.Repositories;
using SimpleInjector;

namespace Data
{
    public static class DataComponentBootstrapper
    {
        public static void Bootstrap(Container container)
        {
            // Register data components with the DI container
            container.Register<IOrderQueryRepository, OrderQueryRepository>();
        }
    }
}
