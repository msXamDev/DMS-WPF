using Caliburn.Micro;
using MyScreens.Model;
using MyScreens.Models;
using MyScreens.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyScreens.ViewModels
{
    public class LoginScreenViewModel : BindableBase
    {
        //Login login = new Login();
        UserDetailEntities db = new UserDetailEntities();


        //var query;
        
        private IRegionManager _regionManager;
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DelegateCommand<object> LogIn { get; private set; }
        public LoginScreenViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            LogIn = new DelegateCommand<object>(LogInClicked);
        }

        private void LogInClicked( object parameter)
        {
            var query = from u in db.UserDeatils
                    where u.Username == UserName && u.Password == PassWord
                    select u;
            var passwordbox = parameter as PasswordBox;
            PassWord = passwordbox.Password;
            if (query.SingleOrDefault()!=null)
            {
                navigate navigateMeth = new navigate(_regionManager);
                navigateMeth.navigateMethod("HomeScreen");
                //MessageBox.Show("Login Successful");
            }
            else
            {
                MessageBox.Show("Incorrect Username or password", "Error !", MessageBoxButton.OK);
            }
        }
    }
    public class navigate : BindableBase
    {
        public IRegionManager _regionManager;
        public navigate(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void navigateMethod(string navigation)
        {
            if (navigation != null)
            {
                _regionManager.RequestNavigate("MainRegion", navigation);
            }
        }
    }

}
