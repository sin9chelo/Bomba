using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Main.DB;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
