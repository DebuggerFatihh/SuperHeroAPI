namespace SuperHeroAPI.Services.UserBookmarkService
{
    public interface IUserBookmarkService
    {
        Task<List<UserBookmark>> GetAllUserBookmarks();
        Task<UserBookmark> GetSingleUserBookmark(int id);
        Task<List<UserBookmark>?> AddUserBookmark(UserBookmark userBookmark);
        Task<List<UserBookmark>?> UpdateUserBookmark(int id, UserBookmark request);
        Task<List<UserBookmark>?> DeleteUserBookmark(int id);

        Task<List<UserBookmark>> GetBookmarkByUser();
    }
}