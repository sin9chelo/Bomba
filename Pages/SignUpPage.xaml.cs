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
            if(SignBoxLogin.Text.Length >= 5 && SignBoxPassword.Text.Length >= 5 && SignBoxEmail.Text.Contains("@mail.ru"))
            {
                SignBtn.IsEnabled = true;

                using (ApplicationDBEntities context = new ApplicationDBEntities())
                {
                    USER user = new USER(SignBoxLogin.Text, App.GetHash(SignBoxPassword.Text), SignBoxEmail.Text);
                    context.USER.Add(user);
                    context.SaveChanges();

                    Loading load = new Loading();
                    load.Show();
                    Application.Current.MainWindow.Close();
                }
            }
            else
            {
                SignBtn.IsEnabled = false;
            }
        }

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            MessageBox.Show(e.Error.ErrorContent.ToString());
        }
    }
}
