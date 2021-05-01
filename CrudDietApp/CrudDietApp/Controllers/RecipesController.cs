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
    public class RecipesController : Controller
    {
        private readonly AppDatabases databases;

        public RecipesController(AppDatabases appDatabases)
        {
            databases = appDatabases;
        }
        
        //shows existing recipes
        public IActionResult Index()
        {
            var recipes = databases.Recipes.ToList();
            return View(recipes);
        }

        public IActionResult CreateRecipe()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateRecipe(AddRecipeBindingModel bm)
        {
            var newRecipe = new Recipe
            {
                Title = bm.Title,
                Method = bm.Method,
                Ingredients = bm.Ingredients,
                Type = bm.Type,
                PictureUrl = bm.PictureUrl
            };
            databases.Recipes.Add(newRecipe);
            databases.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
