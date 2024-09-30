using NotificationProgect.Entity;
using NotificationProgect.Repositories.Common;

namespace NotificationProgect.Repositories
{
    public interface IToDoRepository : IRepository
    {
        Task<ToDoModelEntity[]> GetToDoByIdsAsync(string[] ids);
        Task<ToDoModelEntity[]> GetToDoByDateAsync(DateTime[] date);
        Task<ToDoModelEntity> GetToDoByIdAsync(string id);
        Task<ToDoModelEntity[]> GetToDoAllAsync();

    }
}
