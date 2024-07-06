using Microsoft.EntityFrameworkCore;
using StudentDormCooknook.Data;

namespace StudentDormCookbook.Data.Generic
{
	public class Repository<T> : IRepository<T>
		where T : class
	{
		protected readonly StudentCookbookDbContext _context;

		public Repository(StudentCookbookDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Create
		/// </summary>
		public void Add(T entity)
		{
			_context.Add(entity);
		}

		/// <summary>
		/// Read
		/// </summary>
		public IQueryable<T> GetAll()
		{
			return _context.Set<T>().AsNoTracking();
		}

		/// <summary>
		/// Update
		/// </summary>
		public void Update(T entity)
		{
			_context.Update(entity);
		}

		/// <summary>
		/// Delete
		/// </summary>
		public void Delete(T entity)
		{
			_context.Remove(entity);
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
