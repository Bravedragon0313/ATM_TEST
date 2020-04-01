using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    public class SanctionsLog : BaseEntity
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
        public string SanctionedId { get; set; }
        public string SanctionedAliasId { get; set; }
        public string SanctionedAliasFullName { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Created { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
