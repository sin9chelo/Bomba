//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Main.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            this.USER_GAME = new HashSet<USER_GAME>();
        }
        Random random = new Random();
        public int _startBalance = 0;
        public USER(string username, string password, string mail)
        {
            this.USERNAME = username;
            this.PASSWORD_HASH = password;
            this.MAIL = mail;
            this.BALANCE = 0;
            this.REALNAME = "ok";

        }
        public int USER_ID { get; set; }
        public string REALNAME { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD_HASH { get; set; }
        public Nullable<decimal> BALANCE { get; set; }
        public string MAIL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_GAME> USER_GAME { get; set; }
    }
}
