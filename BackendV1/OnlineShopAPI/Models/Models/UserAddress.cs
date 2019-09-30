using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class UserAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        public string Street { get; set; }
        public long? District { get; set; }
        public long? City { get; set; }
        public long? National { get; set; }
        public string Other { get; set; }
        public bool? MainAdress { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
