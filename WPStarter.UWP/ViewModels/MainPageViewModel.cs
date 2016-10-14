using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPStarter.UWP.Views;

namespace WPStarter.UWP.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<MenuItem> _menu;

        public MainPageViewModel()
        {
            _menu = new ObservableCollection<MenuItem>();

            Menu.Add(new MenuItem() { Glyph = ((char)0xE80F).ToString(), Text = "Home", NavigationDestination = typeof(Home) });
            Menu.Add(new MenuItem() { Glyph = ((char)0xE7C3).ToString(), Text = "Posts", NavigationDestination = typeof(Posts) });
            Menu.Add(new MenuItem() { Glyph = ((char)0xE8F1).ToString(), Text = "Categories", NavigationDestination = typeof(Categories) });

        }
        public ObservableCollection<MenuItem> Menu
        {

            get { return _menu; }
        }
    }
}
