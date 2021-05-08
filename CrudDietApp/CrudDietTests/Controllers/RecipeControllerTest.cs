using CrudDietApp.Controllers;
using CrudDietLibrary.Interfaces;
using CrudDietLibrary.Models;
using CrudDietLibrary.Models.Binding;
using CrudDietLibrary.Models.View;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Spring.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CrudDietTests
{
    public class RecipeControllerTest
    {
        private Mock<IRepositoryWrapper> mockRepo;
        private RecipesController recipeController;
        private AddRecipeBindingModel addRecipe;

        public RecipeControllerTest()
        {
            //sample models
            addRecipe = new AddRecipeBindingModel { Title = "Recipe Added", Method = "Cook", Ingredients = "Food", Type = DietType.Vegan, PictureUrl = "" };

            //controller setup
            mockRepo = new Mock<IRepositoryWrapper>();
            recipeController = new RecipesController(mockRepo.Object);
        }

        [Fact]
        public void CreateRecipe_Test()
        {
            mockRepo.Setup(repo => repo.Recipes.FindByCondition(c => c.Id == It.IsAny<int>())).Returns(GetRecipes());
            var controllerActionResult = recipeController.CreateRecipe(addRecipe);
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void GetAllRecipes_Test()
        {
            mockRepo.Setup(repo => repo.Recipes.FindAll()).Returns(GetRecipes());
            var controllerActionResult = recipeController.Index();
            Assert.NotNull(controllerActionResult);
            Assert.IsType<ViewResult>(controllerActionResult);
        }

        [Fact]
        public void GetRecipe_Test()
        {
            mockRepo.Setup(repo => repo.Recipes.FindAll()).Returns(GetRecipes());
            var controllerActionResult = recipeController.DetailsOfRecipe(It.IsAny<int>());
            Assert.NotNull(controllerActionResult);
            Assert.IsType<ViewResult>(controllerActionResult);
        }

        [Fact]
        public void UpdateRecipe_Test()
        {
            mockRepo.Setup(repo => repo.Recipes.FindByCondition(r => r.Id == It.IsAny<int>())).Returns(GetRecipes());
            mockRepo.Setup(repo => repo.Recipes.Update(GetRecipe()));
            var controllerActionResult = recipeController.UpdateRecipe(It.IsAny<int>());
            Assert.NotNull(controllerActionResult);
            Assert.IsType<ViewResult>(controllerActionResult);

        }

        [Fact]
        //public void DeleteRecipe_Test()
        //{
        //    mockRepo.Setup(repo => repo.Recipes.FindByCondition(r => r.Id == It.IsAny<int>())).Returns(GetRecipes());
        //    mockRepo.Setup(repo => repo.Recipes.Delete(GetRecipe()));
        //    //var controllerActionResult = recipeController.DeleteRecipe(It.IsAny<int>());
        //    Assert.Throws<NoElementsException>((() => recipeController.DeleteRecipe(It.IsAny<int>())));
        //    //Assert.IsType<NotFoundResult>(controllerActionResult);
        //    //mockRepo.Setup(repo => repo.Recipes.FindByCondition(c => c.Id == It.IsAny<int>())).Returns(GetRecipes());
        //    //Assert.NotNull(controllerActionResult);
        //}
        private IEnumerable<Recipe> GetRecipes()
        {
            var recipes = new List<Recipe> {
            new Recipe(){Id=1, Title = "Recipe", Method = "Cook", Ingredients = "Food", Type = DietType.Vegan, PictureUrl = ""},
            new Recipe(){Id=2, Title = "Another recipe", Method = "Bake", Ingredients = "More food", Type = DietType.Vegetarian, PictureUrl = "" }
            };
            return recipes;
        }
        private Recipe GetRecipe()
        {
            return GetRecipes().ToList()[0];
        }

    }
}
