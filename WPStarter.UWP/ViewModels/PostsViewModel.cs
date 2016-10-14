using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressAPI;
using WordPressAPI.Helpers;
using WordPressAPI.Models;
using WPStarter.UWP.Utilities;

namespace WPStarter.UWP.ViewModels
{
    public class PostsViewModel : ViewModelBase
    {
        private IEnumerable<WordPressPost> _posts;
        private WordPressTerm _term;
        private string _title = "Posts";

        public PostsViewModel()
        {
            UpdateData();
        }

        public PostsViewModel(WordPressTerm term)
        {
            _term = term;
            Title = "Posts for Category: " + term.Name;

            UpdateData();
        }

        public async void UpdateData()
        {
            ProgressHelper.EnableRing = true;

            var fields = new List<WordPressField>();
            fields.Add(WordPressPostHelper.GetField("Id"));
            fields.Add(WordPressPostHelper.GetField("Title"));
            fields.Add(WordPressPostHelper.GetField("Excerpt"));
            fields.Add(WordPressPostHelper.GetField("PostModified"));

            var posts = await WordPressHelper.Client.GetPostsAsync(new WordPressPostFilter() { Order = WordPressOrder.desc, OrderBy = WordPressPostOrderBy.modified, Size = 1000 }, fields);

            if(posts != null )
            {
                Posts = posts.Where(p => p.Terms.Count(t => (t.Taxonomy == "category" && t.Name == _term.Name)) > 0);
            } else
            {
                Posts = posts;
            }

            ProgressHelper.EnableRing = false;
        }

        public IEnumerable<WordPressPost> Posts
        {
            get { return _posts; }
            private set { Set("Posts", ref _posts, value); }
        }

        public string Title
        {
            get { return _title; }
            private set { Set("Title", ref _title, value); }
        }

    }
}
