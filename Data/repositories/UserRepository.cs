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

        public bool IsEqualData(string username, string password)
        {
            bool flag = false;
            
            var users = AppContext.USER.ToList();
            foreach (USER u in users)
            {
                if (username == u.USERNAME && App.GetHash(password) == u.PASSWORD_HASH)
                {
                    flag = true;
                    CurrentUser.User = u;
                }
            }
            
            return flag;
        }

        public void SignInUser(string username, string password)
        {

            if (IsEqualData(username, password))
                App.OpenLoad();
            else
                App.FailedLoad();
        }
        public void ChangeRealname(string realname)
        {
            var user = AppContext.USER
                .Where(c => c.USERNAME == CurrentUser.User.USERNAME)
                .FirstOrDefault();

            user.REALNAME = realname;
            CurrentUser.User.REALNAME = realname;

            AppContext.SaveChanges();
        }
        public bool ChangePassword(string pass, string oldpass)
        {
            bool flag = false;
            if(CurrentUser.User.PASSWORD_HASH == App.GetHash(oldpass))
            {
                var user = AppContext.USER
                .Where(c => c.PASSWORD_HASH == CurrentUser.User.PASSWORD_HASH)
                .FirstOrDefault();

                user.PASSWORD_HASH = App.GetHash(pass);

                AppContext.SaveChanges();
                CurrentUser.User.PASSWORD_HASH = App.GetHash(pass);

                flag = true;
                return flag;
            }
            else
            {
                return false;
            }
        }

        public bool FindDuplicate(string username)
        {
            bool flag = false;

            var users = AppContext.USER.ToList();
            foreach(USER u in users)
            {
                if (username == u.USERNAME)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public void SetPay(decimal money)
        {
            var user = AppContext.USER
                .Where(c => c.USERNAME == CurrentUser.User.USERNAME)
                .FirstOrDefault();

            user.BALANCE += money;
            AppContext.SaveChanges();
            CurrentUser.User.BALANCE = user.BALANCE;
        }
        public void ChangeBalance(decimal? balance)
        {
            var user = AppContext.USER
                .Where(c => c.USERNAME == CurrentUser.User.USERNAME)
                .FirstOrDefault();

            user.BALANCE = balance;
            CurrentUser.User.BALANCE = balance;

            AppContext.SaveChanges();
        }
    }
}
