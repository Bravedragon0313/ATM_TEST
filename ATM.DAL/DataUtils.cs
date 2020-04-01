using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ATM.DAL
{
    /// <summary>
    /// DataUtils
    /// </summary>
    public static class DataUtils
    {
        /// <summary>
        /// Task<PagedResult<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<ATM.Utils.Data.DataPagingUtils.PagedResult<T>> GetPagedResultAsync<T>(this IQueryable<T> query, int currentPage, int pageSize) where T : class
        {
            var skip = (currentPage - 1) * pageSize;
            var take = pageSize;

            var rowCount = await query.CountAsync();
            var results = await query.Skip(skip).Take(take).ToListAsync();

            var pagedResult = new ATM.Utils.Data.DataPagingUtils.PagedResult<T>
            {
                CurrentPage = currentPage,
                PageCount = (int)Math.Ceiling(decimal.Divide(rowCount, pageSize)),
                PageSize = pageSize,
                RowCount = rowCount,
                Results = results
            };

            return pagedResult;
        }
    }
}
