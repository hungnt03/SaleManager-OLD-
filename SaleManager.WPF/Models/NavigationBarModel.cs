using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.WPF.Models
{
    public class NavigationBarModel : BaseModel
    {
        public string _screenName;
        public string ScreenName
        {
            get { return _screenName; }
            set
            {
                _screenName = value;
                OnPropertyChanged("ScreenName");
            }
        }
    }
}
