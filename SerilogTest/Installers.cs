using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Services.Logging.SerilogIntegration;
using Castle.Windsor;
using Serilog;
using Component = Castle.MicroKernel.Registration.Component;

namespace SerilogTest
{
    public class Installers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IApp>().ImplementedBy<App>().LifestyleSingleton());
            container.Register(Component.For<SerilogConfig>().ImplementedBy<SerilogConfig>().LifestyleSingleton());
            container.AddFacility<LoggingFacility>(f => f.LogUsing(new SerilogFactory(new LoggerConfiguration().ReadFrom.Configuration(container.Resolve<SerilogConfig>().GetConfiguration()).CreateLogger())));
        }
    }
}