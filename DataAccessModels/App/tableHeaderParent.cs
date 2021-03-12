using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FFM.DataAccessModels.App
{
    [Index(nameof(isDeleted), IsUnique = false)]
    public abstract class tableHeaderParent
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

        // A Bool with the name of the bitRecordActive used to disable a Recipient
        [Column("isActive", Order = 3)]
        [Display(Name = "Is Active")]
        [Required]
        public bool isActive { get; set; } = true;

        //A Bool with the name of the bitRecordDeleted used to delete a record
        [Column("isDeleted", Order = 4)]
        [Display(Name = "Is Deleted")]
        public bool? isDeleted { get; set; } = false;

        //The date the record was Updated
        [Column("lastModifiedOnDate", Order = 8)]
        [Display(Name = "Last Modified On Date")]
        public DateTime? lastModifiedOnDate { get; set; } = DateTime.UtcNow;

        //User ID of the user who Updated the record
        [Column("lastModifiedByUserId", Order = 9)]
        [Display(Name = "Last Modified By User ID")]
        public Guid? lastModifiedByUserId { get; set; }

        //User IP Address of the user who Updated the record
        [Column("lastModifiedByIp", Order = 10)]
        [MaxLength(50)]
        [Display(Name = "Last Modified By IP")]
        public string lastModifiedByIp { get; set; }

        //The date the record was Deleted
        [Column("deletedOnDate", Order = 11)]
        [Display(Name = "Deleted On Date")]
        public DateTime? deletedOnDate { get; set; }

        //User ID of the user who Deleted the record
        [Column("deletedByUserId", Order = 12)]
        [Display(Name = "Deleted By User ID")]
        public Guid? deletedByUserId { get; set; }

        //User IP Address of the user who Deleted the record
        [Column("deletedByIp", Order = 13)]
        [MaxLength(50)]
        [Display(Name = "Deleted By IP")]
        public string deletedByIp { get; set; }

        //The date the record was Approved
        [Column("approvedRejectedOnDate", Order = 14)]
        [Display(Name = "Approved Rejected On Date")]
        public DateTime? approvedRejectedOnDate { get; set; }

        //User ID of the user who Approved the record
        [Column("approvedRejectedByUserId", Order = 15)]
        [Display(Name = "Approved Rejected By User ID")]
        public Guid? approvedRejectedByUserId { get; set; }

        //User IP Address of the user who deleted the record
        [Column("approvedRejectedByIp", Order = 16)]
        [MaxLength(50)]
        [Display(Name = "Approved Rejected By IP")]
        public string approvedRejectedByIp { get; set; }


        //_End Of Header____________________________________________//
    }
}
