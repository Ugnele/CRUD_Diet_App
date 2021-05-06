using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDietLibrary.Models.Binding
{
    public class AddUserBindingModel
    {
        public string Username { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string PictureUrl { get; set; }
    }
}
