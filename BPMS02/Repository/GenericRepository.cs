
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BPMS02.IRepository;
using BPMS02.Models;
using Microsoft.EntityFrameworkCore;

namespace BPMS02.Repository
{
    public abstract class GenericRepository<T>: IBasicCRUDRepository<T> where T : class
    {
        protected DataContext context;

        public GenericRepository(DataContext _context)
        {
            context = _context;
        }

        public virtual IEnumerable<T> EntityItems => context.Set<T>().AsQueryable();

        public virtual Task CreateAsync(T dbEntity)
        {
            context.Set<T>().Add(dbEntity);
            return context.SaveChangesAsync();
        }
        public virtual Task<T> QueryByIdAsync(Guid Id)
        {
            return context.Set<T>().FindAsync(Id);
        }
        public virtual async Task<Tuple<List<T>, int>> PageListAsync<TOrderBy>(Expression<Func<T, TOrderBy>> orderBy, int pageIndex, int pageSize)
        {
            var query = context.Set<T>().AsQueryable();
            var count = await query.CountAsync();
            
            var linqVar = await query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Tuple<List<T>, int>(linqVar, count);
        }

        public virtual Task EditAsync(T dbEntity)
        {
            context.Entry<T>(dbEntity).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

        public virtual Task Delete(T dbEntity)
        {
            context.Remove(dbEntity);

            return context.SaveChangesAsync();

        }

        public async Task<T> Delete(Guid Id)
        {
            var dbEntry = await context.Set<T>().FindAsync(Id);
            if (dbEntry != null)
            {
                context.Set<T>().Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }
    }
}
