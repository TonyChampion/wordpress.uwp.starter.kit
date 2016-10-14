using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace WPStarter.UWP.Utilities
{
    public static class ProgressHelper
    {
        private static ProgressRing _ring;

        public static ProgressRing Ring
        {
            get { return _ring; }
            set
            {
                _ring = value;
            }
        }

        public static bool EnableRing
        {
            set
            {
                if(_ring != null)
                {
                    _ring.IsActive = value;
                }
            }
        }
    }
}
