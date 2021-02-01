using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Models
{
    public class WorkOrder
    {
        [Key]
        public int WorkOrderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        [ForeignKey("Listing")]
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
    }
}
