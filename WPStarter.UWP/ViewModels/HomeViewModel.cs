using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressAPI.Models;
using WordPressAPI;
using GalaSoft.MvvmLight;
using Windows.UI.Xaml.Controls;
using WPStarter.UWP.Utilities;

namespace WPStarter.UWP.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private IEnumerable<WordPressPost> _posts;
        private IEnumerable<WordPressTerm> _categories;
        private WordPressOptions _options;
        public HomeViewModel()
        {
            UpdateData();
        }

        public async void UpdateData()
        {
            ProgressHelper.EnableRing = true;

            Options = await WordPressHelper.GetOptions();
            Posts = await WordPressHelper.Client.GetPostsAsync(new WordPressPostFilter() { Size = 10, Order = WordPressOrder.desc, OrderBy = WordPressPostOrderBy.modified });
            Categories = await WordPressHelper.Client.GetTermsAsync("category", new WordPressTermFilter() { Order = WordPressOrder.desc, OrderBy = WordPressTermOrderBy.count });

            ProgressHelper.EnableRing = false;
        }

        public IEnumerable<WordPressPost> Posts
        {
            get { return _posts; }
            private set { Set("Posts", ref _posts, value); }
        }

        public IEnumerable<WordPressTerm> Categories
        {
            get { return _categories; }
            private set { Set("Categories", ref _categories, value); }
        }

        public WordPressOptions Options
        {
            get { return _options; }
            private set { Set("Options", ref _options, value); }
        }

    }
}
