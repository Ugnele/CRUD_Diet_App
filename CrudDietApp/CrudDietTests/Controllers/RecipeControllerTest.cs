using CrudDietApp.Controllers;
using CrudDietLibrary.Interfaces;
using CrudDietLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CrudDietTests
{
    public class RecipeControllerTest
    {
        private Mock<IRepositoryWrapper> mockRepo;
        private RecipesController recipesController;
        //private CreateRecipe createRecipe;
        //private UpdateRecipe updateRecipe;
        private Recipe recipe;
        private List<Recipe> recipes;
        private Mock<IRecipe> recipeMock;
        private List<IRecipe> recipesMock;
        //private Mock<IAddRecipe> addRecipeMock;
        //private Mock<IUpdateRecipe> updateRecipeMock;
        //private Mock<IRecipeViewModel> RecipeViewModelMock;
        //private List<IRecipeViewModel> RecipesViewModelMock;
        public RecipeControllerTest()
        {
            //mock setup
            recipeMock = new Mock<IRecipe>();
            recipesMock = new List<IRecipe> { recipeMock.Object };

            recipe = new Recipe();
            recipes = new List<Recipe>();

            //controller set up
            var recipeResultsMock = new Mock<IActionResult>();
        }
        //        addRecipeMock = new Mock<IAddRecipe>();
        //        updateRecipeMock = new Mock<IUpdateRecipe>();
        //        
        //        //viewmodels mock setup
        //        RecipeViewModelMock = new Mock<IRecipeViewModel>();
        //        RecipesViewModelMock = new List<IRecipeViewModel>();

        //        //sample models
        //        addRecipe = new AddRecipe { Code = "CS101", Title = "Computing Basics" };
        //        updateRecipe = new UpdateRecipe { Code = "CS101", Title = "Understanding Computing Basics" };

        //        CONTROLLER SETUP//controller setup
        //         recipeControllerMock = new Mock<IRecipesController>();
        //        _logger = new Mock<ILogger<RecipeController>>();

        //        mockRepo = new Mock<IRepositoryWrapper>();
        //        var allRecipes = GetRecipes();
        //        RecipeController = new RecipeController(_logger.Object, mockRepo.Object);
        //    }
        [Fact]
        public void GetAllRecipes_Test()
        {
            mockRepo.Setup(repo => repo.Recipes.FindAll()).Returns(GetRecipes());
            var controllerActionResult = recipesController.Index();
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void AddRecipe_Test()
        {
            mockRepo.Setup(repo => repo.Recipes.FindByCondition(r => r.Id == It.IsAny<int>())).Returns(GetRecipes());
            //var controllerActionResult = RecipesController.Post(addRecipe);
            //Assert.NotNull(controllerActionResult);
            //Assert.IsType<ActionResult<RecipeViewModel>>(controllerActionResult);
        }
        [Fact]
        public void DeleteRecipe_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Recipes.FindByCondition(r => r.Id == It.IsAny<int>())).Returns(GetRecipes());
            //mockRepo.Setup(repo => repo.Recipes.Delete(GetRecipe()));
            ////Act
            //var controllerActionResult = RecipesController.Delete(It.IsAny<int>());
            ////Assert
            //Assert.NotNull(controllerActionResult);
        }
        private IEnumerable<Recipe> GetRecipes()
        {
            var recipes = new List<Recipe> {
                new Recipe(){Id=1, Title="recipe1", Method="Cook", Ingredients = "Food", PictureUrl = "", Type = DietType.Vegan},
                new Recipe(){Id=2, Title="recipe2", Method="Bake", Ingredients = "Vegs", PictureUrl = "", Type = DietType.Vegetarian}
                };
            return recipes;
        }
        //private Recipe GetRecipe()
        //{
        //    return GetRecipes().ToList()[0];
        //}
        //}
        /// <summary>
        /// /////////////////////
        /// </summary>
        [Fact]
        public void Index()
        {
        }

        [Fact]
        public void DetailsOfRecipe()
        {
        }

        [Fact]
        public void UpdateRecipe()
        {
        }
        [Fact]
        public void DeleteRecipe()
        {
        }
    }
}
