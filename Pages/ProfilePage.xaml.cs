using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using f = System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Main.Data.Static_Resources;
using Main.Data.Account;
using System.Net;
using Main.DB;
using Main.Repositories;

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
            this.DataContext = new Account();
        }


        private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.DefaultExt = ".png";
            file.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            if (file.ShowDialog() == true)
            {
                Uri fileUri = new Uri(file.FileName);
                ImgSlot.Source = new BitmapImage(fileUri);
            }


            using (WebClient wc = new WebClient())
            {
                
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            using (UnitOfWork context = new UnitOfWork())
            {
                context.UserRepository.ChangeRealname(RealnameText.Text);
                App.SuccesLoad();
            }
        }

        private void SavePassword_Click(object sender, RoutedEventArgs e)
        {
            using(UnitOfWork context = new UnitOfWork())
            {
                if (context.UserRepository.ChangePassword(NPassText.Text, OPassText.Text))
                    App.SuccesLoad();
                else
                    App.FailedLoad();
                OPassText.Clear();
                NPassText.Clear();
            }
        }

        private void Deposit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
