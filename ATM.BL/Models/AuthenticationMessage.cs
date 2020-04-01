using System;

namespace ATM.BL.Models
{
    /// <summary>
    /// Authentication Message
    /// </summary>
    public class AuthenticationMessage
    {

        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Data { get; set; }
        public virtual Device Device { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual bool IsUsed { get; set; }
    }
}