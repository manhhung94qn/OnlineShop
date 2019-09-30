using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string CategotyName { get; set; }
        public int Status { get; set; }
        public long? ParentId { get; set; }
        public string Deatail { get; set; }
        public string AvatarMain { get; set; }
        public string AvatarSeconde { get; set; }
        public DateTime CratedDate { get; set; }
        public long CreateBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
