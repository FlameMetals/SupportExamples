using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FFM.DataAccessModels.App
{
    public class orderPartsHeader : tableHeaderParent
    {
        //ID of the ordersHeader
        [Column(Order = 200)]
        [Display(Name = "ID of the orders Header")]
        public System.Guid ordersHeaderId { get; set; }
        [ForeignKey("ordersHeaderId")]
        public virtual ordersHeader ordersHeader { get; set; }

        // Order Line Number
        [Column("lineNumber", Order = 201)]
        [Display(Name = "lineNumber")]
        public int lineNumber { get; set; }

        public List<orderParts> orderParts { get; set; }
        public List<orderPartProcesses> orderPartProcesses { get; set; }
    }
}
