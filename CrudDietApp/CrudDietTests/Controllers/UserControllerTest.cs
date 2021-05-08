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
    public class UserControllerTest
    {
        private Mock<IRepositoryWrapper> mockRepo;
        private UsersController userController;
        private AddUserBindingModel addUser; 
        public UserControllerTest()
        {
            //sample models
            addUser = new AddUserBindingModel { Username = "Anna Added", About = "Anna is nice.", Email = "anna@email.com", Password = "Password", Age = 20, PictureUrl = "" };

            //controller setup
            var userResultsMock = new Mock<IActionResult>();

            mockRepo = new Mock<IRepositoryWrapper>();
            var allUsers = GetUsers();
            userController = new UsersController(mockRepo.Object);
        }

        [Fact]
        public void CreateUser_Test()
        {
            mockRepo.Setup(repo => repo.Users.FindByCondition(c => c.Id == It.IsAny<int>())).Returns(GetUsers());
            var controllerActionResult = userController.CreateUser(addUser);
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void GetAllUsers_Test()
        {
            mockRepo.Setup(repo => repo.Users.FindAll()).Returns(GetUsers());
            var controllerActionResult = userController.Index();
            Assert.NotNull(controllerActionResult);
            Assert.IsType<ViewResult>(controllerActionResult);
        }

        [Fact]
        public void GetUser_Test()
        {
            mockRepo.Setup(repo => repo.Users.FindAll()).Returns(GetUsers());
            var controllerActionResult = userController.DetailsOfUser(It.IsAny<int>());
            Assert.NotNull(controllerActionResult);
            Assert.IsType<ViewResult>(controllerActionResult);
        }

        [Fact]
        public void UpdateUser_Test()
        {
            mockRepo.Setup(repo => repo.Users.FindByCondition(r => r.Id == It.IsAny<int>())).Returns(GetUsers());
            mockRepo.Setup(repo => repo.Users.Update(GetUser()));
            var controllerActionResult = userController.UpdateUser(It.IsAny<int>());
            Assert.NotNull(controllerActionResult);
            Assert.IsType<ViewResult>(controllerActionResult);

        }

        //[Fact]
        //public void DeleteUser_Test()
        //{
        //    mockRepo.Setup(repo => repo.Users.FindByCondition(r => r.Id == It.IsAny<int>())).Returns(GetUsers());
        //    mockRepo.Setup(repo => repo.Users.Delete(GetUser()));
        //    var controllerActionResult = userController.DeleteUser(It.IsAny<int>());
        //    //Assert.Throws<NoElementsException>((() => userController.DeleteUser(It.IsAny<int>())));
        //    //Assert.IsType<NotFoundResult>(controllerActionResult);
        //    //mockRepo.Setup(repo => repo.Users.FindByCondition(c => c.Id == It.IsAny<int>())).Returns(GetUsers());
        //    //Assert.Null(controllerActionResult);
        //}
        private IEnumerable<User> GetUsers()
        {
            var users = new List<User> {
            new User(){Id=1, Username = "Anna", About = "Anna is nice.", Email = "anna@email.com", Password = "Password", Age = 20, PictureUrl = "" },
            new User(){Id=2, Username = "Billy", About = "Billy is also nice.", Email = "billy@email.com", Password = "PasswordB", Age = 28, PictureUrl = "" }
            };
            return users;
        }
        private User GetUser()
        {
            return GetUsers().ToList()[0];
        }

    }
}
