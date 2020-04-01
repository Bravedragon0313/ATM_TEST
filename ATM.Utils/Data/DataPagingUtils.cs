using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM.Utils.Data
{
    /// <summary>
    /// DataUtils
    /// </summary>
    public static class DataPagingUtils
    {
        /// <summary>
        /// PagedResultBase
        /// </summary>
        public abstract class PagedResultBase
        {
            public int CurrentPage { get; set; }
            public int PageCount { get; set; }
            public int PageSize { get; set; }
            public int RowCount { get; set; }
        }

        /// <summary>
        /// PagedResultBase
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class PagedResult<T> : PagedResultBase where T : class
        {
            public ICollection<T> Results { get; set; }

            public PagedResult()
            {
                Results = new List<T>();
            }
        }

        /// <summary>
        /// GetPagedResult
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PagedResult<T> GetPagedResult<T>(this IQueryable<T> query, int currentPage, int pageSize) where T : class
        {
            var skip = (currentPage - 1) * pageSize;
            var take = pageSize;

            var rowCount = query.Count();
            var results = query.Skip(skip).Take(take).ToList();

            var pagedResult = new PagedResult<T>
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
