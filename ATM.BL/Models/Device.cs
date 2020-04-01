using ATM.BL.Models.Common;
using System;

namespace ATM.BL.Models
{
    /// <summary>
    /// Device
    /// </summary>
    public class Device : BaseEntity
    {
        public string DeviceId { get; set; }
        public int Cashbox { get; set; }
        public int Cassette1 { get; set; }
        public int Cassette2 { get; set; }
        public bool? Paired { get; set; }
        public bool? Display { get; set; }
        public DateTime Created { get; set; }
        public int? UserConfigId { get; set; }
        public string Name { get; set; }
        public DateTime LastOnline { get; set; }
        public string Location { get; set; }

        public virtual DeviceConfig DeviceConfig { get; set; }
    }
}
