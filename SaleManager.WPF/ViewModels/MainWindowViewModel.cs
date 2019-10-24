using SaleManager.WPF.Utilities;
using SaleManager.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleManager.WPF.Utilities;

namespace SaleManager.WPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private NavigationModel<IPageViewModel> _page;
        public NavigationModel<IPageViewModel> Page
        {
            get { return _page; }
            set
            {
                _page = value;
                OnPropertyChanged("Page");
            }
        }
        public MainWindowViewModel()
        {
            _page = new NavigationModel<IPageViewModel>(new LoginView());

            Messenger messenger = App.Messenger;
            messenger.Register(SysConstant.PUSH_SCREEN, (Action<IPageViewModel>)(param => Page.Push(param)));
            messenger.Register(SysConstant.POP_SCREEN, (Action<IPageViewModel>)(param => Page.Pop()));
        }
    }
}
