using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EF_linq
{
    [Table("Likes")]
    public class Likes
    {
        [Key]
        public int LikeId { get; set; }
        public DateTime CreatedDate { get; set; }


        public int? PhotoId { get; set; }
        public Photos Photos { get; set; }

    }
}
