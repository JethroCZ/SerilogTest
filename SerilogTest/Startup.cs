using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace SerilogTest
{
    public class Startup
    {
        public void Run()
        {
            var container = SetInstallers();
            var app = container.Resolve<IApp>();
            app.RunApplication();
        }

        private IWindsorContainer SetInstallers()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IWindsorContainer>().Instance(container).LifestyleSingleton());
            container.Install(FromAssembly.Instance(Assembly.GetExecutingAssembly()));
            return container;
        }
    }
}