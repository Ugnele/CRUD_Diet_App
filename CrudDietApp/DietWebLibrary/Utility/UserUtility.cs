using CrudDietLibrary.Models;
using CrudDietLibrary.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDietLibrary.Utility
{
    public static class UserUtility
    {
        public static UserViewModel GetViewModel(this User user)
        {
            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Age = user.Age,
                About = user.About,
                PictureUrl = user.PictureUrl
            };
            return userViewModel;
        }

        public static List<UserViewModel> GetViewModels(this List<User> users)
        {
            var allUsersViewModel = new List<UserViewModel>();
            foreach (var user in users)
            {
                allUsersViewModel.Add(new UserViewModel()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    Age = user.Age,
                    About = user.About,
                    PictureUrl = user.PictureUrl
                });
            }
            return allUsersViewModel;
        }
    }
}
