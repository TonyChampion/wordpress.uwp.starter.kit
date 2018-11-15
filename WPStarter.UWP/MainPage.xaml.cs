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
using WPStarter.UWP.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WPStarter.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            

            ProgressHelper.Ring = prMain;
            NavigationHelper.Frame = ContentFrame;
            ContentFrame.Navigated += ContentFrame_Navigated;
            NavigationHelper.Navigate(typeof(Home));
            navView.BackRequested += NavView_BackRequested;

            ViewModel = new MainPageViewModel();
        }

        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            ContentFrame.GoBack();
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            navView.IsBackEnabled = ContentFrame.CanGoBack;
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            switch (args.InvokedItem) {
                case "Home":
                    ContentFrame.Navigate(typeof(Home));
                    break;
                case "Posts":
                    ContentFrame.Navigate(typeof(Posts));
                    break;
                case "Categories":
                    ContentFrame.Navigate(typeof(Categories));
                    break;
            }

        }
    }
}
