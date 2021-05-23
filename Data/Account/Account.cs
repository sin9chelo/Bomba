using Main.Data.Static_Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Data.Account
{
    public class Account
    {
        public Account()
        {

        }

        public string Username
        {
            get
            {
                return CurrentUser.User.USERNAME;
            }
            set {; }
        }

        public string Realname
        {
            get
            {
                return CurrentUser.User.REALNAME;
            }
            set {; }
        }
        public decimal? Balance
        {
            get
            {
                return CurrentUser.User.BALANCE;
            }
            set {; }
        }
    }
}
