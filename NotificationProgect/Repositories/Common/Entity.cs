namespace NotificationProgect.Repositories.Common;

public abstract class Entity : IEntity
{
    public string Id { get; set; }

    public bool IsTransient() // проверка новая ли модель 
    {
        return Id == null;
    }
}
