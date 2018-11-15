using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressAPI.Models;
using WPStarter.UWP.Utilities;

namespace WPStarter.UWP.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private WordPressOptions _options;
        public MainPageViewModel()
        {
            UpdateData();
        }

        public async void UpdateData()
        {
            Options = await WordPressHelper.GetOptions();
        }

        public WordPressOptions Options
        {
            get { return _options; }
            private set { Set("Options", ref _options, value); }
        }

    }
}
