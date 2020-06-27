using Prism.Unity;
using System;
using Prism.Regions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyScreens.Views;

namespace WpfApp_DMS
{
    [Obsolete]
    class BootStrapper : UnityBootstrapper
    {
        IRegionManager regionManager;      
        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
        }
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
            regionManager = new RegionManager();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterTypeForNavigation<LoginScreen>("LoginScreen");
            Container.RegisterTypeForNavigation<HomeScreen>("HomeScreen");
            Container.RegisterTypeForNavigation<EmploymentView>("EmploymentView");
            Container.RegisterTypeForNavigation<IncomingWorkContract>("IncomingWorkContract");
            Container.RegisterTypeForNavigation<SearchPage>("SearchPage");


        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            Type ModuleLocatorType = typeof(MyScreens.ModuleLocator);
            ModuleCatalog.AddModule(new Prism.Modularity.ModuleInfo
            {
                ModuleName = ModuleLocatorType.Name,
                ModuleType = ModuleLocatorType.AssemblyQualifiedName

            });
        }
    }
}
