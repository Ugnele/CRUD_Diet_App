﻿using CrudDietApp.Data;
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

        [Route("details/{id:int}")]
        public IActionResult DetailsOfRecipe(int id)
        {
            var recipeWithId = databases.Recipes.FirstOrDefault(r => r.Id == id);
            return View(recipeWithId);
        }


        [Route("update/{id:int}")]
        public IActionResult UpdateRecipe(int id)
        {
            var recipeWithId = databases.Recipes.FirstOrDefault(r => r.Id == id);
            return View(recipeWithId);
        }

        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult UpdateRecipe(Recipe recipe, int id)
        {
            var updatedRecipe = databases.Recipes.FirstOrDefault(r => r.Id == id);
            updatedRecipe.Title = recipe.Title;
            updatedRecipe.Ingredients = recipe.Ingredients;
            updatedRecipe.Method = recipe.Method;
            updatedRecipe.PictureUrl = recipe.PictureUrl;
            updatedRecipe.Type = recipe.Type;
            databases.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("delete/{id:int}")]
        public IActionResult DeleteRecipe(int id)
        {
            var recipeToDelete = databases.Recipes.FirstOrDefault(r => r.Id == id);
            databases.Recipes.Remove(recipeToDelete);
            databases.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
