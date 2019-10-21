using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.WPF.Models
{
    public class UserModel:BaseModel
    {
        private string _username;
        private string _password;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
    }
}
