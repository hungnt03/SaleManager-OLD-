using SaleManager.WPF.Models;
using SaleManager.WPF.Utilities;
using SaleManager.WPF.Views.Admin.Customer;
using SaleManager.WPF.Views.Admin.Product;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SaleManager.WPF.ViewModels
{
    public class MenuViewModel:BaseViewModel
    {
        private MenuModel _menuSelected { set; get; }
        public ObservableCollection<MenuModel> Menus { set; get; }
        public ICommand BackCommand { set; get; }
        public MenuModel MenuSelected
        {
            get { return _menuSelected; }
            set
            {
                _menuSelected = value;
                OnPropertyChanged("MenuSelected");
                App.Messenger.NotifyColleagues(SysConstant.POP_ADMIN_SCREEN, null);
                App.Messenger.NotifyColleagues(SysConstant.PUSH_ADMIN_SCREEN, _menuSelected.ScreenUC);
            }
        }

        public MenuViewModel()
        {
            //BackCommand = new RelayCommand<NavigationBarModel>(
            //    (l) => true,
            //    (l) => Back()
            //);
            InitAdminMenu();
        }

        public void InitAdminMenu()
        {
            Menus = new ObservableCollection<MenuModel>();
            MenuModel product = new MenuModel()
            {
                Icon = "CartMinus",
                LabelName = "Quản lý sản phẩm",
                ScreenUC = new ProductListView()
            };
            MenuModel customer = new MenuModel()
            {
                Icon = "CustomerService",
                LabelName = "Quản lý khách hàng",
                ScreenUC = new CustomerListView()
            };
            Menus.Add(product);
            Menus.Add(customer);

        }
        //private void Back()
        //{
        //    App.Messenger.NotifyColleagues(SysConstant.POP_SCREEN, null);
        //}
    }
}
