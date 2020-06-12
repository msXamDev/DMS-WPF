using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyScreens.Views
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : UserControl
    {
        public LoginScreen()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=SAQUIBVSTORE\SAQUIBSQL; Initial Catalog=DMS-WPF; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = "SELECT COUNT(1) FROM LoginCredentials WHERE username=@username AND password=@password";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@password", password.Password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    var window = new Window();
                    window.Content = new EmploymentView();
                    window.Show();
                    Window.GetWindow(this).Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
    }
}
