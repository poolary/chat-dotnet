using Microsoft.EntityFrameworkCore;
using Backender.Model;

namespace Backender.AppDbContext
{
    public class AppDbContexts : DbContext
    {
        public AppDbContexts(DbContextOptions<AppDbContexts> options) : base(options)
        {
        }

        public DbSet<UserEntity> MessagesOfUsersChat { get; set; }
        public DbSet<UsersChat> UsersOfUsersChat { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
