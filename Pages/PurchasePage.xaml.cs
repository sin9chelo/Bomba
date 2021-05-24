using Main.Data.Static_Resources;
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
    /// Логика взаимодействия для PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Page
    {
        public PurchasePage()
        {
            InitializeComponent();
            this.DataContext = new GamesViewModel();
        }

        private void Purchase_Click(object sender, RoutedEventArgs e)
        {
            decimal? balance = CurrentUser.User.BALANCE;
            decimal price = CurrentGame.Game.PRICE;
            if (balance > price)
            {
                CurrentUser.User.BALANCE = balance - price;
                using (UnitOfWork context = new UnitOfWork())
                {
                    context.UserGameRepository.Add(new DB.USER_GAME(CurrentUser.User.USER_ID, CurrentGame.Game.GAME_ID));
                    context.UserRepository.ChangeBalance(CurrentUser.User.BALANCE);
                    context.SaveChanges();
                    App.SuccesLoad();
                }
            }
            else
                App.FailedLoad();
        }
    }
}
