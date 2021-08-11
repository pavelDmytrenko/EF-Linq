using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    public interface IDbContext
    {
        DbSet<User> User { get; set; }
        DbSet<Photo> Photo { get; set; }
        DbSet<Like> Like { get; set; }
        int SaveChanges();
    }
}
