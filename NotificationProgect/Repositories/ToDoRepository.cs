using NotificationProgect.Entity;
using NotificationProgect.Repositories.Common;

namespace NotificationProgect.Repositories
{
    public class ToDoRepository : DbContextRepositoryBase<ToDoDbContext>, IToDoRepository
    {
        public ToDoRepository(ToDoDbContext dbContext, IUnitOfWork unitOfWork = null) : base(dbContext, unitOfWork)
        {
        }

        public IQueryable<ToDoModelEntity> ToDoModels => DbContext.Set<ToDoModelEntity>();

    }
}
