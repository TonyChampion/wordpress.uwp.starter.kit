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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WPStarter.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainPageViewModel _viewModel;

        public MainPage()
        {
            this.InitializeComponent();

            _viewModel = new MainPageViewModel();
            DataContext = _viewModel;

            ProgressHelper.Ring = prMain;

            NavigationHelper.Frame = frContent;

            NavigationHelper.Navigate(_viewModel.Menu.First().NavigationDestination);

        }

        private void lvNav_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationHelper.Navigate((e.AddedItems[0] as MenuItem).NavigationDestination);
        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            svMain.IsPaneOpen = !svMain.IsPaneOpen;

        }
    }
}
