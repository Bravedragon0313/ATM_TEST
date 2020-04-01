using System;

namespace ATM.BL.Models
{
    /// <summary>
    /// Bill
    /// </summary>
    public class Bill
    {
        public Guid Id { get; set; }
        public int Fiat { get; set; }
        public string FiatCode { get; set; }
        public decimal CryptoAtoms { get; set; }
        public Guid CashInTxsId { get; set; }
        public long DeviceTime { get; set; }
        public DateTime Created { get; set; }
        public string CryptoCode { get; set; }
        public decimal CashInFee { get; set; }
        public decimal CashInFeeCrypto { get; set; }
        public decimal CryptoAtomsAfterFee { get; set; }
    }
}
