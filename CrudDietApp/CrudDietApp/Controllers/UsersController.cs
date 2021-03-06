using CrudDietLibrary.Data;
using CrudDietLibrary.Interfaces;
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
        //private readonly ApplicationDbContext databases;
        private readonly IRepositoryWrapper repo;

        public UsersController(IRepositoryWrapper repoWrapper)//ApplicationDbContext appDatabases
        {
            //databases = appDatabases;
            repo = repoWrapper;
        }

        //shows existing users
        public IActionResult Index()
        {
            var users = repo.Users.FindAll(r => r.Recipes);//
            //var users = databases.Users.Include(r=>r.Recipes).ToList();
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
            repo.Users.Create(newUser);
            repo.Save();
            //databases.Users.Add(newUser);
            //databases.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("user/details/{id:int}")]
        public IActionResult DetailsOfUser(int id)
        {
            var userWithId = repo.Users.FindByCondition(r => r.Id == id, r => r.Recipes).FirstOrDefault();
            //var userWithId = databases.Users.Include(r=>r.Recipes).FirstOrDefault(u => u.Id == id);
            return View(userWithId);
        }


        [Route("user/update/{id:int}")]
        public IActionResult UpdateUser(int id)
        {
            var userWithId = repo.Users.FindByCondition(r => r.Id == id).FirstOrDefault();
            //var userWithId = databases.Users.FirstOrDefault(u => u.Id == id);
            return View(userWithId);
        }

        [HttpPost]
        [Route("user/update/{id:int}")]
        public IActionResult UpdateUser(User user, int id)
        {
            var userToUpdate = repo.Users.FindByCondition(r => r.Id == id).First();
            //var userToUpdate = databases.Users.FirstOrDefault(u => u.Id == id);
            userToUpdate.Username = user.Username;
            userToUpdate.Password = user.Password;
            userToUpdate.Email = user.Email;
            userToUpdate.Age = user.Age;
            userToUpdate.About = user.About;
            userToUpdate.PictureUrl = user.PictureUrl;
            repo.Save();
            //databases.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("user/delete/{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var userToDelete = repo.Users.FindByCondition(r => r.Id == id).First();
            repo.Users.Delete(userToDelete);
            repo.Save(); 
            //var userToDelete = databases.Users.FirstOrDefault(u => u.Id == id);
            //databases.Users.Remove(userToDelete);
            //databases.SaveChanges();
            return RedirectToAction("Index");
        }

        //___________________________________________________________________________
        //Recipe actions from user account

        [Route("createrecipe/{createdById:int}")]
        public IActionResult CreateRecipe(int createdById)
        {
            var user = repo.Users.FindByCondition(r => r.Id == createdById).First();
            //var user = databases.Users.FirstOrDefault(u => u.Id == createdById);
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
                CreatedBy = repo.Users.FindByCondition(u => u.Id == createdById).FirstOrDefault()
                //CreatedBy = databases.Users.FirstOrDefault(u => u.Id == createdById)
            };
            repo.Recipes.Create(newRecipe);
            repo.Save();
            //databases.Recipes.Add(newRecipe);
            //databases.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
