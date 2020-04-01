using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    /// <summary>
    /// Customer
    /// </summary>
    public class Customer : BaseEntity
    {
        public Customer()
        {
            CashInTxs = new HashSet<CashInTx>();
            CashOutTxs = new HashSet<CashOutTx>();
            ComplianceOverrides = new HashSet<ComplianceOverride>();
            SanctionsLogs = new HashSet<SanctionsLog>();
            AuthenticationMessage = new HashSet<AuthenticationMessage>();
        }

        public Guid Id { get; set; }
        public string Phone { get; set; }
        public DateTime? PhoneAt { get; set; }
        public string IdCardDataNumber { get; set; }
        public DateTime? IdCardDataExpiration { get; set; }
        public string IdCardData { get; set; }
        public DateTime? IdCardDataAt { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool? Sanctions { get; set; }
        public string FrontCameraPath { get; set; }
        public DateTime? FrontCameraAt { get; set; }
        public string IdCardPhotoPath { get; set; }
        public DateTime? IdCardPhotoAt { get; set; }
        public DateTime Created { get; set; }
        public string SmsOverrideBy { get; set; }
        public DateTime? SmsOverrideAt { get; set; }
        public string IdCardDataOverrideBy { get; set; }
        public DateTime? IdCardDataOverrideAt { get; set; }
        public string IdCardPhotoOverrideBy { get; set; }
        public DateTime? IdCardPhotoOverrideAt { get; set; }
        public string FrontCameraOverrideBy { get; set; }
        public DateTime? FrontCameraOverrideAt { get; set; }
        public string SanctionsOverrideBy { get; set; }
        public DateTime? SanctionsOverrideAt { get; set; }
        public string AuthorizedOverrideBy { get; set; }
        public DateTime? AuthorizedOverrideAt { get; set; }
        public DateTime? AuthorizedAt { get; set; }
        public DateTime? SanctionsAt { get; set; }

        public virtual CustomerToken AuthorizedOverrideByNavigation { get; set; }
        public virtual CustomerToken FrontCameraOverrideByNavigation { get; set; }
        public virtual CustomerToken IdCardDataOverrideByNavigation { get; set; }
        public virtual CustomerToken IdCardPhotoOverrideByNavigation { get; set; }
        public virtual CustomerToken SanctionsOverrideByNavigation { get; set; }
        public virtual CustomerToken SmsOverrideByNavigation { get; set; }
        public virtual ICollection<CashInTx> CashInTxs { get; set; }
        public virtual ICollection<CashOutTx> CashOutTxs { get; set; }
        public virtual ICollection<ComplianceOverride> ComplianceOverrides { get; set; }
        public virtual ICollection<SanctionsLog> SanctionsLogs { get; set; }
        public virtual ICollection<AuthenticationMessage> AuthenticationMessage { get; set; }
    }
}
