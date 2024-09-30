using Microsoft.EntityFrameworkCore;
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

        public async Task<ToDoModelEntity[]> GetToDoByDateAsync(DateTime[] date)
        {
            if(date == null || date.Length == 0)
            {
                return Array.Empty<ToDoModelEntity>();
            }

            var query = ToDoModels.Where(x => date.Contains(x.CreateDate));
            var result = await query.ToArrayAsync();
            return result;
        }

        public async Task<ToDoModelEntity[]> GetToDoByIdsAsync(string[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                return Array.Empty<ToDoModelEntity>();
            }

            var query  = ToDoModels.Where(x =>  ids.Contains(x.Id));
            var result = await query.ToArrayAsync();
            return result;
        }

        public async Task<ToDoModelEntity> GetToDoByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            var result = await ToDoModels.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<ToDoModelEntity[]> GetToDoAllAsync()
        {
            return await ToDoModels.ToArrayAsync();
        }
    }
}
