using Main.Repositories;
using Main.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Main.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {

        public ProductPage()
        {
            InitializeComponent();
            this.DataContext = new GamesViewModel();
        }

        private void PurchaseGame_Click(object sender, RoutedEventArgs e)
        {
            using(UnitOfWork context = new UnitOfWork())
            {
                if (!context.UserGameRepository.IsPurchase(CurrentGameName.Text))
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                            (window as MainWindow).ActiveFrame.Navigate(new Uri("../Pages/PurchasePage.xaml", UriKind.RelativeOrAbsolute));
                    }
                }
                else
                    App.FailedLoad();
            }
        }
    }
}
