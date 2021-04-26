using Main.Entity;
using Main.Pages;
using System;
using System.Windows;
using System.Windows.Input;

namespace Main
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Close_Window(object sender, RoutedEventArgs e)
        {
            Main.Close();
        }
        private void MinMax_Window(object sender, RoutedEventArgs e)
        {
            if (Main.WindowState == WindowState.Maximized)
            {
                Main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                Main.WindowState = WindowState.Normal;
                Main.Height = 600;
                Main.Width = 1000;
            }
            else
                Main.WindowState = WindowState.Maximized;
        }

        private void MoveGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_MouseDown(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void StoreAct_Click(object sender, RoutedEventArgs e)
        {
            ActiveFrame.Content = new StorePage();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            ActiveFrame.Content = new ProfilePage();
        }

        //private void AddNewUser_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var context = new UserContext())
        //    {
        //        var user = new User()
        //        {
        //            Name = "Vitalik",
        //            Mail = "invalid@mail.ru",
        //            Password = "riki228Q%"
        //        };
        //        context.Users.Add(user);
        //        context.SaveChanges();

        //        Out.Text = Convert.ToString($"Id {user.Id}, Name {user.Name}, Mail {user.Mail}, Password {user.Password}");
        //    }

        //}
    }
}
