using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    public class AggregatedMachinePing : BaseEntity
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
        public int DroppedPings { get; set; }
        public int TotalPings { get; set; }
        public int LagSdMs { get; set; }
        public int LagMinMs { get; set; }
        public int LagMaxMs { get; set; }
        public int LagMedianMs { get; set; }
        public DateTime Day { get; set; }
    }
}
