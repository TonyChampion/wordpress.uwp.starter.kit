using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using WPStarter.UWP.Models;

namespace WPStarter.UWP.Converters
{
    public class CategoryOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(value != null && value is Category)
            {
                var cat = value as Category;

                return cat.MaxCount == 0 ? 1.0 : ((double)cat.Count / (double)cat.MaxCount / 2.0) + 0.5;
            }

            return 1.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
