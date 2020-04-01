using System.ComponentModel.DataAnnotations;

namespace ATM.BL.Models.Common
{
    /// <summary>
    /// Base Entity
    /// </summary>
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
