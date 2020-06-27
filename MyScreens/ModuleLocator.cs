using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyScreens.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MyScreens
{
    public class ModuleLocator : IModule
    {
        private IRegionManager _regionManager;

        public ModuleLocator(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(LoginScreen));
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //_regionManager.RegisterViewWithRegion("MainRegion", typeof(HomeScreen));
            //containerRegistry.Register(typeof(HomeScreen));
        }
    }
}
