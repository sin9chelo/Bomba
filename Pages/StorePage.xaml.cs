using Main.Commands;
using Main.Data.Static_Resources;
using Main.DB;
using Main.Repositories;
using Main.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Main.Pages
{
    /// <summary>
    /// Логика взаимодействия для StorePage.xaml
    /// </summary>
    public partial class StorePage : Page
    {
        GamesViewModel games = new GamesViewModel();
        public StorePage()
        {
            InitializeComponent();
            this.DataContext = games;
        }

        private void SortByPrice_Click(object sender, RoutedEventArgs e)
        {
            games.SortByPrice();
        }

        private void SortByPdate_Click(object sender, RoutedEventArgs e)
        {
            games.SortByPDate();
        }

        private void ContentSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string str = ((this.ContentSelect.SelectedValue as GAME).NAME).ToString();
            using (UnitOfWork context = new UnitOfWork())
            {
                CurrentGame.Game = context.GameRepository.AppContext.GAME.Where(g => g.NAME.Equals(str)).FirstOrDefault();
            }
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                    (window as MainWindow).ActiveFrame.Navigate(new Uri("../Pages/ProductPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void SearchGame_Click(object sender, RoutedEventArgs e)
        {
            games.GetGameBySearchRequest(SearchString.Text);
        }
        
    }

}
