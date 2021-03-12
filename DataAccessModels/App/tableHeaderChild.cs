using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FFM.DataAccessModels.App
{
    [Index(nameof(createdOnDate), IsUnique = false)]
    public abstract class tableHeaderChild
    {
        //The ID of your object with the name of the Contacts
        [Key]
        [Column("id", Order = 0)]
        [Required]
        public Guid id { get; set; }


        //A byte[] with the name of the vBinChangeKey Change Key is used in some tables for recored change history. When the applaction requires advanced tracking.
        [Column("changeKey", Order = 2)]
        [Display(Name = "Change Key")]
        [Timestamp]
        public byte[] changeKey { get; set; }

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


        //_End Of Header____________________________________________//
    }
}
