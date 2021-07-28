using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EF_linq
{
    [Table("Photos")]
    public class Photos
    {
        [Key]
        public int PhotoId { get; set; }
        public string Context { get; set; }
        public DateTime CreatedDate { get; set; }

        public int? UserId { get; set; }
        public Users Users { get; set; }

        public ICollection<Likes> Likes { get; set; }
        public Photos()
        {
            Likes = new List<Likes>();
        }
    }
}
