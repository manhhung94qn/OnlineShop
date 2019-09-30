using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string AvatarMain { get; set; }
        public string AvatarSeconde { get; set; }
        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }
        public Decimal Price { get; set; }
        public Decimal? PromotionPrice { get; set; }
        public long? CategoryId { get; set; }
        public long? BrandId { get; set; }
        public int? Status { get; set; }
        public long? ViewCount { get; set; }
        public string Detail { get; set; }
        public DateTime CratedDate { get; set; }
        public long CreateBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public string MetaKeyWord { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
        public virtual IEnumerable<ProductRate> ProductRates { get; set; }
        public virtual IEnumerable<ProductFeedback> ProductFeedbacks { get; set; }
        public virtual IEnumerable<ProductSpecification> ProductSpecifications { get; set; }
    }
}
