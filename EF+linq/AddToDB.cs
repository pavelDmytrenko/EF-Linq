using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_linq
{
    public class AddToDB
    {
        public void AddToDb()
        {
            using (UserContext db = new UserContext())
            {
                // создаем два объекта User
                Users user1 = new Users { Name = "Tom" };
                Users user2 = new Users { Name = "Sam" };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();

                Photos pl1 = new Photos { Context = "meeting", CreatedDate = DateTime.Now, Users = user1 };
                Photos pl2 = new Photos { Context = "daily", CreatedDate = DateTime.Now, Users = user1 };
                Photos pl3 = new Photos { Context = "dogs", CreatedDate = DateTime.Now, Users = user2 };
                db.Photos.AddRange(new List<Photos> {pl1, pl2, pl3
                        });
                db.SaveChanges();

                Likes lk1 = new Likes { CreatedDate = DateTime.Now, Photos = pl1 };
                Likes lk2 = new Likes { CreatedDate = DateTime.Now, Photos = pl1 };
                Likes lk3 = new Likes { CreatedDate = DateTime.Now, Photos = pl2 };
                db.Likes.AddRange(new List<Likes> { lk1, lk2, lk3 });
                db.SaveChanges();
            }

        }
    }
}