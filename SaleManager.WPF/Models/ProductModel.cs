using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.WPF.Models
{
    public class ProductModel:BaseModel
    {
        private string _name;
        private int _quantity;
        private string _price;
        private string _barcode;
        private bool _isPin;
        private bool _isSelected;
        private PagedModel _paged;
        public ProductModel()
        {

        }
        public ProductModel(SaleManager.WebApi.Models.ProductModel apiModel)
        {
            Name = apiModel.Name;
            Quantity = apiModel.Quantity;
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            Price = double.Parse(apiModel.Price.ToString()).ToString("#,###", cul.NumberFormat);
            IsPin = apiModel.Pin==1;
        }
        public PagedModel Paged
        {
            get { return _paged; }
            set
            {
                _paged = value;
                OnPropertyChanged("Paged");
            }
        }
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
        public bool IsPin
        {
            get { return _isPin; }
            set
            {
                _isPin = value;
                OnPropertyChanged("IsPin");
            }
        }
        public string Barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                OnPropertyChanged("Barcode");
            }
        }
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
    }
    public class ProductCreateModel : BaseModel
    {
        private string _name;
        private int _quantity;
        private string _price;
        private string _barcode;
        private bool _isPin;
        private int _category;
        private int _supplier;
        public ProductCreateModel()
        {

        }
        public ProductCreateModel(SaleManager.WebApi.Models.ProductModel apiModel)
        {
            Name = apiModel.Name;
            Quantity = apiModel.Quantity;
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            Price = double.Parse(apiModel.Price.ToString()).ToString("#,###", cul.NumberFormat);
            Barcode = apiModel.Barcode;
            IsPin = apiModel.Pin == 1;
        }
        public SaleManager.WebApi.Models.ProductModel Generate()
        {
            var product = new SaleManager.WebApi.Models.ProductModel();
            product.Name = Name;
            product.CategoryId = Category;
            product.Pin = IsPin ? 1 : 0;
            product.Price = decimal.Parse(Price.Replace(",", ""));
            product.Quantity = Quantity;
            product.SupplierId = Supplier;
            return product;
        }
        public int Supplier
        {
            get { return _supplier; }
            set
            {
                _supplier = value;
                OnPropertyChanged("Supplier");
            }
        }
        public int Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged("Category");
            }
        }
        public bool IsPin
        {
            get { return _isPin; }
            set
            {
                _isPin = value;
                OnPropertyChanged("IsPin");
            }
        }
        public string Barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                OnPropertyChanged("Barcode");
            }
        }
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
    }
}
