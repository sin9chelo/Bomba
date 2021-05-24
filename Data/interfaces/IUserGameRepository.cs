using Main.Data.interfaces.@base;
using Main.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Data.interfaces
{
    public interface IUserGameRepository : IRepository<USER_GAME>
    {
        void AddUserGame(USER_GAME curGame);
    }
}
