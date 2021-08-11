using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_linq
{
    public interface IDbContext
    {
        DbSet<User> User { get; set; }
        DbSet<Photo> Photo { get; set; }
        DbSet<Like> Like { get; set; }
        int SaveChanges();
    }
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
