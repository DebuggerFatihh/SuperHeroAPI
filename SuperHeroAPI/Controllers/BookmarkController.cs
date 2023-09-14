using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services.BookmarkService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarkService _bookmarkService;

        public BookmarkController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Bookmark>>> GetAllBookmarks()
        {
            var bookmarks = await _bookmarkService.GetAllBookmarks();
            return Ok(bookmarks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bookmark>> GetSingleBookmark(int id)
        {
            var bookmark = await _bookmarkService.GetSingleBookmark(id);
            if (bookmark is null)
                return NotFound("Yer işareti bulunamadı.");
            return Ok(bookmark);
        }


        [HttpPost]
        public async Task<ActionResult<List<Bookmark>>> AddBookmark(Bookmark bookmark)
        {
            var bookmarks = await _bookmarkService.AddBookmark(bookmark);
            return Ok(bookmarks);
        }

        [HttpPut]
        public async Task<List<Bookmark>?> UpdateBookmark(int id, Bookmark request)
        {
            return await _bookmarkService.UpdateBookmark(id, request);

        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult<List<Bookmark>>> UpdateBookmark(int id, Bookmark request)
        //{
        //    var bookmarks = await _bookmarkService.UpdateBookmark(id, request);
        //    if (bookmarks is null)
        //        return NotFound("Yer işareti bulunamadı.");
        //    return Ok(bookmarks);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Bookmark>>> DeleteBookmark(int id)
        {
            var bookmarks = await _bookmarkService.DeleteBookmark(id);
            if (bookmarks is null)
                return NotFound("Yer işareti bulunamadı.");
            return Ok(bookmarks);
        }
        [HttpGet("GetBookmarkByCategory")]
        public async Task<ActionResult<Bookmark>> GetBookmarkByCategory(int categoryId)
        {
            var result = await _bookmarkService.GetBookmarkByCategory(categoryId);

            return Ok(result);
        }
    }
}
