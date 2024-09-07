namespace NotificationProgect.Repositories.Common
{
    public interface IUnitOfWork
    {
        int Commit(); //фиксация изменений
        Task<int> CommitAsync(); //фиксация изменений асинхронно 
    }
}
