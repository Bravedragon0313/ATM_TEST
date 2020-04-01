using System;
using System.ComponentModel.DataAnnotations;

namespace ATM.RequestLog.Models
{
    /// <summary>
    /// RequestResponseHistory
    /// </summary>
    public class RequestResponseHistory
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime RequestTime { get; set; }

        [Required]
        public long ResponseMillis { get; set; }

        [Required]
        public int StatusCode { get; set; }

        [Required]
        public string Method { get; set; }

        [Required]
        public string Path { get; set; }

        public string QueryString { get; set; }

        public string RequestBody { get; set; }

        public string ResponseBody { get; set; }

        public int? AuthorizedUser { get; set; }

        public string DeviceId { get; set; }
    }
}
