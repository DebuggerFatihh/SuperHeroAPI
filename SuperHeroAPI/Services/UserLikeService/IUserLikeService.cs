namespace SuperHeroAPI.Services.UserLikeService
{
    public interface IUserLikeService
    {
        Task<List<UserLike>> GetAllUserLikes();
        Task<UserLike> GetSingleUserLike(int id);
        Task<List<UserLike>?> AddUserLike(UserLike userLike);
        Task<List<UserLike>?> UpdateUserLike(int id, UserLike request);
        Task<List<UserLike>?> DeleteUserLike(int id);

        Task<List<UserLike>?> GetLikeByUser();
    }
}