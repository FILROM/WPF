using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ProektOOP
{
    /// <summary>
    /// Logika interakcji dla klasy AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();         

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "MIN 5";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "MIN 5";
                passBox.Background = Brushes.DarkRed;
            } else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authUser = null;
                using (AppContext db = new AppContext())
                {
                    authUser = db.Users.Where(b =>b.Login == login && b.Pass == pass).FirstOrDefault();
                }

                if (authUser != null)
                {
                    MessageBox.Show("SUCESS!");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }             
                else
                    MessageBox.Show("Wrong pass or login");
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
