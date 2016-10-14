using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPStarter.UWP.ViewModels
{
    public class MenuItem : ViewModelBase
    {
        private string glyph;
        private string text;
        private RelayCommand command;
        private Type navigationDestination;

        public string Glyph
        {
            get { return glyph; }
            set
            {
                Set("Glyph", ref glyph, value);
            }
        }

        public string Text
        {
            get { return text; }
            set { Set("Texct", ref text, value); }
        }

        public RelayCommand Command
        {
            get { return command; }
            set { Set("Command", ref command, value); }
        }

        public Type NavigationDestination
        {
            get { return navigationDestination; }
            set { Set("NavigationDestination", ref navigationDestination, value); }
        }

        public bool IsNavigation
        {
            get { return navigationDestination != null; }
        }
    }
}
