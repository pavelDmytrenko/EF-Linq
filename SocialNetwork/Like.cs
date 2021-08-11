using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork
{
    [Table("Likes")]
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        public DateTime CreatedDate { get; set; }


        public int? PhotoId { get; set; }
        public Photo Photos { get; set; }

    }
}
