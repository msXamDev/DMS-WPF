using MyScreens.Model;
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

namespace MyScreens.ViewModels
{
    public class LoginScreenViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        //dmsEntities dmsEntity = new dmsEntities();
        Login login = new Login();
        public DelegateCommand<string> LoginButton { get; private set; }

        public LoginScreenViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            LoginButton = new DelegateCommand<string>(LoginButtonClicked);
        }

        private void LoginButtonClicked(string NavigateToHomePage)
        {
            //SqlConnection sqlCon = new SqlConnection(@"Data Source=SAQUIBVSTORE\SAQUIBSQL; Initial Catalog=DMS-WPF; Integrated Security=True;");
            //try
            //{

            //    if (sqlCon.State == ConnectionState.Closed)
            //        sqlCon.Open();
            //    string query = "SELECT COUNT(1) FROM LoginCredentials WHERE username=@username AND password=@password";
            //    SqlCommand cmd = new SqlCommand(query, sqlCon);
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Parameters.AddWithValue("@username", login.username);
            //    cmd.Parameters.AddWithValue("@password", login.password);
            //    int count = Convert.ToInt32(cmd.ExecuteScalar());
            //    if (count == 1)
            //    {
            if (NavigateToHomePage != null)
            {
                _regionManager.RequestNavigate("MainRegion", NavigateToHomePage);
            }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Username or password is incorrect");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


    }
    
}
