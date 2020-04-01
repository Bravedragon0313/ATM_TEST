using ATM.RequestLog.Models;
using Microsoft.EntityFrameworkCore;

namespace ATM.RequestLog.Data
{
    /// <summary>
    /// Log Db Context
    /// </summary>
    public class LogDbContext : DbContext
    {
        public DbSet<RequestResponseHistory> HistoryLog { get; set; }

        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestResponseHistory>().HasIndex(b => b.RequestTime);
            modelBuilder.Entity<RequestResponseHistory>().HasIndex(b => b.StatusCode);
        }
    }
}
