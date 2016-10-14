using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using WordPressAPI;
using WordPressAPI.Helpers;
using WordPressAPI.Models;
using WPStarter.UWP.Models;
using WPStarter.UWP.Utilities;

namespace WPStarter.UWP.ViewModels
{
    public class CategoriesViewModel : ViewModelBase
    {
        private IEnumerable<WordPressTerm> _categories;
        private CategorySort _currentSort;

        public CategoriesViewModel()
        {
            UpdateData();
        }

        public async void UpdateData()
        {
            ProgressHelper.EnableRing = true;

            Categories = await WordPressHelper.Client.GetTermsAsync("category", new WordPressTermFilter() { Order = WordPressOrder.desc, OrderBy = WordPressTermOrderBy.count, Size = 1000 });
            InitSort();

            ProgressHelper.EnableRing = false;

        }

        private void InitSort()
        {
            var fieldInfo = typeof(CategorySort).GetRuntimeFields().FirstOrDefault(x => x.GetCustomAttribute<DefaultValueAttribute>() != null);

            if (fieldInfo != null)
            {
                CurrentSort = (CategorySort)Enum.Parse(typeof(CategorySort), fieldInfo.Name);
            }
        }
        public IEnumerable<WordPressTerm> Categories
        {
            get { return _categories; }
            private set {
                Set("Categories", ref _categories, value);
                RaisePropertyChanged("SortedCategoies");
               
            }
        }

        public object CurrentSort
        {
            get { return _currentSort; }
            set
            {
                Set("CurrentSort", ref _currentSort, (CategorySort)value);
                RaisePropertyChanged("SortedCategories");
            }
        }

        public PostViewModel Test { get; set; }
        public Array Sorts
        {
            get
            {
                var ret = Enum.GetValues(typeof(CategorySort));
                return ret;
            }
        }
        public IEnumerable<WordPressTerm> SortedCategories
        {
            get {
                return _currentSort == CategorySort.count ? _categories :
                                  _categories.OrderBy(c => c.Name);
            }
        }

        public void SortChanged(object sender, SelectionChangedEventArgs e)
        {
            var itm = e.AddedItems[0] as ComboBoxItem;

            //_isCountSort = (string)itm.Content == "Count";
            RaisePropertyChanged("SortedCategories");
        }
    }
}
