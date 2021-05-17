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
using Main.Data.Static_Resources;
using Main.Repositories;

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

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork context = new UnitOfWork())
            {
                context.UserRepository.SignInUser(SignBoxLogin.Text, SignBoxPassword.Text);
            }
        }

    }
}
