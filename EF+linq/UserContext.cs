using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_linq
{
    class UserContext: DbContext
    {
        public UserContext()
            : base("DbConnection")
        { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Photos> Photos { get; set; }
        public DbSet<Likes> Likes { get; set; }
    }
}
