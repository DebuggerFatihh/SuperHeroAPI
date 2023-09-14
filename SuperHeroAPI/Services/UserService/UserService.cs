using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<User> GetSingleUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<List<User?>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetUserByUsernameAndPassword(string fullname, string password)
        {

            // Kullanıcı adı ve şifre ile veritabanında kullanıcıyı sorgula
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Fullname == fullname && u.Password == password);
            if (user == null) return null;

            return user;
        }

        public async Task<User?> UpdateUser(int id, User request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
                return null;

            user.Id = request.Id;
            user.Username = request.Username;
            user.Fullname = request.Fullname;
            user.Password = request.Password;

            // Diğer gerekli güncellemeleri burada yapabilirsiniz.

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetPassword(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

    }
}