using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace WPStarter.UWP.Utilities
{
    public static class NavigationHelper
    {
        private static Frame _frame;

        public static Frame Frame
        {
            get { return _frame; }
            set
            {
                _frame = value;
                _frame.Navigated += _frame_Navigated;
            }
        }

        private static void _frame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            
        }

        public static void GoBack()
        {
            if(Frame != null && Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        public static void Navigate(Type destination)
        {
            Navigate(destination, null);
        }
        public static void Navigate(Type destination, object param )
        {
            if(Frame != null)
            {
                Frame.Navigate(destination, param);
            }
        }

    }
}
