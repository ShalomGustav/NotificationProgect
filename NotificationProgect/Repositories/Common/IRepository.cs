﻿namespace NotificationProgect.Repositories.Common
{
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Gets the unit of work. This class actually saves the data into underlying storage.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Attaches the specified item to the context that is tracking objects.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        void Attach<T>(T item) where T : class;

        /// <summary>
        /// Adds the specified item to the context in the Added state. Meaning item will be created in the underlying storage.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        void Add<T>(T item) where T : class;

        /// <summary>
        /// Updates the specified item. Marks the item for the update.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        void Update<T>(T item) where T : class;

        /// <summary>
        /// Removes the specified item. Item marked for deletion and will be removed from the underlying storage on save.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        void Remove<T>(T item) where T : class;
    }
}
