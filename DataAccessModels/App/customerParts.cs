using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FFM.DataAccessModels.App
{
    [Index(nameof(userfriendlyName), IsUnique = false)]
    public class customerParts : tableHeaderChild
    {
        //ID of the customerPartsHeader
        [Column(Order = 200)]
        [Display(Name = "ID of the customerParts Header")]
        public System.Guid customerPartsHeaderId { get; set; }
        [ForeignKey("customerPartsHeaderId")]
        public virtual customerPartsHeader customerPartsHeader { get; set; }

        //ID of the customerLocationsHeader
        //[Column(Order = 200)]
        //[Display(Name = "ID of the customerLocations Header")]
        //public System.Guid customerLocationsHeaderId { get; set; }
        //[ForeignKey("customerLocationsHeaderId")]
        //public virtual customerLocationsHeader customerLocationsHeader { get; set; }


        //Name of the Customer Part
        [Column("userfriendlyName", Order = 201)]
        [MaxLength(255)]
        [Display(Name = "user friendly Name")]
        public string userfriendlyName { get; set; }


        //Name
        [Column("name", Order = 201)]
        [MaxLength(255)]
        [Display(Name = "name")]
        public string name { get; set; }


        //Description
        [Column("description", Order = 201)]
        [MaxLength(255)]
        [Display(Name = "description")]
        public string description { get; set; }


        //public List<routeCustomerParts> routeCustomerParts { get; set; }
        //public List<orderParts> orderParts { get; set; }

    }
}
