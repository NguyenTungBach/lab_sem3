using LabSem3.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabSem3.Models
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }
        public int Row { get; set; }
        public int Colunm { get; set; }
        public double Price { get; set; }
        public DateTime? BookingDate { get; set; }
        public int Status { get; set; }
    }
}