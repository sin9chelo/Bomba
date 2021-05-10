using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.DB;
using Main.Data.interfaces;
using Main.Data.repositories.@base;

namespace Main.Data.repositories
{
    public class UserGameRepository : Repository<USER_GAME>, IUserGameRepository
    {
        public ApplicationDBEntities AppContext => _context as ApplicationDBEntities;

        public UserGameRepository(ApplicationDBEntities context) : base(context)
        {

        }
    }
}
