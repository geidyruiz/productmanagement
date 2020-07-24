using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace productmanagement.Models
{
    public class Invoice
    {
        [Key]
        public int Invoice_Number { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]

        public string Date { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Client_Invoice { get; set; }
        [Column(TypeName = "float")]

        public float Sub_Total_Invoice { get; set; }
        [Column(TypeName = "float")]
        public float Total_Invoice { get; set; }



    }
}
