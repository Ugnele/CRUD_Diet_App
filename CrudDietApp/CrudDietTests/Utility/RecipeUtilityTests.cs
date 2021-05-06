using CrudDietLibrary.Models;
using CrudDietLibrary.Models.View;
using CrudDietLibrary.Utility;
using System;
using System.Collections.Generic;
using Xunit;

namespace CrudDietTests
{
    public class RecipeUtilityTest
    {
        [Fact]
        public void GetViewModel()
        {
            Recipe testRecipe = new Recipe()
            {
                Id = 1,
                Title = "Best Recipe",
                Method = "Cook",
                Ingredients = "Food items",
                PictureUrl = "",
                Type = DietType.Halal
            };

            var testRecipeViewModel = testRecipe.GetViewModel();
            Assert.IsType<RecipeViewModel>(testRecipeViewModel);
            Assert.NotNull(testRecipeViewModel);
            Assert.NotEmpty(testRecipeViewModel.Title);
            Assert.Empty(testRecipeViewModel.PictureUrl);
            Assert.Contains("Cook", testRecipeViewModel.Method);
            Assert.Equal(DietType.Halal, testRecipeViewModel.Type);
        }

        [Fact]
        public void GetViewModels()
        {
            List<Recipe> testRecipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Id = 1,
                    Title = "Meaty Recipe",
                    Method = "Grill",
                    Ingredients = "Animal items",
                    PictureUrl = "",
                    Type = DietType.Omnivore
                },
                new Recipe()
                {
                    Id = 2,
                    Title = "Planty Recipe",
                    Method = "Pan Fry",
                    Ingredients = "Grass items",
                    PictureUrl = "",
                    Type = DietType.Vegan
                },
                new Recipe()
                {
                    Id = 1,
                    Title = "Fishy Recipe",
                    Method = "Boil",
                    Ingredients = "Ocean animal items",
                    PictureUrl = "",
                    Type = DietType.Pescetarian
                }
            };

            var testRecipesViewModel = testRecipes.GetViewModels();
            Assert.NotEmpty(testRecipesViewModel);
            Assert.IsType<List<RecipeViewModel>>(testRecipesViewModel);
            Assert.True(testRecipesViewModel[0].Id == testRecipesViewModel[2].Id);
            Assert.False(testRecipesViewModel[0].Id == testRecipesViewModel[1].Id);
        }
    }
}
