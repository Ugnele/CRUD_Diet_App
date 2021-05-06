using CrudDietLibrary.Models;
using CrudDietLibrary.Models.Binding;
using DietWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDietAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly ApplicationDbContext databases;
        public RecipesController(ApplicationDbContext applicationDbContext)
        {
            databases = applicationDbContext;
        }

        [HttpGet("")]
        public IActionResult GetAllRecipes()
        {
            var recipes = databases.Recipes.ToList();
            return Ok(recipes);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetRecipeWithId(int id)
        {
            var recipeWithId = databases.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipeWithId == null) return NotFound();
            return Ok(recipeWithId);
        }

        [HttpPost("")]
        public IActionResult CreateRecipe([FromBody] AddRecipeBindingModel bm)
        {
            var newRecipe = new Recipe
            {
                Title = bm.Title,
                Method = bm.Method,
                Ingredients = bm.Ingredients,
                Type = bm.Type,
                PictureUrl = bm.PictureUrl,
            };
            var createdRecipe = databases.Recipes.Add(newRecipe).Entity;
            databases.SaveChanges();
            return Ok(createdRecipe);
        }
    }
}
