using RestSharp;
using SaleManager.WPF.Models;
using SaleManager.WPF.Utilities;
using SaleManager.WPF.Views.Admin.Product;
using SaleManager.WPF.Views.Template;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SaleManager.WPF.ViewModels.Admin.Product
{
    public class ProductListViewModel : BaseViewModel
    {
        private ProductModel _productSelected { set; get; }
        public ObservableCollection<ProductModel> Products { set; get; }
        private bool _isAllItemsSelected { set; get; }
        public ICommand AddProductCommand { set; get; }
        public IPageViewModel MenuPage { set; get; }
        public ProductModel ProductSelected
        {
            get { return _productSelected; }
            set
            {
                _productSelected = value;
                OnPropertyChanged("ProductSelected");
                //App.Messenger.NotifyColleagues(SysConstant.POP_ADMIN_SCREEN, null);
                //App.Messenger.NotifyColleagues(SysConstant.PUSH_ADMIN_SCREEN, _menuSelected.ScreenUC);
            }
        }
        public bool IsAllItemsSelected
        {
            get { return _isAllItemsSelected; }
            set
            {
                _isAllItemsSelected = value;
                OnPropertyChanged("IsAllItemsSelected");

                foreach (var product in Products)
                {
                    product.IsSelected = value;
                }
            }
        }

        public ProductListViewModel()
        {
            var apiProducts = GetProducts();
            Products = new ObservableCollection<ProductModel>();
            if(apiProducts != null)
            {
                foreach (var apiProduct in apiProducts)
                {
                    Products.Add(new ProductModel(apiProduct));
                }
            }

            AddProductCommand = new RelayCommand<ProductModel>(
                (l) => true,
                (l) => NavigateAddProduct()
            );

            MenuPage = new MenuView();
        }
        public void NavigateAddProduct()
        {
            App.Messenger.NotifyColleagues(SysConstant.PUSH_ADMIN_SCREEN, new ProductCreateView());
        }
        private List<SaleManager.WebApi.Models.ProductModel> GetProducts()
        {
            var client = new RestClient("https://localhost:44313");
            var request = new RestRequest("api/Products/Index", Method.GET);
            var queryResult = client.Execute<List<SaleManager.WebApi.Models.ProductModel>>(request).Data;
            return queryResult;
        }
    }
}
