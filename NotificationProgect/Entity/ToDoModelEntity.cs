using NotificationProgect.Models;
using NotificationProgect.Repositories.Common;
using System.ComponentModel.DataAnnotations;

namespace NotificationProgect.Entity;

public class ToDoModelEntity : Repositories.Common.Entity, IDateEntity<ToDoModelEntity, ToDoModel>
{
    [StringLength(256)]
    public string Name { get; set; }

    [StringLength(1024)]
    public string Description { get; set; }

    public bool? Complited { get; set; }

    [StringLength(256)]
    public string Contact { get; set; }

    public ToDoType Type { get; set; }

    public DateTime CreateDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }


    public ToDoModel ToModel(ToDoModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        model.Name = Name;
        model.Description = Description;
        model.Complited = Complited;
        model.Contact = Contact;
        model.Type = Type;

        model.StartDate = StartDate;
        model.CreateDate = CreateDate;
        model.EndDate = EndDate;

        return model;
    }

    public ToDoModelEntity FromModel(ToDoModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        Name = model.Name;
        Description = model.Description;
        Complited = model.Complited;
        Contact = model.Contact;
        Type = model.Type;

        StartDate = model.StartDate;
        CreateDate = model.CreateDate;
        EndDate = model.EndDate;

        return this;
    }

    public void Patch(ToDoModelEntity patch)
    {
        patch.Name = Name;
        patch.Description = Description;
        patch.Complited = Complited;
        patch.Contact = Contact;
        patch.Type = Type;
        patch.StartDate = StartDate;
        patch.CreateDate = CreateDate;
        patch.EndDate = EndDate;
    }
}

