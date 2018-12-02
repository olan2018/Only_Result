using Microsoft.EntityFrameworkCore;

namespace Application.Models
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<UserItem> UserItems { get; set; }
        public DbSet<StudentItem> StudentItems { get; set; }
        public DbSet<TutorItem> TutorItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserItem>().ToTable("User");
            modelBuilder.Entity<StudentItem>().ToTable("Student");
            modelBuilder.Entity<TutorItem>().ToTable("Tutor");
        }
    }
}
