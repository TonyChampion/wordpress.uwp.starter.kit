using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPStarter.UWP.Models
{
    public enum CategorySort
    {
        [Display(Name ="Count")]
        [DefaultValue(true)]
        count,
        [Display(Name = "Name")]
        name
    }

}
