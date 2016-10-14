using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressAPI;
using WordPressAPI.Models;
using WPStarter.UWP.Utilities;

namespace WPStarter.UWP.ViewModels
{
    public class PostViewModel : ViewModelBase
    {
        private WordPressPost _post;
        private string _htmlContent;
        public PostViewModel(WordPressPost post)
        {
            UpdateData(post);
        }

        public async void UpdateData(WordPressPost post)
        {
            Post = await WordPressHelper.Client.GetPostAsync(Int32.Parse(post.Id));
            GenerateHtmlContent();
        }

        private async void GenerateHtmlContent()
        {
            var ret = "";

            if (_post != null && _post.Content != null)
            {
                var options = await WordPressHelper.GetOptions();
                var cssUrl = String.Format("{0}/wp-content/themes/{1}/style.css", options.BlogUrl.Value, options.Stylesheet.Value);
             //   options.BlogUrl.Value + "/wp-content/themes/" + options.Stylesheet.Value + "/style.css";
                ret = $@"<html>
                              <body>
                                <link rel='stylesheet' type='text/css' href='{cssUrl}'/>                                {_post.Content}                              </body>                            </html>";
            }

            HtmlContent = ret;
        }
        public WordPressPost Post
        {
            get { return _post; }
            private set { Set("Post", ref _post, value); }
        }

        public string HtmlContent
        {
            get { return _htmlContent; }
            private set
            {
                Set("HtmlContent", ref _htmlContent, value);
            }
        }
    }
}
