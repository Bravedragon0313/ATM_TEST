using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    public class Trade : BaseEntity
    {
        public string CryptoCode { get; set; }
        public decimal CryptoAtoms { get; set; }
        public string FiatCode { get; set; }
        public DateTime Created { get; set; }
        public string Error { get; set; }
    }
}
