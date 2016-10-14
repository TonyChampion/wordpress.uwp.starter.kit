using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressAPI;
using WordPressAPI.Models;

namespace WPStarter.UWP.Utilities
{
    public static class WordPressHelper
    {
        private static WordPressClient _client;
        
        public static WordPressClient Client
        {
            get
            {
                if(_client == null)
                {
                    var blogUri = (string)App.Current.Resources["blogUri"];
                    var blogUser = (string)App.Current.Resources["blogUser"];
                    var blogPwd = (string)App.Current.Resources["blogPwd"];
                    var blogId = (int)App.Current.Resources["blogId"];

                    _client = new WordPressClient(blogUri, blogUser, blogPwd, blogId);
                }
                return _client;
            }
        }

        private static WordPressOptions _options;

        public static async Task<WordPressOptions> GetOptions()
        {
            if(_options == null)
            {
                _options = await Client.GetOptionsAsync();
                
            }

            return _options;
        }
    }
}
