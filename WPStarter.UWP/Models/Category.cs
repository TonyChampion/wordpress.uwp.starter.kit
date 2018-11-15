using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressAPI.Models;

namespace WPStarter.UWP.Models
{
    public class Category : WordPressTerm
    {
        public static Category FromWordPressTerm(WordPressTerm term, int maxCount)
        {
            return new Category()
            {
                Id = term.Id,
                Name = term.Name,
                Count = term.Count,
                Description = term.Description,
                Parent = term.Parent,
                Taxonomy = term.Taxonomy,
                Slug = term.Slug,
                TermGroup = term.TermGroup,
                TermTaxonomyId = term.TermTaxonomyId,
                MaxCount = maxCount
            };
        }

        public int MaxCount { get; set; }
    }
}
