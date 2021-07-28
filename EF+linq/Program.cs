using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UserContext db = new UserContext())
            {
                #region addNewDataToTables
                /*
                // создаем два объекта User
                Users user1 = new Users { Name = "Tom" };
                Users user2 = new Users { Name = "Sam" };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();

                Photos pl1 = new Photos { Context = "meeting", CreatedDate = DateTime.Now,  Users = user1 };
                Photos pl2 = new Photos { Context = "daily", CreatedDate = DateTime.Now,  Users = user1 };
                Photos pl3 = new Photos { Context = "dogs", CreatedDate = DateTime.Now,  Users = user2};
                db.Photos.AddRange(new List<Photos> { pl1, pl2, pl3 });
                db.SaveChanges();

                Likes lk1 = new Likes { CreatedDate = DateTime.Now, Photos = pl1 };
                Likes lk2 = new Likes { CreatedDate = DateTime.Now, Photos = pl1 };
                Likes lk3 = new Likes { CreatedDate = DateTime.Now, Photos = pl2 };
                db.Likes.AddRange(new List<Likes> { lk1, lk2, lk3 });
                db.SaveChanges();
                */
                #endregion

                #region output
                
                foreach (Likes pl in db.Likes)
               //    Console.WriteLine("{0} - {1}", pl.LikeId, pl.Photos != null ? pl.Photos.Context : "");
                Console.WriteLine();
                // вывод 
                foreach (Photos pl in db.Photos)
                //    Console.WriteLine("{0} - {1}", pl.PhotoId, pl.Users != null ? pl.Users.Name : "");
                Console.WriteLine();
              
                #endregion

                /*     var firstLeftJoin = db.Users.GroupJoin(
                                           (db.Users.GroupJoin(db.Photos, u => u.UserId, p => p.UserId, (u, p) => new { u, p })
                                               .SelectMany(x => x.p.DefaultIfEmpty(), (us, ph) =>
                                                   new { us.u.Name, us.u.UserId, upUserID = ph == null ? 0 : ph.UserId, PhotoID = ph == null ? 0 : ph.PhotoId, })
                                               .Join(db.Likes, f => f.PhotoID, l => l.PhotoId, (f, l) =>
                                                  new { f.Name, f.UserId, upPhoto = f.PhotoID, CreatedDate = l.CreatedDate })
                                               .Where(x => x.CreatedDate > new DateTime(2021, 6, 27))
                                               .GroupBy(p => new { p.UserId, p.Name })
                                               .Select(l => new { Name = l.Key.Name, UserId = l.Key.UserId, Count = l.Count(), })),
                                                   u => u.UserId, r => r.UserId, (u, r) => new { u, r })
                                           .SelectMany(x => x.r.DefaultIfEmpty(), (us, rs) =>
                                             new { us.u.Name, us.u.UserId, Count = rs == null ? 0 : rs.Count, })
                                           .OrderByDescending(x => x.Count);
                */
                List<ResultCollections> resCol = new List<ResultCollections>();
                foreach (Users t in db.Users)
                {
//var res = t.Photos.Select(x => new { likes = x.Likes.Where(y => y.CreatedDate > new DateTime(2021, 6, 28)) }).Sum(x=>x.likes.Count());
                   // var res2 = t.Photos.Where(x=>x.);
                //    Console.WriteLine(res + t.Name);
                    //foreach (var r in res)
                    //   Console.WriteLine("{0} - {1} - {2}", r.Select(x=>x.Photos.Use, t.Name, r.);
                      ResultCollections rc = new ResultCollections { UserId = t.UserId, Name = t.Name, Count = t.Photos.Select(x => new { likes = x.Likes.Where(y => y.CreatedDate > new DateTime(2021, 6, 28)) }).Sum(x => x.likes.Count()) };
                    //t.Photos.Select(x => x.Likes.Where(y => y.CreatedDate > new DateTime(2021, 6, 28))) };//Sum(x => x.Count)
                     resCol.Add(rc);
                                                                                                           //   Console.WriteLine("{0} - {1} - {2}", t.UserId, t.Name, cnt);
            }
                

                    resCol.OrderByDescending(x=>x.Count);
                    foreach (var res in resCol)
                    Console.WriteLine(res.UserId + "  " + res.Name + " " + res.Count);
            }
             Console.Read();
        }
    }
}
