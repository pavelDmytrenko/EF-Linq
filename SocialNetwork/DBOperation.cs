using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    public class DBOperation : IDBOperation
    {
        private readonly IDbContext _dbContext;
        public DBOperation(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ResultItem> SelectItem(DateTime DateFrom)
        {
                List<ResultItem> resItem = _dbContext.User.Select(u =>
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
