using ATM.BL.Models.Common;
using System;

namespace ATM.BL.Models
{
    /// <summary>
    /// CashInAction
    /// </summary>
    public class CashInAction : BaseEntity
    {
        public Guid TxId { get; set; }
        public string Action { get; set; }
        public string Error { get; set; }
        public string ErrorCode { get; set; }
        public string TxHash { get; set; }
        public DateTime Created { get; set; }
    }
}
