using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDietLibrary.Models.View
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Method { get; set; }
        public string Ingredients { get; set; }
        public string PictureUrl { get; set; }
        public DietType Type { get; set; }
    }
}
