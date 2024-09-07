namespace NotificationProgect.Repositories.Common;

public interface IEntity //признак того что это модель которая унаследована от entity это база данных
{
    string Id { get; set; }
}
