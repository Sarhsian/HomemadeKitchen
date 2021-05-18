using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CasualShop.DAL.Entities
{
    [Table("Categories_tbl")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Dishes> Dishess { get; set; }
        public Category()
        {
            Dishess = new List<Dishes>();
        }

    }
}
