using Caliburn.Micro;
using SimpleInjector;

namespace TestingCaliburnMicro.Configuration
{
    public class SimpleInjectorInitialisation
    {
        public static Container Initialise()
        {
            var container = new Container();

            RegisterCaliburnMicro(container);
            RegisterInstances(container);

            container.Verify();

            return container;
        }

        private static void RegisterInstances(Container container)
        {
        }

        private static void RegisterCaliburnMicro(Container container)
        {
            container.RegisterSingleton<IWindowManager, WindowManager>();
            container.RegisterSingleton<IEventAggregator, EventAggregator>();
        }
    }
}