namespace mail_api_monq.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория бд для сущности T
    /// </summary>
    /// <typeparam name="T">Сущность</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Получить список из бд определенной сущности
        /// </summary>
        IQueryable<T> Items { get; }
        /// <summary>
        /// Получить определенный элемент из бд для сущности T
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Полученную сущность</returns>
        T Get(int id);
        /// <summary>
        /// Получить определенный элемент асинхронно из бд для сущности T
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="Cancel">Объект отмены асинхронного запроса</param>
        /// <returns>Возвращает элемент с определенным Id сущности T</returns>
        Task<T> GetAsync(int id, CancellationToken Cancel = default);
        /// <summary>
        /// Добавить элемент в БД сущности Т
        /// </summary>
        /// <param name="item">Сущность</param>
        /// <returns>Добавленный элемент сущности Т</returns>
        T Add(T item);
        /// <summary>
        /// Добавить элемент асинхронно в бд
        /// </summary>
        /// <param name="item">Сущность</param>
        /// <param name="Cancel">Объект отмены асинхронного запроса на добавление</param>
        /// <returns>Добавленный элемент сущности Т</returns>
        Task<T> AddAsync(T item, CancellationToken Cancel = default);
        /// <summary>
        /// Изменить элемент сущности Т в бд
        /// </summary>
        /// <param name="item">Сущность</param>
        void Update(T item);
        /// <summary>
        /// Изменить элемент сущности Т в бд асинхронно
        /// </summary>
        /// <param name="item">Сущность</param>
        /// <param name="Cancel">Объект отмены асинхронного запроса на добавление</param>
        /// <returns>Пустой таск, аналогичен void</returns>
        Task UpdateAsync(T item, CancellationToken Cancel = default);
        /// <summary>
        /// Удалить элемент сущности Т из бд
        /// </summary>
        /// <param name="id">Идентификатор</param>
        void Remove(int id);
        /// <summary>
        /// Удалить асинхронно элемент сущности Т из бд
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="Cancel">Объект отмены асинхронного запроса на добавление</param>
        /// <returns>Пустой таск, аналогичен void</returns>
        Task RemoveAsync(int id, CancellationToken Cancel = default);
    }
}
