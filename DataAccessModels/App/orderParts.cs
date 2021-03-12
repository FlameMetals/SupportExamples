using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FFM.DataAccessModels.App
{
    [Index(nameof(userfriendlyName), IsUnique = false)]
    [Index(nameof(orderQty), IsUnique = false)]
    [Index(nameof(orderWt), IsUnique = false)]
    public class orderParts : tableHeaderChild
    {
        // ID of the orderPartsHeader
        [Column(Order = 200)]
        [Display(Name = "ID of the orderParts Header")]
        public System.Guid orderPartsHeaderId { get; set; }
        [ForeignKey("orderPartsHeaderId")]
        public virtual orderPartsHeader orderPartsHeader { get; set; }

        // ID of the orderPartsHeader
        [Column(Order = 201)]
        [Display(Name = "Id of the customer parts child item")]
        public System.Guid customerPartsId { get; set; }
        [ForeignKey("customerPartsId")]
        public virtual customerParts customerParts { get; set; }

        // Name of the Order Part
        [Column("userfriendlyName", Order = 202)]
        [MaxLength(50)]
        [Display(Name = "user friendly Name")]
        public string userfriendlyName { get; set; }

        // Order Part Qty
        [Column("orderQty", Order = 203)]
        [Display(Name = "orderQty")]
        public int? orderQty { get; set; }

        // Order Part Wt
        [Column("orderWt", Order = 204, TypeName = "decimal(18, 3)")]
        [Display(Name = "orderWt")]
        public decimal? orderWt { get; set; }
    }
}
