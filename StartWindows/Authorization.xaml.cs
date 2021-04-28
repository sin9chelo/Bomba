using Main.Pages;
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

namespace Main.StartWindows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            LoginAuthorPage.Content = new SignInPage();
            Color color = (Color)ColorConverter.ConvertFromString("#6AD1FE");
            InLine.Background = new SolidColorBrush(color);
            UpLine.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            LoginAuthorPage.Content = new SignUpPage();
            Color color = (Color)ColorConverter.ConvertFromString("#6AD1FE");
            UpLine.Background = new SolidColorBrush(color);
            InLine.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void Authoriz_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
