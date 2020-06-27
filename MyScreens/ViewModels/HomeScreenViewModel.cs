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
    class HomeScreenViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> EmpConButton { get; private set; }
        public DelegateCommand<string> IncWorkConButton { get; private set; }
        public DelegateCommand<string> SearchButton { get; private set; }

        public HomeScreenViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            EmpConButton = new DelegateCommand<string>(EmpConButtonClicked);
            IncWorkConButton = new DelegateCommand<string>(IncWorkConButtonClicked);
            SearchButton = new DelegateCommand<string>(SearchButtonClicked);
        }

        private void SearchButtonClicked(string NavigateToSearchPage)
        {
            if (NavigateToSearchPage != null)
                _regionManager.RequestNavigate("MainRegion", NavigateToSearchPage);
        }

        private void IncWorkConButtonClicked(string NavigateToIncWorkPage)
        {
            if (NavigateToIncWorkPage != null)
                _regionManager.RequestNavigate("MainRegion", NavigateToIncWorkPage);
        }

        private void EmpConButtonClicked(string NavigateToEmployementPage)
        {
            if (NavigateToEmployementPage != null)
                _regionManager.RequestNavigate("MainRegion", NavigateToEmployementPage);
        }
    }
}
