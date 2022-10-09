using mail_api_monq.DAL.Data;
using mail_api_monq.DAL.Entities.Base;
using mail_api_monq.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace mail_api_monq.DAL.Repositories
{
    /// <summary>
    /// Базовый репозиторий для работы с сущностью
    /// </summary>
    /// <typeparam name="T">Сущность, которая реализует базовую сущность и имеет пустой конструктор</typeparam>
    internal class Repository<T> : IRepository<T>
        where T : Entities.Base.IEntity, new()
    {
        private readonly DbSet<T> _Set;
        private readonly AppDbContext _context;
        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="context">Контекст бд</param>
        public Repository(AppDbContext context)
        {
            _context = context;
            _Set = context.Set<T>();
        }
        /// <summary>
        /// Добавить сущность в БД
        /// </summary>
        /// <param name="item">Сущность</param>
        /// <returns>Добавленную сущность</returns>
        /// <exception cref="ArgumentNullException">Переданный аргумент должен быть сущностью</exception>
        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _context.Entry(item).State = EntityState.Added;
            _context.SaveChanges();
            return item;
        }
        /// <summary>
        /// Добавить асинхронно в бд
        /// </summary>
        /// <param name="item">Сущность</param>
        /// <param name="Cancel">Объект отмены асинхронного добавления</param>
        /// <returns>Добавленную сущность</returns>
        public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            _context.Entry(item).State = EntityState.Added;
            await _context.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }
        /// <summary>
        /// Получить список сущностей, можно переопределить
        /// </summary>
        public virtual IQueryable<T> Items => _Set;
        /// <summary>
        /// Получить сущность с определенным Id
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public T Get(int id) => Items.SingleOrDefault(item => item.Id == id);
        /// <summary>
        /// Получить сущность асинхронно
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="Cancel">Объект отмены асинхронного получения</param>
        /// <returns>Сущность с опеределнным Id</returns>
        /// <exception cref="ArgumentOutOfRangeException">Нужно передать Id, который больше 0</exception>
        public async Task<T> GetAsync(int id, CancellationToken Cancel = default)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            return await Items.SingleOrDefaultAsync(item => item.Id == id, Cancel).ConfigureAwait(false);
        }
        /// <summary>
        /// Удалить сущность с определенным Id
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <exception cref="ArgumentOutOfRangeException">Нужно передать Id, который больше 0</exception>
        public void Remove(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var item = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new T { Id = id };

            _context.Remove(item);

            _context.SaveChanges();
        }
        /// <summary>
        /// Удалить асинхронно сущность с определенным Id
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="Cancel">Объект отмены асинхронного удаления</param>
        /// <returns>Пустой Task аналогично void</returns>
        /// <exception cref="ArgumentOutOfRangeException">Нужно передать Id, который больше 0</exception>
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            if(id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            _context.Remove(new T { Id = id });
            await _context.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
        /// <summary>
        /// Изменить сущность в бд
        /// </summary>
        /// <param name="item">Сущность</param>
        /// <exception cref="ArgumentNullException">Нужно передать сущность, которая не равна null</exception>
        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _context.Entry(item).State = EntityState.Modified;

            _context.SaveChanges();
        }
        /// <summary>
        /// Изменить сущность в бд асинхронно
        /// </summary>
        /// <param name="item">Сущность</param>
        /// <param name="Cancel">Объект отмены асинхронного изменения</param>
        /// <returns>Пустой Task аналогично void</returns>
        /// <exception cref="ArgumentNullException">Нужно передать сущность, которая не равна null</exception>
        public async Task UpdateAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
