using SaleManager.WPF.ViewModels;
using SaleManager.WPF.ViewModels.Admin.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SaleManager.WPF.Views.Admin.Product
{
    /// <summary>
    /// Interaction logic for ProductListView.xaml
    /// </summary>
    public partial class ProductListView : UserControl,IPageViewModel
    {
        public ProductListView()
        {
            InitializeComponent();
            this.DataContext = new ProductListViewModel();
        }
    }
}
