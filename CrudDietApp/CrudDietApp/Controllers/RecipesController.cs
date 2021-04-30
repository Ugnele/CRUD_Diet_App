using CrudDietApp.Data;
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
    }
}
