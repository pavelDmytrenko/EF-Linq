using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EF_linq
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public ICollection<Photos> Photos { get; set; }
        public Users()
        {
            Photos = new List<Photos>();
        }
    }
}
