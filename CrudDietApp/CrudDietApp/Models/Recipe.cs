using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDietApp.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Method { get; set; }
        public string PictureUrl { get; set; }
        public int Kcal { get; set; }
        public int Fat { get; set; }
        public int Saturated { get; set; }
        public int Carbohydrate { get; set; }
        public int Sugars { get; set; }
        public int Fibre { get; set; }
        public int Protein { get; set; }
        public int Salt { get; set; }


    }
}
