using Main.Pages;
using System.Windows;
using System.Windows.Input;
using Main.StartWindows;
using System;

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

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
            Authorization author = new Authorization();
            author.Show();
            //Application.Current.MainWindow.Close();
        }

        private void Store_Click(object sender, RoutedEventArgs e)
        {
            ActiveFrame.Content = new StorePage();
        }
    }
}
