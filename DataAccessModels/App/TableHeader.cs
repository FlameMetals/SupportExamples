using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FFM.DataAccessModels.App
{
    public abstract class tableHeader : tableHeaderParent
    {
        //The date the record was created
        [Column("createdOnDate", Order = 5)]
        [Display(Name = "Created On Date")]
        [Required]
        public DateTime createdOnDate { get; set; } = DateTime.UtcNow;

        //User ID of the user who created the record
        [Column("createdByUserId", Order = 6)]
        [Display(Name = "Created By User ID")]
        [Required]
        public Guid createdByUserId { get; set; }

        //User IP Address of the user who created the record
        [Column("createdByIp", Order = 7)]
        [MaxLength(50)]
        [Display(Name = "Created By IP")]
        [Required]
        public string createdByIp { get; set; }
    }
}
