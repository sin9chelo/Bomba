using System.Windows.Controls;
using Microsoft.Win32;
using f = System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;

namespace Main.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void PersonalSetting_Click(object sender, RoutedEventArgs e)
        {
            SettingsFrame.Content = new PersonalSettingsPage();
        }
    }
}
