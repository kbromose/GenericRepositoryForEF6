using System.Collections.Generic;

namespace GenericRepositoryForEF6.RepositoryLibrary
{
	public interface IGenericRepository<T> where T : class
	{

		IReadOnlyList<T> GetAll();
		void Add(T entity);
		void Delete(T entity);
		void Edit(T entity);
		void Save();
	}
}
