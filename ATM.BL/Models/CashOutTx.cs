using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    public class CashOutTx : BaseEntity
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
        public string ToAddress { get; set; }
        public decimal CryptoAtoms { get; set; }
        public string CryptoCode { get; set; }
        public decimal Fiat { get; set; }
        public string FiatCode { get; set; }
        public bool Dispense { get; set; }
        public bool Notified { get; set; }
        public bool Redeem { get; set; }
        public string Phone { get; set; }
        public string Error { get; set; }
        public DateTime Created { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public int? HdIndex { get; set; }
        public bool Swept { get; set; }
        public bool Timedout { get; set; }
        public bool? DispenseConfirmed { get; set; }
        public int? Provisioned1 { get; set; }
        public int? Provisioned2 { get; set; }
        public int? Denomination1 { get; set; }
        public int? Denomination2 { get; set; }
        public string ErrorCode { get; set; }
        public int TxVersion { get; set; }
        public DateTime? PublishedAt { get; set; }
        public bool TermsAccepted { get; set; }
        public string Layer2Address { get; set; }
        public decimal? CommissionPercentage { get; set; }
        public decimal? RawTickerPrice { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
