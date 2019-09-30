using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class ProductSpecification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Len { get; set; }
        public string Quality { get; set; }
        public string Connect { get; set; }
        public string Storage { get; set; }
        public string Power { get; set; }
        public string Size { get; set; }
        public string Resolution { get; set; }//Do phan giai
        public string Guarantee { get; set; } //bao hanh
        public string Other { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
