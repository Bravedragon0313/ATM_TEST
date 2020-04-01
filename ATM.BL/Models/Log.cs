using ATM.BL.Models.Common;
using System;

namespace ATM.BL.Models
{
    /// <summary>
    /// Log
    /// </summary>
    public class Log
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
        public string LogLevel { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Message { get; set; }
        public DateTime ServerTimestamp { get; set; }
        public int Serial { get; set; }
    }
}
