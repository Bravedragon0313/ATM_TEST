

using ATM.BL.Models.Common;
using System.Collections.Generic;
using System;

namespace ATM.BL.Models
{
    public class Migrations : BaseEntity
    {
        public int Id { get; set; }
        public string Data { get; set; }
    }
}

