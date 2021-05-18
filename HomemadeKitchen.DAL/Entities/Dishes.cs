using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CasualShop.DAL.Entities
{
    [Table("Dishes_tbl")]
    public class Dishes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? TagId { get; set; }
        public Tag Tag { get; set; }
        public int? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
