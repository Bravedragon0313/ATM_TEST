using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    public class CashInRefill : BaseEntity
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
        public int UserId { get; set; }
        public int CashBoxCount { get; set; }
        public DateTime Created { get; set; }
    }
}
