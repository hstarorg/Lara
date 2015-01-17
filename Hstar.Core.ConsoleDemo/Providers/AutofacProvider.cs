using Autofac;
using Hstar.Core.Ioc;

namespace Hstar.Core.ConsoleDemo.Providers
{
    public class AutofacProvider:IContainerProvider
    {
        private IContainer container;

        public AutofacProvider()
        {
            this.InitIocContainer();
        }
        private void InitIocContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Test1>().As<Test1>();
            container=builder.Build();
        }

        public T GetInstance<T>()
        {
            return container.Resolve<T>();
        }
    }
}
