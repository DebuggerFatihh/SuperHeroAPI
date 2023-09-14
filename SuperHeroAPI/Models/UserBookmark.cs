namespace SuperHeroAPI.Models
{
    public class UserBookmark
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookmarkId { get; set; }

        public virtual User? User { get; set; }
        public virtual Bookmark? Bookmark { get; set; }
    }
}
