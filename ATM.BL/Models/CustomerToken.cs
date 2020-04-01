using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    /// <summary>
    /// CustomerToken
    /// </summary>
    public class CustomerToken : BaseEntity
    {
        public CustomerToken()
        {
            ComplianceOverrides = new HashSet<ComplianceOverride>();
            CustomersAuthorizedOverrideByNavigation = new HashSet<Customer>();
            CustomersFrontCameraOverrideByNavigation = new HashSet<Customer>();
            CustomersIdCardDataOverrideByNavigation = new HashSet<Customer>();
            CustomersIdCardPhotoOverrideByNavigation = new HashSet<Customer>();
            CustomersSanctionsOverrideByNavigation = new HashSet<Customer>();
            CustomersSmsOverrideByNavigation = new HashSet<Customer>();
        }

        public string Token { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<ComplianceOverride> ComplianceOverrides { get; set; }
        public virtual ICollection<Customer> CustomersAuthorizedOverrideByNavigation { get; set; }
        public virtual ICollection<Customer> CustomersFrontCameraOverrideByNavigation { get; set; }
        public virtual ICollection<Customer> CustomersIdCardDataOverrideByNavigation { get; set; }
        public virtual ICollection<Customer> CustomersIdCardPhotoOverrideByNavigation { get; set; }
        public virtual ICollection<Customer> CustomersSanctionsOverrideByNavigation { get; set; }
        public virtual ICollection<Customer> CustomersSmsOverrideByNavigation { get; set; }
    }
}
