using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    public class CashOutRefill : BaseEntity
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
        public int UserId { get; set; }
        public int Cassette1 { get; set; }
        public int Cassette2 { get; set; }
        public int Denomination1 { get; set; }
        public int Denomination2 { get; set; }
        public DateTime Created { get; set; }
    }
}
