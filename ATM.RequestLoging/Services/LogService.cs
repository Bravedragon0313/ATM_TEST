using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM.RequestLog.Data;
using ATM.RequestLog.Models;
using ATM.Utils.Data;
using Microsoft.EntityFrameworkCore;
using static ATM.DAL.DataUtils;

namespace ATM.RequestLog.Services
{
    /// <summary>
    /// LogService
    /// </summary>
    public class LogService
    {
        private readonly LogDbContext _db;

        public LogService(LogDbContext db)
        {
            _db = db;
        }

        public Task LogRequestAsync(RequestResponseHistory historyItem)
        {
            _db.HistoryLog.Add(historyItem);

            return _db.SaveChangesAsync();
        }

        public async Task<DataPagingUtils.PagedResult<RequestResponseHistory>> GetRequestLogPagedAsync(int page)
        {
            var u = await (_db.HistoryLog).GetPagedResultAsync(page, 10);

            return u;
        }

        public async Task<IEnumerable<RequestResponseHistory>> GetLogsListAsync()
        {
            var items = from i in _db.HistoryLog
                        orderby i.RequestTime descending
                        select i;

            return await items.ToListAsync();
        }
    }
}
