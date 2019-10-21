using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SaleManager.WPF.Utilities.Converters
{
    public class MoneyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal number;
            if (decimal.TryParse(value.ToString(), out number))
            {
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN"); 
                string vndFormat = double.Parse(value.ToString()).ToString("#,###", cul.NumberFormat);
                return vndFormat;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal number;
            if (string.IsNullOrEmpty(value.ToString())){
                if(decimal.TryParse(value.ToString().Replace(",",""), out number)){
                    return number;
                }
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
