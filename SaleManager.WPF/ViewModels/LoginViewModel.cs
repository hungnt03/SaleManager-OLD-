using SaleManager.WPF.Models;
using SaleManager.WPF.Utilities;
using SaleManager.WPF.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SaleManager.WPF.ViewModels
{
    public class LoginViewModel:BaseViewModel,IPageViewModel
    {
        public UserModel _data { set; get; }
        public ICommand LoginCommand { set; get; }
        public UserModel Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged("Data");
            }
        }
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<UserModel>(
                (l) => true,
                (l) => Login()
            );
        }
        private void Login()
        {
            App.Messenger.NotifyColleagues(SysConstant.PUSH_SCREEN, new AdminManagerView());
        }
    }
}
