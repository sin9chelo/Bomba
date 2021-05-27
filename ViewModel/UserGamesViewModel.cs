using Main.Commands;
using Main.Data.Static_Resources;
using Main.DB;
using Main.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Main.ViewModel
{
    public class UserGamesViewModel : INotifyPropertyChanged 
    {
        ObservableCollection<GAME> games;

        public UserGamesViewModel()
        {
            games = new ObservableCollection<GAME>();
            using (UnitOfWork context = new UnitOfWork())
            {
                foreach (var game in context.UserGameRepository.AppContext.USER_GAME)
                {
                    if(game.USER_ID == CurrentUser.User.USER_ID)
                    {
                        games.Add(context.UserRepository.AppContext.GAME.Where(t => t.GAME_ID == game.GAME_ID).First());
                    }
                }
                GameInfoCommand = new RelayCommand(ExecuteGameInfo);
            }
        }

        public ICommand GameInfoCommand
        {
            get;
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

        public GAME Game => CurrentGame.Game;

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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
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
                    (window as MainWindow).ActiveFrame.Navigate(new Uri("../Pages/GameForUserPage.xaml", UriKind.RelativeOrAbsolute));
            }

        }
    }
}
