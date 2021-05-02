using CrudDietApp.Data;
using CrudDietApp.Models;
using CrudDietApp.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDietApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDatabases databases;

        public UsersController(AppDatabases appDatabases)
        {
            databases = appDatabases;
        }

        //shows existing users
        public IActionResult Index()
        {
            var users = databases.Users.ToList();
            return View(users);
        }

        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(AddUserBindingModel bm)
        {
            var newUser = new User
            {
                Username = bm.Username,
                Password = bm.Password,
                Email = bm.Email,
                Age = bm.Age,
                About = bm.About,
                PictureUrl = bm.PictureUrl
            };
            databases.Users.Add(newUser);
            databases.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("user/details/{id:int}")]
        public IActionResult DetailsOfUser(int id)
        {
            var userWithId = databases.Users.FirstOrDefault(u => u.Id == id);
            return View(userWithId);
        }


        [Route("user/update/{id:int}")]
        public IActionResult UpdateUser(int id)
        {
            var userWithId = databases.Users.FirstOrDefault(u => u.Id == id);
            return View(userWithId);
        }

        [HttpPost]
        [Route("user/update/{id:int}")]
        public IActionResult UpdateUser(User user, int id)
        {
            var updatedUser = databases.Users.FirstOrDefault(r => r.Id == id);
            updatedUser.Username = user.Username;
            updatedUser.Password = user.Password;
            updatedUser.Email = user.Email;
            updatedUser.Age = user.Age;
            updatedUser.About = user.About;
            updatedUser.PictureUrl = user.PictureUrl;
            databases.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("user/delete/{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var userToDelete = databases.Users.FirstOrDefault(u => u.Id == id);
            databases.Users.Remove(userToDelete);
            databases.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
