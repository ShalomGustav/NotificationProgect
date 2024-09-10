using Microsoft.EntityFrameworkCore;
using NotificationProgect.Entity;

namespace NotificationProgect.Repositories
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoModelEntity>().ToTable("ToDo").HasKey(x => x.Id);
            modelBuilder.Entity<ToDoModelEntity>().Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();

            modelBuilder.Entity<ToDoModelEntity>().Property(x => x.StartDate).HasColumnName("StartDate").IsRequired(false);
            modelBuilder.Entity<ToDoModelEntity>().Property(x => x.EndDate).HasColumnName("EndDate").IsRequired(false);
            modelBuilder.Entity<ToDoModelEntity>().Property(x => x.Description).HasColumnName("Description").IsRequired(false);
            modelBuilder.Entity<ToDoModelEntity>().Property(x => x.Complited).HasColumnName("Complited").IsRequired(false);
            modelBuilder.Entity<ToDoModelEntity>().Property(x => x.Contact).HasColumnName("Contact").IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
