using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.DB;
using Main.Data.interfaces;
using Main.Data.repositories.@base;
using Main.Data.Static_Resources;

namespace Main.Data.repositories
{
    public class UserGameRepository : Repository<USER_GAME>, IUserGameRepository
    {
        public ApplicationDBEntities AppContext => _context as ApplicationDBEntities;

        public UserGameRepository(ApplicationDBEntities context) : base(context)
        {

        }

        public void AddUserGame(USER_GAME curGame)
        {
            AppContext.USER_GAME.Add(curGame);
        }
        public bool IsPurchase(string name)
        {
            int iter = 0;

            var idGame = AppContext.GAME.Where(t => t.NAME.Equals(name)).Select(t=>t.GAME_ID).FirstOrDefault();

            var idGame2 = AppContext.GAME.Where(t => t.NAME.Equals(name)).FirstOrDefault().GAME_ID;

            foreach (USER_GAME u in AppContext.USER_GAME)
            {
                if (u.GAME_ID == idGame && CurrentUser.User.USER_ID == u.USER_ID)
                    iter++;
            }

            return iter == 1;
        }
        public void SetDownload(string name)
        {
            var idGame = AppContext.GAME.Where(t => t.NAME.Equals(name)).FirstOrDefault().GAME_ID;

            var userGame = AppContext.USER_GAME
                .Where(c => c.GAME_ID == idGame)
                .FirstOrDefault();
            userGame.IsDownload = 1;
            AppContext.SaveChanges();
        }
        public bool IsDownload(string name)
        {
            int iter = 0;

            var idGame = AppContext.GAME.Where(t => t.NAME.Equals(name)).FirstOrDefault().GAME_ID;

            var userGame = AppContext.USER_GAME
                .Where(c => c.GAME_ID == idGame && c.USER_ID == CurrentUser.User.USER_ID)
                .FirstOrDefault();
            if (userGame.IsDownload == 1)
                iter = 1;
            else
                iter = 0;
            return iter == 1;
        }
    }
}
