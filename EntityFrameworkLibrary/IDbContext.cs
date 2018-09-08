using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace GenericRepositoryForEF6.EntityFrameworkLibrary
{
	public interface IDbContext
	{
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		int SaveChanges();
		DbEntityEntry Entry(object entity);
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
	}
}