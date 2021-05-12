using Main.Data.interfaces;
using Main.Data.repositories.@base;
using Main.Data.Static_Resources;
using Main.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Data.repositories
{
    public class UserRepository : Repository<USER>, IUserRepository
    {
        public ApplicationDBEntities AppContext => _context as ApplicationDBEntities;

        public UserRepository(ApplicationDBEntities context) : base(context)
        {

        }

        public void SignUpUser(string login, string password, string username)
        {
            USER user = new USER(login, App.GetHash(password), username);
            AppContext.USER.Add(user);
            AppContext.SaveChanges();

            CurrentUser.User = user;
        }
    }
}
