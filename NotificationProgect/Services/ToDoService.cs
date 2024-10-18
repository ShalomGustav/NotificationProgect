using NotificationProgect.Entity;
using NotificationProgect.Models;
using NotificationProgect.Repositories;
using NotificationProgect.Repositories.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NotificationProgect.Services
{
    public class ToDoService : CrudService<ToDoModel, ToDoModelEntity>
    {
        private readonly List<ToDoModel> _toDos;
        private readonly Func<IToDoRepository> _repositoryFactory;

        public ToDoService(Func<IToDoRepository> repositoryFactory) : base(repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public List<ToDoModel> GetToDos()
        {
            return _toDos;//
        }

        public async Task<ToDoModel[]> GetToDoByDateAsync(DateTime date)
        {
            using (var repository = _repositoryFactory())
            {
                var dateEntity = await repository.GetToDoByDateAsync(new[] { date });

                if (dateEntity == null)
                {
                    throw new NullReferenceException(nameof(dateEntity));
                }

                return dateEntity.Select(x => x.ToModel(AbstractTypeFactory<ToDoModel>.TryCreateInstance())).ToArray();
            }
        }

        public async Task<ToDoModel[]> GetToDoAllAsync()
        {
            using (var repository = _repositoryFactory())
            {
                var query = await repository.GetToDoAllAsync();
                var result = query.Select(x => x.ToModel(AbstractTypeFactory<ToDoModel>.TryCreateInstance())).ToArray();
                return result;
            }
        }

        public async Task<ToDoModel> GetToDoByIdAsync(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var user = await GetByIdAsync(id);

            if (user == null)
            {
                throw new NullReferenceException(nameof(user));
            }

            return user;
        }

        public async Task SaveChangesAsync(ToDoModel toDoModel)
        {
            if (toDoModel == null)
            {
                throw new ArgumentNullException(nameof(toDoModel));
            }

            await SaveChangesAsync(new[] { toDoModel });
        }

        public async Task DeleteToDoAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            await DeleteAsync(new[] { id });
        }

        protected override async Task<ToDoModelEntity[]> LoadEntities(IRepository repository, IEnumerable<string> ids)
        {
            return await ((IToDoRepository) repository).GetToDoByIdsAsync(ids.ToArray());
        }
    }
}
