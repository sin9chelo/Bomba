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
using Main.Other;

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
            using(UnitOfWork context = new UnitOfWork())
            {
                if (!context.UserRepository.FindDuplicate(SignBoxLogin.Text))
                {
                    if (SignBoxLogin.Text.Length >= 5 && SignBoxPassword.Text.Length >= 5 && SignBoxEmail.Text.Contains("@mail.ru"))
                    {
                        SignBtn.IsEnabled = true;


                        context.UserRepository.SignUpUser(SignBoxLogin.Text, SignBoxPassword.Text, SignBoxEmail.Text);


                        App.OpenLoad();
                    }
                    else
                    {
                        SignBtn.IsEnabled = false;
                    }
                }
                else
                    App.DuplicateLoad();
                    
            }
        }

        private void TextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            MessageBox.Show(e.Error.ErrorContent.ToString());
        }
    }
}
