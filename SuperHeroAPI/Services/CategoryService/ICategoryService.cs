namespace SuperHeroAPI.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetSingleCategory(int id);
        Task<List<Category>?> AddCategory(Category category);
        Task<List<Category>?> UpdateCategory(int id, Category request);
        Task<List<Category>?> DeleteCategory(int id);
    }
}