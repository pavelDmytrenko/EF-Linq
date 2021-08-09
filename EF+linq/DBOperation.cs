using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_linq
{
    public class DBOperation
    {
        public List<ResultItem> SelectItem(DateTime DateFrom)
        {
            using (UserContext db = new UserContext())
            { 
                List<ResultItem> resItem = db.Users.Select(u =>
                        new ResultItem
                        {
                            UserId = u.UserId,
                            Name = u.Name,
                            Count = u.Photos.Select(p => p.Likes.Where(l =>l.CreatedDate >= DateFrom )).Sum(l => l.Count())
                        }).ToList();

                resItem.OrderByDescending(l => l.Count);
                return resItem;
            }
        }
    }
}
