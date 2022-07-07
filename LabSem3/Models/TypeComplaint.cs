using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabSem3.Models
{
    public class TypeComplaint
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeRole { get; set; }
        public int ComplaintId { get; set; }
        [ForeignKey("ComplaintId")]
        public virtual List<Complaint> Complaints { get; set; }
    }
}