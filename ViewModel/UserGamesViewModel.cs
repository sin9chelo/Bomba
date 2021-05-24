using Main.Data.Static_Resources;
using Main.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Main.ViewModel
{
    public class UserGamesViewModel : INotifyPropertyChanged 
    {
        ObservableCollection<GAME> games;

        public UserGamesViewModel()
        {
            games = new ObservableCollection<GAME>();
            using (ApplicationDBEntities context = new ApplicationDBEntities())
            {
                foreach (var game in context.USER_GAME)
                {
                    if(game.USER_ID == CurrentUser.User.USER_ID)
                    {
                        games.Add(context.GAME.Where(t => t.GAME_ID == game.GAME_ID).First());
                    }
                }
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
    }
}
