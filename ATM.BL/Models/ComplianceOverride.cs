using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    public class ComplianceOverride : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime OverrideAt { get; set; }
        public string OverrideBy { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerToken OverrideByNavigation { get; set; }
    }
}
