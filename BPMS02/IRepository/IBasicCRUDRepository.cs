using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BPMS02.IRepository
{
    public interface IBasicCRUDRepository<T> where T : class
    {

        IEnumerable<T> EntityItems { get; }

 
        Task CreateAsync(T dbEntity);


        Task<T> QueryByIdAsync(Guid Id);

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="TOrderBy">排序字段类型</typeparam>
        /// <param name="orderBy">排序字段</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns></returns>
        Task<Tuple<List<T>, int>> PageListAsync<TOrderBy>(Expression<Func<T, TOrderBy>> orderBy, int pageIndex, int pageSize);

        Task EditAsync(T dbEntity);

        Task Delete(T dbEntity);

        Task<T> Delete(Guid Id);
    }
}
