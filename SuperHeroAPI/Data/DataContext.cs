using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=BookmarkDb;Username=postgres;Password=1256yusuf");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<UserLike> UserLikes { get; set; }
        public DbSet<UserBookmark> UserBookmarks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        
    }
}
