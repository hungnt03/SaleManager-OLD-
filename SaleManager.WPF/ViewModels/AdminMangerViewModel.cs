using SaleManager.WPF.Utilities;
using SaleManager.WPF.Views.Admin.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.WPF.ViewModels
{
    class AdminMangerViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageAdminViewModel;
        private Stack<IPageViewModel> _pageAdminViewModels;
        public IPageViewModel CurrentPageAdminViewModel
        {
            get
            {
                return _currentPageAdminViewModel;
            }
            set
            {
                _currentPageAdminViewModel = value;
                OnPropertyChanged("CurrentPageAdminViewModel");
            }
        }
        public Stack<IPageViewModel> PageAdminViewModels
        {
            get
            {
                if (_pageAdminViewModels == null)
                    _pageAdminViewModels = new Stack<IPageViewModel>();

                return _pageAdminViewModels;
            }
        }
        private void PushViewModel(IPageViewModel viewModel)
        {
            if (!PageAdminViewModels.Contains(viewModel))
                PageAdminViewModels.Push(viewModel);

            CurrentPageAdminViewModel = PageAdminViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }
        private void PopViewModel()
        {
            PageAdminViewModels.Pop();

            if(PageAdminViewModels.Count>0)
                CurrentPageAdminViewModel = PageAdminViewModels.Peek();
        }
        public AdminMangerViewModel()
        {
            //PageAdminViewModels.Push(new ProductListView());
            CurrentPageAdminViewModel = new ProductListView();

            //Messenger messenger = App.Messenger;
            //messenger.Register(SysConstant.PUSH_ADMIN_SCREEN, (Action<IPageViewModel>)(param => PushViewModel(param)));
            //messenger.Register(SysConstant.POP_ADMIN_SCREEN, (Action<IPageViewModel>)(param => PopViewModel()));
        }
    }
}
