using SaleManager.WPF.ViewModels;
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

namespace SaleManager.WPF.Views.Template
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl,IPageViewModel
    {
        public MenuView()
        {
            InitializeComponent();
            List<Person> persons = new List<Person>();
            persons.Add(new Person() { Age = 10, Name = "Yin", Icon= "AboutOutline" });
            persons.Add(new Person() { Age = 11, Name = "Yang", Icon = "AccessPoint" });
            persons.Add(new Person() { Age = 12, Name = "Yo", Icon = "AllInclusive" });

            this.DataContext = new MenuViewModel();
        }
    }
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Icon { set; get; }
    }
}
