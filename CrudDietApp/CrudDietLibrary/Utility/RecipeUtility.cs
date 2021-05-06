using CrudDietLibrary.Models;
using CrudDietLibrary.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDietLibrary.Utility
{
    public static class RecipeUtility
    {
        public static RecipeViewModel GetViewModel(this Recipe recipe)
        {
            var recipeViewModel = new RecipeViewModel()
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Method = recipe.Method,
                Ingredients = recipe.Ingredients,
                PictureUrl = recipe.PictureUrl,
                Type = recipe.Type
            };
            return recipeViewModel;
        }

        public static List<RecipeViewModel> GetViewModels(this List<Recipe> recipes)
        {
            var allRecipesViewModel = new List<RecipeViewModel>();
            foreach (var recipe in recipes)
            {
                allRecipesViewModel.Add(new RecipeViewModel()
                {
                    Id = recipe.Id,
                    Title = recipe.Title,
                    Method = recipe.Method,
                    Ingredients = recipe.Ingredients,
                    PictureUrl = recipe.PictureUrl,
                    Type = recipe.Type
                });
            }
            return allRecipesViewModel;
        }
    }
}
