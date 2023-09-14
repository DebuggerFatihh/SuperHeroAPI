using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroAPI.Services.UserLikeService
{
    public class UserLikeService : IUserLikeService
    {
        private readonly DataContext _context;

        private static List<UserLike> userLike = new List<UserLike>
        {
            // Başlangıçta boş bir liste
        };
        public UserLikeService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserLike>> AddUserLike(UserLike userLike)
        {
            _context.UserLikes.Add(userLike);
            await _context.SaveChangesAsync();
            return await GetAllUserLikes();
        }

        public async Task<List<UserLike>?> DeleteUserLike(int id)
        {
            var userLike = await _context.UserLikes.FindAsync(id);
            if (userLike is null)
                return null;

            _context.UserLikes.Remove(userLike);
            await _context.SaveChangesAsync();

            return await GetAllUserLikes();
        }

        public async Task<List<UserLike>> GetAllUserLikes()
        {
            var userLikes = await _context.UserLikes.ToListAsync();
            return userLikes;
        }

        public async Task<UserLike?> GetSingleUserLike(int id)
        {
            var userLike = await _context.UserLikes.FindAsync(id);
            return userLike;
        }
        public async Task<List<UserLike>> GetLikeByUser()
        {
            return await _context.UserLikes
                 .Include(x => x.Bookmark.User)
                 .Include(x => x.Bookmark.Category)
                 .Include(x => x.User)
                 .ToListAsync();
        }

        public async Task<List<UserLike>?> UpdateUserLike(int id, UserLike request)
        {
            var userLike = await _context.UserLikes.FindAsync(id);
            if (userLike is null)
                return null;

            userLike.UserId = request.UserId;
            userLike.Id = request.Id;
            userLike.BookmarkId = request.BookmarkId;
            // Diğer gerekli güncellemeleri burada yapabilirsiniz.

            await _context.SaveChangesAsync();

            return await GetAllUserLikes();
        }
    }
}