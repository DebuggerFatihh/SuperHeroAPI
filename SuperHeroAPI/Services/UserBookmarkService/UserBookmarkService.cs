using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroAPI.Services.UserBookmarkService
{
    public class UserBookmarkService : IUserBookmarkService
    {
        private readonly DataContext _context;

        public UserBookmarkService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserBookmark>> GetAllUserBookmarks()
        {
            var userBookmark = await _context.UserBookmarks.ToListAsync();
            return userBookmark;
        }

        public async Task<UserBookmark> GetSingleUserBookmark(int id)
        {
            var userBookmark = await _context.UserBookmarks.FindAsync(id);
            return userBookmark;
        }
        public async Task<List<UserBookmark>> GetBookmarkByUser()
        {
            return await _context.UserBookmarks
                 .Include(x => x.Bookmark.User)
                 .Include(x => x.Bookmark.Category)
                 .Include(x => x.User)
                 .ToListAsync();
        }


        public async Task<List<UserBookmark>> AddUserBookmark(UserBookmark userBookmark)
        {
            _context.UserBookmarks.Add(userBookmark);
            await _context.SaveChangesAsync();
            return await GetAllUserBookmarks();
        }


        public async Task<List<UserBookmark>> UpdateUserBookmark(int id, UserBookmark request)
        {
            var userBookmark = await _context.UserBookmarks.FindAsync(id);
            if (userBookmark is null)
                return null;

            userBookmark.Id = request.Id;
            userBookmark.UserId = request.UserId;
            userBookmark.BookmarkId = request.BookmarkId;
            // Diğer güncelleme işlemlerini ekleyin

            await _context.SaveChangesAsync();
            return await GetAllUserBookmarks();
        }

        public async Task<List<UserBookmark>?> DeleteUserBookmark(int id)
        {
            var userBookmark = await _context.UserBookmarks.FindAsync(id);
            if (userBookmark is null)
                return null;

            _context.UserBookmarks.Remove(userBookmark);
            await _context.SaveChangesAsync();
            return await GetAllUserBookmarks();
        }
    }
}