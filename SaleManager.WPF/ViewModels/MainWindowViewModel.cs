using SaleManager.WPF.Utilities;
using SaleManager.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.WPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageViewModel;
        private Stack<IPageViewModel> _pageViewModels;
        public Stack<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new Stack<IPageViewModel>();

                return _pageViewModels;
            }
        }
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged("CurrentPageViewModel");
            }
        }
        private void PushViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Push(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }
        private void PopViewModel()
        {
            PageViewModels.Pop();

            CurrentPageViewModel = PageViewModels.Peek();
        }
        public MainWindowViewModel()
        {
            PageViewModels.Push(new LoginView());
            CurrentPageViewModel = PageViewModels.Peek();

            Messenger messenger = App.Messenger;
            messenger.Register(SysConstant.PUSH_SCREEN, (Action<IPageViewModel>)(param => PushViewModel(param)));
        }
    }
}
