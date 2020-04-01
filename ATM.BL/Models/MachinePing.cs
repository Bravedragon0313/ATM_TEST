using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    public class MachinePing : BaseEntity
    {
        public string DeviceId { get; set; }
        public DateTime DeviceTime { get; set; }
        public DateTime Updated { get; set; }
    }
}
