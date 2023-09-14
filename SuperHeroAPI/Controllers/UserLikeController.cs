using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services.UserLikeService;
using SuperHeroAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLikeController : ControllerBase
    {
        private readonly IUserLikeService _userLikeService;

        public UserLikeController(IUserLikeService userLikeService)
        {
            _userLikeService = userLikeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserLike>>> GetAllUserLikes()
        {
            return await _userLikeService.GetAllUserLikes();
        }
        [HttpGet("GetLikeByUser")]
        public async Task<ActionResult<List<UserLike>>> GetLikeByUser()
        {
            var result = await _userLikeService.GetLikeByUser();

            return result;
        }   

        [HttpGet("{id}")]
        public async Task<ActionResult<UserLike>> GetSingleUserLike(int id)
        {
            var result = await _userLikeService.GetSingleUserLike(id);
            if (result is null)
                return NotFound("Kullanıcı beğenisi bulunamadı.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<UserLike>>> AddUserLike(UserLike userLike)
        {
            var result = await _userLikeService.AddUserLike(userLike);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<UserLike>>> UpdateUserLike(int id, UserLike request)
        {
            var result = await _userLikeService.UpdateUserLike(id, request);
            if (result is null)
                return NotFound("Kullanıcı beğenisi bulunamadı.");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserLike>>> DeleteUserLike(int id)
        {
            var result = await _userLikeService.DeleteUserLike(id);
            if (result is null)
                return NotFound("Kullanıcı beğenisi bulunamadı.");
            return Ok(result);
        }
    }
}