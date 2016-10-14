using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Windows.UI.Xaml.Data;
using System.ComponentModel.DataAnnotations;

namespace WPStarter.UWP.Converters
{
    public class EnumDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(value != null)
            {
                var fieldInfo = value.GetType().GetRuntimeFields().FirstOrDefault(x => x.Name == value.ToString());

                if(fieldInfo != null)
                {
                    var attr = fieldInfo.GetCustomAttribute<DisplayAttribute>();

                    if(attr != null)
                    {
                        return attr.Name;
                    }
                }
                
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
