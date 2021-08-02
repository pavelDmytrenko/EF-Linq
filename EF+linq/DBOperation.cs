using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_linq
{
    public class DBOperation
    {
        #region output
        /*
        foreach (Likes pl in db.Likes)
       Console.WriteLine(pl.LikeId+" "+pl.PhotoId+" "+pl.CreatedDate);
        Console.WriteLine();
        // вывод 
        foreach (Photos ph in db.Photos)
            Console.WriteLine(ph.PhotoId + " " + ph.UserId + " " + ph.CreatedDate);
        Console.WriteLine();
        Console.WriteLine();
        */
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

        /*foreach (Users t in db.Users)
        {
             ResultItem rc = new ResultItem { UserId = t.UserId, Name = t.Name, Count = t.Photos.Select(x => new { likes = x.Likes.Where(y => y.CreatedDate > new DateTime(2021, 6, 28)) }).Sum(x => x.likes.Count()) };
            //t.Photos.Select(x => x.Likes.Where(y => y.CreatedDate > new DateTime(2021, 6, 28))) };//Sum(x => x.Count)
             resCol.Add(rc);
        }
        */
        public List<ResultItem> SelectItem()
        {
            using (UserContext db = new UserContext())
            {
                List<ResultItem> resItem = new List<ResultItem>();
                resItem = db.Users.Select(u =>
                        new ResultItem
                        {
                            UserId = u.UserId,
                            Name = u.Name,
                            Count =
                        u.Photos.Select(x => new { likes = x.Likes.Where(y => y.CreatedDate > new DateTime(2021, 6, 28)) })
                        .Sum(x => x.likes.Count())
                        }).ToList();

                resItem.OrderByDescending(x => x.Count);
                return resItem;
            }
        }
        /*        Console.WriteLine(resItem.Count);
                foreach (var res in resItem)
                Console.WriteLine(res.UserId + "  " + res.Name + " " + res.Count);
                */
    }
}
