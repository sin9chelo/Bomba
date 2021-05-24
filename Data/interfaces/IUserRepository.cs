using Main.Data.interfaces.@base;
using Main.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Data.interfaces
{
    public interface IUserRepository : IRepository<USER>
    {
        void SignUpUser(string login, string password, string username);
        void SignInUser(string username, string password);
        bool IsEqualData(string username, string password);
        void ChangeRealname(string realname);
        bool ChangePassword(string pass, string oldpass);
        bool FindDuplicate(string username);
        void SetPay(decimal money);
    }
}
