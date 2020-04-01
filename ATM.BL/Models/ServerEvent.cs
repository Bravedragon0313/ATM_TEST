using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    /// <summary>
    /// ServerEvent
    /// </summary>
    public class ServerEvent : BaseEntity
    {
        public string EventType { get; set; }
        public DateTime Created { get; set; }
    }
}
