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
    public class RecipesController : Controller
    {
        //private readonly ApplicationDbContext databases;
        private readonly IRepositoryWrapper repo;

        public RecipesController(IRepositoryWrapper repoWrapper)//ApplicationDbContext appDatabases
        {
            //databases = appDatabases;
            repo = repoWrapper;
        }

        //shows existing recipes
        public IActionResult Index()
        {
            var recipes = repo.Recipes.FindAll();
            //var recipes = databases.Recipes.ToList();
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
                PictureUrl = bm.PictureUrl,
                //CreatedById = bm.CreatedById,
            };
            repo.Recipes.Create(newRecipe);
            repo.Save();
            //databases.Recipes.Add(newRecipe);
            //databases.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("recipes/details/{id:int}")]
        public IActionResult DetailsOfRecipe(int id)
        {
            var recipeWithId = repo.Recipes.FindByCondition(r => r.Id == id).FirstOrDefault();
            //var recipeWithId = databases.Recipes.Include(u => u.CreatedBy).FirstOrDefault(r => r.Id == id);
            return View(recipeWithId);
        }


        [Route("update/{id:int}")]
        public IActionResult UpdateRecipe(int id)
        {
            var recipeWithId = repo.Recipes.FindByCondition(r => r.Id == id).FirstOrDefault();
            //var recipeWithId = databases.Recipes.FirstOrDefault(r => r.Id == id);
            return View(recipeWithId);
        }

        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult UpdateRecipe(Recipe recipe, int id)
        {
            var recipeToUpdate = repo.Recipes.FindByCondition(r => r.Id == id).First();
            //var updatedRecipe = databases.Recipes.FirstOrDefault(r => r.Id == id);
            recipeToUpdate.Title = recipe.Title;
            recipeToUpdate.Ingredients = recipe.Ingredients;
            recipeToUpdate.Method = recipe.Method;
            recipeToUpdate.PictureUrl = recipe.PictureUrl;
            recipeToUpdate.Type = recipe.Type;
            repo.Save();
            //databases.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("delete/{id:int}")]
        public IActionResult DeleteRecipe(int id)
        {
            var recipeToDelete = repo.Recipes.FindByCondition(r => r.Id == id).First();
            repo.Recipes.Delete(recipeToDelete);
            repo.Save();
            //var recipeToDelete = databases.Recipes.FirstOrDefault(r => r.Id == id);
            //databases.Recipes.Remove(recipeToDelete);
            //databases.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
