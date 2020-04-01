using System;
using ATM.BL.Models.Common;

namespace ATM.BL.Models
{
    /// <summary>
    /// User
    /// </summary>
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
