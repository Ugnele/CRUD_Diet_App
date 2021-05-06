using CrudDietLibrary.Models;
using CrudDietLibrary.Models.View;
using CrudDietLibrary.Utility;
using System;
using System.Collections.Generic;
using Xunit;

namespace CrudDietTests
{
    public class UserUtilityTest
    {
        [Fact]
        public void GetViewModel()
        {
            User testUser = new User()
            {
                Id = 1,
                Username = "Anna",
                Password = "Password",
                Email = "anna@gmail.com",
                Age = 22,
                About = "I am Anna",
                PictureUrl = ""
            };

            var testUserViewModel = testUser.GetViewModel();
            Assert.IsType<UserViewModel>(testUserViewModel);
            Assert.NotNull(testUserViewModel);
            Assert.NotEmpty(testUserViewModel.Username);
            Assert.Empty(testUserViewModel.PictureUrl);
            Assert.Contains("@", testUserViewModel.Email);
        }

        [Fact]
        public void GetViewModels()
        {
            List<User> testUsers = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Username = "Anna",
                    Password = "Password",
                    Email = "anna@gmail.com",
                    Age = 22,
                    About = "I am Anna",
                    PictureUrl = ""
                },
                new User()
                {
                    Id = 2,
                    Username = "Billy",
                    Password = "Password2",
                    Email = "Billy@gmail.com",
                    Age = 5,
                    About = "I am Billy",
                    PictureUrl = ""
                },
                new User()
                {
                    Id = 3,
                    Username = "Cindy",
                    Password = "Password3",
                    Email = "cindy@gmail.com",
                    Age = 23,
                    About = "I am Cindy",
                    PictureUrl = ""
                }
            };

            var testUsersViewModel = testUsers.GetViewModels();
            Assert.NotEmpty(testUsersViewModel);
            Assert.IsType<List<UserViewModel>>(testUsersViewModel);
            Assert.False(testUsersViewModel[0].Id == testUsersViewModel[1].Id);
        }
    }
}
