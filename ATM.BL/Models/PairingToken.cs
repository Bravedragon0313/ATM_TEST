using ATM.BL.Models.Common;
using System;

namespace ATM.BL.Models
{
    /// <summary>
    /// PairingToken
    /// </summary>
    public class PairingToken : BaseEntity
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
    }
}


