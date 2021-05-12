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
using Main.Data.Static_Resources;
using Main.Data;
using Main.Repositories;

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

                using (UnitOfWork context = new UnitOfWork())
                {

                    context.UserRepository.SignUpUser(SignBoxLogin.Text, SignBoxPassword.Text, SignBoxEmail.Text);
                    
                }
                OpenLoad();
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
        
        public void OpenLoad()
        {
            Loading load = new Loading();
            load.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
