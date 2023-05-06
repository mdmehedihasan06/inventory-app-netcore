using INVENTORY.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Infrastructure.RepositoryInterfaces.Generic
{
	public interface IAsyncRepository<T> where T : BaseEntity
	{
		Task<IReadOnlyList<T>> GetAllAsync();
		Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
		Task<T> GetByIdAsync(int id);
		Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate);
		Task<T> AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
