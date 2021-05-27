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
using System.Net.Mail;

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
                        App.FailedLoad();
                        
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

        //private bool IsValidMail(string emailAddress)
        //{
        //    bool flag = false;
        //    char symbol = '@';
        //    int id = emailAddress.IndexOf(symbol);
        //    string domain = emailAddress.Substring(id);
        //    List<string> mails = new List<string>() { "@mail.ru", "@gmail.com", "@yandex.com" };
        //    if (CountSymbol(emailAddress) == 1)
        //    {
        //        foreach (string u in mails)
        //        {
        //            if (domain == u)
        //                flag = true;
        //            else
        //                flag = false;
        //        }
        //    }
        //    else
        //        App.FailedLoad();
        //    return flag;
        //}
        //private int CountSymbol(string emailAddress)
        //{
        //    var symbol = '@';
        //    int i = 0, count = 0;
        //    while ((i = emailAddress.IndexOf(symbol, i)) != -1)
        //    {
        //        ++count;
        //        i += 1;
        //    }
        //    return count;
        //}
        //private bool ValidMail(string email)
        //{
        //    if (email.Contains("@mail.ru") && email.Substring(email.Length).Length == 0)
        //        return true;
        //    else
        //        return false;
        //}

        private void SignBoxLogin_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            
            e.Handled = !(Char.IsLetterOrDigit(e.Text, 0));
            
        }
    }
}
