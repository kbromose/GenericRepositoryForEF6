using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenericRepositoryForEF6.EntityFrameworkLibrary;

namespace GenericRepositoryForEF6.RepositoryLibrary
{
	public abstract class GenericRepository<C, T> :
		IGenericRepository<T> where T : class where C : IDbContext
	{
		protected readonly C _context;
		private readonly IDbContext _entity;

		public GenericRepository(IDbContext entity)
		{
			_entity = entity;
			_context = (C) entity;
		}

		public virtual IReadOnlyList<T> GetAll()
		{
			return _entity.Set<T>().ToList();
		}

		public virtual void Add(T entity)
		{
			_entity.Set<T>().Add(entity);
		}

		public virtual void Delete(T entity)
		{
			_entity.Set<T>().Remove(entity);
		}

		public virtual void Edit(T entity)
		{
			_entity.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Save()
		{
			_entity.SaveChanges();
		}
	}
}