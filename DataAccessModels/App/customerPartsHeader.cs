
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FFM.DataAccessModels.App
{
    public class customerPartsHeader : tableHeaderParent
    {
        public List<customerParts> customerParts { get; set; }
        public List<customerPartImages> customerPartImages { get; set; }
    }
}
