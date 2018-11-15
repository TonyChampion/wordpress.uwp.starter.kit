using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WPStarter.UWP.Converters
{
    public class ContentPreviewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var ret = "";

            if(value != null)
            {
                ret = Regex.Replace(value.ToString(), "<.*?>", String.Empty);
                ret = Regex.Replace(ret, "(http*)", String.Empty);
                ret = ret.Replace("[", "");
                ret = ret.Replace("]", "");
                ret = ret.Replace("\n", "");
                ret = ret.Replace("\t", "");

                var words = ret.Split(new char[] { ' ' });
                ret = String.Join(" ", words.Take(40)).Trim();

                if(words.Count() > 40)
                {
                    ret += "...";
                }
            }

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
