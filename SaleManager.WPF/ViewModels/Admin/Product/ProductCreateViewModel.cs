using SaleManager.WPF.Models;
using SaleManager.WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SaleManager.WPF.ViewModels.Admin.Product
{
    public class ProductCreateViewModel : BaseViewModel
    {
        private ProductModel _product { set; get; }
        public ICommand AddProductCommand { set; get; }
        public ProductModel Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged("Product");
            }
        }

        public ProductCreateViewModel()
        {
            Product = new ProductModel();
            AddProductCommand = new RelayCommand<ProductModel>(
                (l) => true,
                (l) => AddProduct()
            );
        }

        public void AddProduct()
        {

        }
    }
}
