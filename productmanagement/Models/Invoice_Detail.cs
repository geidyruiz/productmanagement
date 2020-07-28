using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace productmanagement.Models
{
    public class Invoice_Detail
    {
        
        [Key]
        public int Invoice_Detail_Number{ get; set; }
        [Column(TypeName = "int")]
        [Required]
        public int Invoice_Number { get; set; }
        [Column(TypeName = "int")]
        public int ProductId { get; set; }
        [Column(TypeName = "int")]
        public int Quantity { get; set; }
        [Column(TypeName = "float")]
        public float Total_Price { get; set; }
    }
}
