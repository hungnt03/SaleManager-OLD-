using SaleManager.WPF.Models;
using SaleManager.WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SaleManager.WPF.ViewModels
{
    public class NavigationBarViewModel : BaseViewModel, IPageViewModel
    {
        public NavigationBarModel _data { set; get; }
        public ICommand BackCommand { set; get; }
        public ICommand LogOutCommand { set; get; }
        public ICommand SettingCommand { set; get; }
        public NavigationBarModel Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged("NavigationBarData");
            }
        }

        public NavigationBarViewModel()
        {
            BackCommand = new RelayCommand<NavigationBarModel>(
                (l) => true,
                (l) => Back()
            );
        }
        private void Back()
        {
            App.Messenger.NotifyColleagues(SysConstant.POP_SCREEN, null);
        }
    }
}
