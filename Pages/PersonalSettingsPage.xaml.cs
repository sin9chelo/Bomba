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
    /// Логика взаимодействия для PersonalSettingsPage.xaml
    /// </summary>
    public partial class PersonalSettingsPage : Page
    {
        public PersonalSettingsPage()
        {
            InitializeComponent();
        }
        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            if (openFile.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFile.FileName);
                ImgSource.Source = new BitmapImage(fileUri);
            }
        }
    }
}
