using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SaleManager.WPF.Models
{
    public class MenuModel : BaseModel
    {
        private string _icon;
        private string _labelName;
        private string _screenId;
        public string ScreenId
        {
            get { return _screenId; }
            set
            {
                _screenId = value;
                OnPropertyChanged("ScreenId");
            }
        }
        public string LabelName
        {
            get { return _labelName; }
            set
            {
                _labelName = value;
                OnPropertyChanged("LabelName");
            }
        }
        public string Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged("Icon");
            }
        }
    }
}
