using Main.StartWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Main.DB;
using System.Security.Cryptography;

namespace Main.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (ApplicationDBEntities context = new ApplicationDBEntities())
                {
                    USER user = new USER(SignBoxLogin.Text, App.GetHash(SignBoxPassword.Text), SignBoxEmail.Text);
                    context.USER.Add(user);
                    context.SaveChanges();
                }
            }
            catch
            {

            }
            Loading load = new Loading();
            load.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
