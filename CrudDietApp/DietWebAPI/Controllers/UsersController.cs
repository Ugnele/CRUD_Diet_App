using CrudDietLibrary.Models;
using CrudDietLibrary.Models.Binding;
using CrudDietLibrary.Utility;
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
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext databases;
        public UsersController(ApplicationDbContext applicationDbContext)
        {
            databases = applicationDbContext;
        }

        [HttpGet("")]
        public IActionResult GetAllUsers()
        {
            var users = databases.Users.ToList();
            return Ok(users.GetViewModels());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUserWithId(int id)
        {
            var userWithId = databases.Users.FirstOrDefault(r => r.Id == id);
            if (userWithId == null) return NotFound();
            return Ok(userWithId.GetViewModel());
        }

        [HttpPost("")]
        public IActionResult CreateUser([FromBody] AddUserBindingModel bm)
        {
            var newUser = new User
            {
                Username = bm.Username,
                Password = bm.Password,
                Email = bm.Email,
                Age = bm.Age,
                About = bm.About,
                PictureUrl = bm.PictureUrl
            };
            var createdUser = databases.Users.Add(newUser).Entity;
            databases.SaveChanges();
            return Ok(createdUser.GetViewModel());
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateUser([FromBody] User user, int id)
        {
            var userWithId = databases.Users.FirstOrDefault(r => r.Id == id);
            if (userWithId == null) return NotFound();
            userWithId.Username = user.Username;
            userWithId.Password = user.Password;
            userWithId.Email = user.Email;
            userWithId.Age = user.Age;
            userWithId.About = user.About;
            userWithId.PictureUrl = user.PictureUrl;
            databases.SaveChanges();
            return Ok(userWithId.GetViewModel());
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var userToDelete = databases.Users.FirstOrDefault(r => r.Id == id);
            databases.Users.Remove(userToDelete);
            databases.SaveChanges();
            if (userToDelete == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
