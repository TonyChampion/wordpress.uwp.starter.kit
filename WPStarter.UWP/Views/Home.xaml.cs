using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WPStarter.UWP.Utilities;
using WPStarter.UWP.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WPStarter.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public HomeViewModel ViewModel { get; set; }
        public Home()
        {
            this.InitializeComponent();
            ViewModel = new HomeViewModel();
        }

        private void lvCategories_ItemClick(object sender, ItemClickEventArgs e)
        {
            NavigationHelper.Navigate(typeof(Categories), e.ClickedItem);

        }

        private void lvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            NavigationHelper.Navigate(typeof(Posts), e.AddedItems.First());

        }

        private void lvPosts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(Post), e.AddedItems.First());
        }
    }
}
