using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace NotificationProgect.Repositories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ToDoDbContext>
    {
        public ToDoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ToDoDbContext>();
            builder.UseSqlServer("Data Source=(local);" +
                "Initial Catalog=UserManagement;Persist Security Info=True;" +
                "User ID=test;Password=test;MultipleActiveResultSets=True;" +
                "Connect Timeout=30;TrustServerCertificate=True");

            return new ToDoDbContext(builder.Options);
        }
    }
}
