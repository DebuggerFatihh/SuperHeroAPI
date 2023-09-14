using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.UserService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleUser(int id)
        {
            var user = await _userService.GetSingleUser(id);
            if (user is null)
                return NotFound("Kullanıcı Bulunamadı.");
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var addedUser = await _userService.AddUser(user);
            return Ok(addedUser);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User request)
        {
            var updatedUser = await _userService.UpdateUser(id, request);
            if (updatedUser is null)
                return NotFound("Kullanıcı Bulunamadı.");
            return Ok(updatedUser);
        }
        [HttpGet("user")]
        public async Task<ActionResult<User>> GetUserByUsernameAndPassword(string username, string password)
        {

            var result = await _userService.GetUserByUsernameAndPassword(username, password);
            if (result == null) return NotFound("İlgili kullanıcı bulunamadı");
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteUser(id);
            if (!deleted)
                return NotFound("Kullanıcı Bulunamadı.");
            return Ok(true);
        }
    }
}