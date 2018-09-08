using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenericRepositoryForEF6.EntityFrameworkLibrary;

namespace GenericRepositoryForEF6.RepositoryLibrary
{
	public abstract class GenericRepository<C, T> :
		IGenericRepository<T> where T : class where C : IDbContext
	{
		protected readonly IDbContext _context;

		public GenericRepository(IDbContext context)
		{
			_context = context;
		}


		public virtual IReadOnlyList<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}

		public virtual void Add(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public virtual void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public virtual void Edit(T entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Save()
		{
			_context.SaveChanges();
		}
	}
}