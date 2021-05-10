using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Validation
{
    class Validation_ByAnnotas : ObservableObject
    {
        private string _username;

        [Required(ErrorMessage = "Must not be empty.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Must be at least 5 characters.")]
        public string Username
        {
            get { return _username; }
            set
            {
                ValidateProperty(value, "Username");
                OnPropertyChanged(ref _username, value);
            }
        }

        private string _mail;

        [Required(ErrorMessage = "Must not be empty.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Must include one of domains.")]
        public string Mail
        {
            get { return _mail; }
            set 
            {
                ValidateProperty(value, "Mail");
                OnPropertyChanged(ref _mail, value);
            }
        }

        private string _password;

        [Required(ErrorMessage = "Must not be empty.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Must be at least 5 characters.")]
        public string Password
        {
            get { return _password; }
            set
            {
                ValidateProperty(value, "Password");
                OnPropertyChanged(ref _password, value);
            }
        }

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }
    }
}
