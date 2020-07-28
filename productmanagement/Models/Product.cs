using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace productmanagement.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Brand { get; set; }
        [Column(TypeName = "float")]
        public float Price { get; set; }

    }
}
