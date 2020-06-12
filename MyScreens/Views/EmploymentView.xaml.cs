using Prism.Regions;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;

namespace MyScreens.Views
{
    /// <summary>
    /// Interaction logic for EmploymentEntryPageView.xaml
    /// </summary>
    public partial class EmploymentView : UserControl
    {
        //IRegionManager _regionManager;
        public EmploymentView()//IRegionManager regionManager )
        {
            InitializeComponent();
            //_regionManager = regionManager;
        }
        //public void Show(string navigateToHomePage)
        //{
        //    if (navigateToHomePage != null)
        //        _regionManager.RequestNavigate("MainRegion", navigateToHomePage);
        //}
    }
}
