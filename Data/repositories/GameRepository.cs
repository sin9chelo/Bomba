using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Data.interfaces;
using Main.Data.repositories.@base;
using Main.DB;

namespace Main.Data.repositories
{
    public class GameRepository : Repository<GAME>, IGameRepository
    {
        public ApplicationDBEntities AppContext => _context as ApplicationDBEntities;

        public GameRepository(ApplicationDBEntities context) : base(context)
        {

        }
    }
}
