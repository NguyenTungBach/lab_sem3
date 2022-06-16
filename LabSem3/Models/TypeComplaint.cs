using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabSem3.Models
{
    public class TypeComplaint
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}