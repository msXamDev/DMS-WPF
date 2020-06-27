using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScreens.ViewModels
{
    class SearchPageViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> HomeButton { get; set; }

        public SearchPageViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            HomeButton = new DelegateCommand<string>(HomeButtonClicked);
        }

        private void HomeButtonClicked(string obj)
        {
            if (obj != null)
                _regionManager.RequestNavigate("MainRegion", obj);
        }
    }
}
