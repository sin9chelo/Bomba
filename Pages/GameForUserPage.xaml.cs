using Main.Repositories;
using Main.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Main.Pages
{
    /// <summary>
    /// Логика взаимодействия для GameForUserPage.xaml
    /// </summary>
    public partial class GameForUserPage : Page
    {
        public GameForUserPage()
        {
            InitializeComponent();
            this.DataContext = new UserGamesViewModel();
        }

        private void DownloadGame_Click(object sender, EventArgs e)
        {
            using(UnitOfWork context = new UnitOfWork())
            {
                if (!context.UserGameRepository.IsDownload(CurrentGame.Text))
                {
                    context.UserGameRepository.SetDownload(CurrentGame.Text);
                    DownloadText.Visibility = Visibility.Visible;
                    DownloadingBar.Visibility = Visibility.Visible;
                    string url = "https://download.virtualbox.org/virtualbox/6.0.6/VirtualBox-6.0.6-130049-Win.exe";
                    using (WebClient wc = new WebClient())
                    {
                        wc.OpenRead(url);
                        string size = (Convert.ToDouble(wc.ResponseHeaders["Content-Length"]) / 1048576).ToString("#.# MB");
                        wc.DownloadProgressChanged += (s, d) =>
                        {
                            DownloadingBar.Value = d.ProgressPercentage;
                            ProgressLabel.Text = $"Size file: {size}\n Downloading: {d.ProgressPercentage}% ({((double)d.BytesReceived / 1048576).ToString("#.# MB")})";
                        };
                        wc.DownloadFileAsync(new Uri(url),
                            @"D:\Game for bb\VirtualBox 6.0.6.exe");
                    }
                }
                else
                    App.FailedLoad();
            }
        }
    }
}
