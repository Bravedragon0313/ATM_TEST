using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    public class CashInTx : BaseEntity
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
        public string ToAddress { get; set; }
        public decimal CryptoAtoms { get; set; }
        public string CryptoCode { get; set; }
        public decimal Fiat { get; set; }
        public string FiatCode { get; set; }
        public long? Fee { get; set; }
        public string TxHash { get; set; }
        public string Phone { get; set; }
        public string Error { get; set; }
        public DateTime Created { get; set; }
        public bool Send { get; set; }
        public bool SendConfirmed { get; set; }
        public bool Timedout { get; set; }
        public DateTime? SendTime { get; set; }
        public string ErrorCode { get; set; }
        public bool OperatorCompleted { get; set; }
        public bool SendPending { get; set; }
        public decimal CashInFee { get; set; }
        public decimal CashInFeeCrypto { get; set; }
        public int MinimumTx { get; set; }
        public int TxVersion { get; set; }
        public bool TermsAccepted { get; set; }
        public decimal? CommissionPercentage { get; set; }
        public decimal? RawTickerPrice { get; set; }
        public bool? IsPaperWallet { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
