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
using WordPressAPI.Models;
using WPStarter.UWP.Utilities;
using WPStarter.UWP.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WPStarter.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Posts : Page
    {
        public Posts()
        {
            this.InitializeComponent();
        }

        public PostsViewModel ViewModel { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is WordPressTerm)
            {
                ViewModel = new PostsViewModel(e.Parameter as WordPressTerm);
            } else
            {
                ViewModel = new PostsViewModel();
            }

            base.OnNavigatedTo(e);
        }

        private void lvPosts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationHelper.Navigate(typeof(Post), e.AddedItems.First());
        }
    }
}
