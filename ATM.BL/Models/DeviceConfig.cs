using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    /// <summary>
    /// DeviceConfig
    /// </summary>
    public class DeviceConfig : BaseEntity
    {
        public DeviceConfig()
        {
            Devices = new HashSet<Device>();
        }

        public string Type { get; set; }
        public string Data { get; set; }
        public DateTime Created { get; set; }
        public bool Valid { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
