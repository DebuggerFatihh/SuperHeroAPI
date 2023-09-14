using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroAPI.Services.BookmarkService
{
    public interface IBookmarkService
    {
        Task<List<Bookmark>> GetAllBookmarks();
        Task<Bookmark> GetSingleBookmark(int id);
        Task<List<Bookmark>?> AddBookmark(Bookmark bookmark);
        Task<List<Bookmark>?> UpdateBookmark(int id, Bookmark request);
        Task<List<Bookmark>?> DeleteBookmark(int id);
        Task<List<Bookmark>> GetBookmarkByCategory(int CategoryId);

    }
}




