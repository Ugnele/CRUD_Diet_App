using CrudDietApp.Data;
using CrudDietLibrary.Models;
using CrudDietLibrary.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var users = databases.Users.Include(r=>r.Recipes).ToList();
            ViewBag.Users = users;
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
            var userWithId = databases.Users.Include(r=>r.Recipes).FirstOrDefault(u => u.Id == id);
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
            var userToBeUpdated = databases.Users.FirstOrDefault(u => u.Id == id);
            userToBeUpdated.Username = user.Username;
            userToBeUpdated.Password = user.Password;
            userToBeUpdated.Email = user.Email;
            userToBeUpdated.Age = user.Age;
            userToBeUpdated.About = user.About;
            userToBeUpdated.PictureUrl = user.PictureUrl;
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

        //___________________________________________________________________________
        //Recipe actions from user account

        [Route("createrecipe/{createdById:int}")]
        public IActionResult CreateRecipe(int createdById)
        {
            var user = databases.Users.FirstOrDefault(u => u.Id == createdById);
            ViewBag.Username = user.Username;
            return View();
        }
        [HttpPost]
        [Route("createrecipe/{createdById:int}")]
        public IActionResult CreateRecipe(AddRecipeBindingModel bm, int createdById)
        {
            bm.CreatedById = createdById;
            var newRecipe = new Recipe
            {
                Title = bm.Title,
                Method = bm.Method,
                Ingredients = bm.Ingredients,
                Type = bm.Type,
                PictureUrl = bm.PictureUrl,
                CreatedBy = databases.Users.FirstOrDefault(u => u.Id == createdById)
            };
            databases.Recipes.Add(newRecipe);
            databases.SaveChanges();
            //databases.Users.FirstOrDefault(u => u.Id == createdById).Recipes.Add(newRecipe);
            //databases.SaveChanges();
            return RedirectToAction("Index");
        }

        //Display All users recipes
        [Route("recipes/{id:int}")]
        public IActionResult ViewRecipes(int id)
        {
            var user = databases.Users.FirstOrDefault(u => u.Id == id);
            var recipes = databases.Recipes.Include(u=>u.CreatedBy).Where(r => r.CreatedBy.Id == id).ToList();
            ViewBag.Username = user.Username;
            return View(recipes);
        }

        //Authentication
        public Boolean Login(int id, string username, string password)
        {
            var user = databases.Users.FirstOrDefault(u => u.Id == id);
            return user.Username == username && user.Password == password;
        }
    }
}
