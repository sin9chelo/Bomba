using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Main.DB;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Main.Commands;
using Main.Data.Static_Resources;
using Main.Repositories;
using Main.Pages;

namespace Main.ViewModel
{
    public class GamesViewModel : INotifyPropertyChanged
    {

        ObservableCollection<GAME> games;

        public GamesViewModel()
        {
            games = new ObservableCollection<GAME>();
            using (ApplicationDBEntities context = new ApplicationDBEntities())
            {
                foreach(var game in context.GAME)
                {
                    games.Add(game);
                }
            }
            GameInfoCommand = new RelayCommand(ExecuteGameInfo);
        }

        public void SortByPrice()
        {
            Games = new ObservableCollection<GAME>(Games.OrderBy(t => t.PRICE));
        }
        public void SortByPDate()
        {
            Games = new ObservableCollection<GAME>(Games.OrderBy(t => t.PDATE));
        }
        public void GetGameBySearchRequest(string path)
        {
            try
            {
                Games = new ObservableCollection<GAME>(Games.Where(t => t.NAME.Contains(path)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public ObservableCollection<GAME> Games
        { 
            get => games;
            set
            {
                games = value;
                OnPropertyChanged("Games");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public GAME Game => CurrentGame.Game;

        public USER User => CurrentUser.User;

        public string Username
        {
            get
            {
                return CurrentUser.User.USERNAME;
            }
        }  

        public ICommand GameInfoCommand
        {
            get;
        }

        public string Name
        {
            get
            {
                return CurrentGame.Game.NAME;
            }
        }

        public decimal Price
        {
            get
            {
                return CurrentGame.Game.PRICE;
            }
        }

        public DateTime PDate
        {
            get
            {
                return CurrentGame.Game.PDATE;
            }
        }

        public string Publisher
        {
            get
            {
                return CurrentGame.Game.PUBLISHER;
            }
        }

        public string Size
        {
            get
            {
                return CurrentGame.Game.SIZE;
            }
        }

        public string GamePlatform
        {
            get
            {
                return CurrentGame.Game.GAME_PLATFORM;
            }
        }

        public string Type
        {
            get
            {
                return CurrentGame.Game.TYPE;
            }
        }

        public string Address
        {
            get
            {
                return CurrentGame.Game.GAME_ADDRESS;
            }
        }

        public string Description
        {
            get
            {
                return CurrentGame.Game.DESCRIPTION;
            }
        }

        
        public static void ExecuteGameInfo(object obj)
        {
            using (UnitOfWork context = new UnitOfWork())
            {
                context.GameRepository.CurrentGameRe(obj);
            }

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                    (window as MainWindow).ActiveFrame.Navigate(new Uri("../Pages/ProductPage.xaml", UriKind.RelativeOrAbsolute));
            }

        }
    }
}
