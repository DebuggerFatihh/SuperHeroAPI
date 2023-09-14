using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.UserBookmarkService;
using System.Collections.Generic;
using System.Threading.Tasks;
 // IUserBookmarkService arabirimini içeren ad alanını eklemelisiniz.

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBookmarkController : ControllerBase
    {
        private readonly IUserBookmarkService _userBookmarkService;

        public UserBookmarkController(IUserBookmarkService userBookmarkService)
        {
            _userBookmarkService = userBookmarkService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserBookmark>> GetSingleUserBookmark(int id)
        {
            var result = await _userBookmarkService.GetSingleUserBookmark(id);
            if (result is null)
                return NotFound("userBookmark Bulunamadı.");
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<UserBookmark>>> GetAllUserBookmarks()
        {
            return await _userBookmarkService.GetAllUserBookmarks();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserBookmark>> GetSingleUserBookmark(int id)
        //{
        //    var userBookmark = await _userBookmarkService.GetSingleUserBookmark(id);
        //    if (userBookmark == null)
        //        return NotFound("Yer işareti bulunamadı.");
        //    return Ok(userBookmark);
        //}

        [HttpPost]
        public async Task<ActionResult<UserBookmark>> AddUserBookmark(UserBookmark userBookmark)
        {
            var addedUserBookmark = await _userBookmarkService.AddUserBookmark(userBookmark);
            return Ok(addedUserBookmark);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserBookmark>> UpdateUserBookmark(int id, UserBookmark userBookmark)
        {
            var updatedUserBookmark = await _userBookmarkService.UpdateUserBookmark(id, userBookmark);
            if (updatedUserBookmark == null)
                return NotFound("Yer işareti bulunamadı.");
            return Ok(updatedUserBookmark);
        }

        [HttpDelete("{id}")]
        public async Task<List<UserBookmark>> DeleteUserBookmark(int id)
        {
            var result = await _userBookmarkService.DeleteUserBookmark(id);
            return result;
        }
    }
}