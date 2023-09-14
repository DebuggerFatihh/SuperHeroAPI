namespace SuperHeroAPI.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetSingleUser(int id);
        Task<List<User?>> AddUser(User user);
        Task<User?> UpdateUser(int id, User request);
        Task<bool> DeleteUser(int id);

        Task<User?> GetUserByUsernameAndPassword(string username, string password);
    }
}