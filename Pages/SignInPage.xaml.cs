using Main.DB;
using Main.Other;
using Main.StartWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Main.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }
        private bool IsEqualData(string username, string password)
        {
            bool flag = false;
            using (ApplicationDBEntities context = new ApplicationDBEntities())
            {
                var users = context.USER.ToList();
                foreach(USER u in users)
                {
                    if (username == u.USERNAME && App.GetHash(password) == u.PASSWORD_HASH)
                        flag = true;
                }
            }
            return flag;
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationDBEntities context = new ApplicationDBEntities())
            {
                var users = context.USER.ToList();
                foreach (USER u in users)
                {
                    if (IsEqualData(SignBoxLogin.Text, SignBoxPassword.Text))
                    {
                        Loading load = new Loading();
                        load.Show();
                        Application.Current.MainWindow.Close(); 
                        break;
                    }
                    else
                    {
                        FailedWindow win = new FailedWindow();
                        win.Show();
                        break;
                    }
                }
            }
        }

    }
}
