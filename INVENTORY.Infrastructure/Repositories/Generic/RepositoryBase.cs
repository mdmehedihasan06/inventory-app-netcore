using INVENTORY.Domain.Entities;
using INVENTORY.Infrastructure.Context;
using INVENTORY.Infrastructure.RepositoryInterfaces.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Infrastructure.Repositories.Generic
{
	public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseEntity
	{
		protected readonly AppDbContext _context;

		public RepositoryBase(AppDbContext context)
		{
			_context = context;
		}
		public async Task<T> AddAsync(T entity)
		{
			try
			{
				_context.Set<T>().Add(entity);
				await _context.SaveChangesAsync();
				return entity;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public async Task<T> UpdateAsync(T entity)
		{			
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
		public async Task DeleteAsync(T entity)
		{			
            try
            {
                //_context.Set<T>().Remove(entity);
                //await _context.SaveChangesAsync();
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().Where(predicate).ToListAsync();
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
        public async Task<T> GetByIdAsync(int id)
		{
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (DbException ex)
            {
                throw ex;
            }
		}
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

		public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate)
		{
			try
			{
				var entity = await _context.Set<T>().Where(predicate).ToListAsync();
				return entity != null;
		    }
            catch (DbException ex)
            {
                throw ex;
            }
}

	}
}
