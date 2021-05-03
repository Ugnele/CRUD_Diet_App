using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDietApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Method { get; set; }
        public string Ingredients { get; set; }
        public string PictureUrl { get; set; }
        public DietType Type { get; set; }
        public User CreatedBy { get; set; }

    }
}
