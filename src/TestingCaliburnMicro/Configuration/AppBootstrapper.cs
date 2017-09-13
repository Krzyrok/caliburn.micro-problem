using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using SimpleInjector;
using TestingCaliburnMicro.ViewModels;

namespace TestingCaliburnMicro.Configuration
{
    public class AppBootstrapper : BootstrapperBase
    {
        private Container _container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container = SimpleInjectorInitialisation.Initialise();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            var serviceTypeForKey = service != null ? service : Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(type => type.IsClass && type.FullName?.Contains(key) == true);

            return _container.GetInstance(serviceTypeForKey);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            IServiceProvider provider = _container;
            Type collectionType = typeof(IEnumerable<>).MakeGenericType(service);
            var services = (IEnumerable<object>)provider.GetService(collectionType);
            return services ?? Enumerable.Empty<object>();
        }

        protected override void BuildUp(object instance)
        {
            var instanceProducer = _container.GetRegistration(instance.GetType(), true);
            instanceProducer.Registration.InitializeInstance(instance);
        }
    }
}
