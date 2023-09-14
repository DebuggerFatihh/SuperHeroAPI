using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroAPI.Services.BookmarkService
{
    public class BookmarkService : IBookmarkService
    {
        private readonly DataContext _context;

        public BookmarkService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Bookmark>?> AddBookmark(Bookmark book)
        {
            _context.Bookmarks.Add(book);
            await _context.SaveChangesAsync();
            return await GetAllBookmarks();
        }

        public async Task<List<Bookmark>?> DeleteBookmark(int id)
        {
            var bookmark = await _context.Bookmarks.FindAsync(id);
            if (bookmark == null) return null;

            _context.Bookmarks.Remove(bookmark);
            await _context.SaveChangesAsync();
            return await GetAllBookmarks();
        }
        public async Task<List<Bookmark>> GetAllBookmarks()
        {
            var Bookmarks = await _context.Bookmarks
                .Include(b => b.Category)
                .Include(b => b.User)
                .ToListAsync();

            return Bookmarks;
        }
        public async Task<List<Bookmark>> GetBookmarkByCategory(int categoryId)
        {
            var bookmarksInCategory = await _context.Bookmarks
                .Where(b => b.CategoryId == categoryId)
                .Include(x => x.Category)
                .Include(x => x.User)
                .ToListAsync();
            if (bookmarksInCategory == null || !bookmarksInCategory.Any())
            {
                return null;
            }

            return bookmarksInCategory;
        }

        public async Task<Bookmark> GetSingleBookmark(int id)
        {
            var Bookmarks = await _context.Bookmarks.FindAsync(id);
            return Bookmarks;
        }

        public async Task<List<Bookmark>?> UpdateBookmark(int id, Bookmark request)
        {
            var bookkmark = await _context.Bookmarks.FindAsync(id);
            if (bookkmark == null) return null;

            bookkmark.Id = request.Id;
            bookkmark.Description = request.Description;
            bookkmark.Title = request.Title;
            bookkmark.Url = request.Url;
            bookkmark.CategoryId = request.CategoryId;
            bookkmark.CreatedAt = request.CreatedAt;
            bookkmark.UserId = request.UserId;
            await _context.SaveChangesAsync();

            return await GetAllBookmarks();
        }

    }
}