using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string BrandName { get; set; }
        public int Status { get; set; }
        public string AvatarMain { get; set; }
        public string AvatarSeconde { get; set; }
        public string Detail { get; set; }
        public DateTime CratedDate { get; set; }
        public long CreateBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long ModifiedBy { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
