using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDietApp.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string About { get; set; }
        public string PictureUrl { get; set; }
        public virtual List<Recipe> UsersRecipes { get; set; }
    }
}
