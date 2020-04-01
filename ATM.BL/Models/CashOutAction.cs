using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    public class CashOutAction : BaseEntity
    {
        public int Id { get; set; }
        public Guid TxId { get; set; }
        public string Action { get; set; }
        public string ToAddress { get; set; }
        public string Error { get; set; }
        public string ErrorCode { get; set; }
        public string TxHash { get; set; }
        public int? Provisioned1 { get; set; }
        public int? Provisioned2 { get; set; }
        public int? Dispensed1 { get; set; }
        public int? Dispensed2 { get; set; }
        public int? Rejected1 { get; set; }
        public int? Rejected2 { get; set; }
        public int? Denomination1 { get; set; }
        public int? Denomination2 { get; set; }
        public bool Redeem { get; set; }
        public long? DeviceTime { get; set; }
        public DateTime Created { get; set; }
        public string Layer2Address { get; set; }
        public string DeviceId { get; set; }
    }
}
