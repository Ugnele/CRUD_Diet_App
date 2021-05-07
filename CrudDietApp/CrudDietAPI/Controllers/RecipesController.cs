using CrudDietLibrary.Data;
using CrudDietLibrary.Models;
using CrudDietLibrary.Models.Binding;
using CrudDietLibrary.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudDietLibrary.Interfaces;

namespace CrudDietAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        //private readonly IRepositoryWrapper repo;

        private readonly ApplicationDbContext databases;
        public RecipesController(ApplicationDbContext applicationDbContext)//IRepositoryWrapper repoWrapper
        {
            databases = applicationDbContext;
            //repo = repoWrapper;
        }

        [HttpGet("")]
        public IActionResult GetAllRecipes()
        {
            //var recipes = repo.Recipes.FindAll();
            var recipes = databases.Recipes.ToList();
            return Ok(recipes.GetViewModels());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetRecipeWithId(int id)
        {
            //var recipeWithId = repo.Recipes.FindByCondition(r => r.Id == id);
            var recipeWithId = databases.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipeWithId == null) return NotFound();
            return Ok(recipeWithId.GetViewModel());
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
            //var createdRecipe = repo.Recipes.Create(newRecipe);
            //repo.Save();
            var createdRecipe = databases.Recipes.Add(newRecipe).Entity;
            databases.SaveChanges();
            return Ok(createdRecipe.GetViewModel());
        }

        [HttpPost("user")]
        public IActionResult CreateUserRecipe([FromBody] AddRecipeBindingModel bm)
        {
            var newRecipe = new Recipe
            {
                Title = bm.Title,
                Method = bm.Method,
                Ingredients = bm.Ingredients,
                Type = bm.Type,
                PictureUrl = bm.PictureUrl,
                //CreatedBy = repo.Users.FindByCondition(u => u.Id == bm.CreatedById)
                CreatedBy = databases.Users.FirstOrDefault(u => u.Id == bm.CreatedById),
            };
            //var createdRecipe = repo.Recipes.Create(newRecipe);
            //repo.Save();
            var createdRecipe = databases.Recipes.Add(newRecipe).Entity;
            databases.SaveChanges();
            return Ok(createdRecipe.GetViewModel());
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateRecipe([FromBody] Recipe recipe, int id)
        {
            //var recipeWithId = repo.Recipes.FindByCondition(r => r.Id == id);
            var recipeWithId = databases.Recipes.FirstOrDefault(r => r.Id == id);
            if (recipeWithId == null) return NotFound();
            recipeWithId.Title = recipe.Title;
            recipeWithId.Ingredients = recipe.Ingredients;
            recipeWithId.Method = recipe.Method;
            recipeWithId.PictureUrl = recipe.PictureUrl;
            recipeWithId.Type = recipe.Type;
            //repo.Save();
            databases.SaveChanges();
            return Ok(recipeWithId.GetViewModel());
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteRecipe(int id)
        {
            //var recipeToDelete = repo.Recipes.FindByCondition(r => r.Id == id);
            //repo.Recipes.Delete(recipeToDelete);
            //repo.Save();
            var recipeToDelete = databases.Recipes.FirstOrDefault(r => r.Id == id);
            databases.Recipes.Remove(recipeToDelete);
            databases.SaveChanges();
            if (recipeToDelete == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
