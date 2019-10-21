using SaleManager.WPF.Utilities;
using SaleManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SaleManager.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static Messenger Messenger
        {
            get { return _messenger; }
        }

        readonly static Messenger _messenger = new Messenger();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow app = new MainWindow();
            MainWindowViewModel context = new MainWindowViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
}
