using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    public class UserContext: DbContext, IDbContext
    {
        public UserContext()
            : base("DbConnection")
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Like> Like { get; set; }
 
    }
}
