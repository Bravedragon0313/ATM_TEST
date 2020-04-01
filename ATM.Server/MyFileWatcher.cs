using Microsoft.AspNetCore.SignalR;
using ATM.Server.Hubs;
using System.IO;
using ATM.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ATM.Server
{
    public interface IMyFileWatcher { }

    public class MyFileWatcher : IMyFileWatcher
    {
        private readonly IHubContext<FileWatcherHub> _hubContext;
        private readonly ApplicationDbContext _context;

        public MyFileWatcher(IHubContext<FileWatcherHub> hubContext, ApplicationDbContext context)
        {
            _hubContext = hubContext;
            _context = context;

        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            var file = new FileDetails() { Name = e.Name, ChangeType = e.ChangeType.ToString() };
            _hubContext.Clients.All.SendAsync("onFileChange", file);
        }
    }
}
