using ATM.BL.Models.Common;
using System;

namespace ATM.BL.Models
{
    /// <summary>
    /// MachineEvent
    /// </summary>
    public class MachineEvent : BaseEntity
    {
        public string DeviceId { get; set; }
        public string EventType { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; }
        public DateTime? DeviceTime { get; set; }
    }
}
