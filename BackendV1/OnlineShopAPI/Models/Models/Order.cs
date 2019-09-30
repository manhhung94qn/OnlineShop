using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
