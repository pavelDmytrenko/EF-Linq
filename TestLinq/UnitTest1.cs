using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using EF_linq;

namespace TestLinq
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            /*using (UserContext db = new UserContext())
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

               //    List<ResultCollections> resCol = new List<ResultCollections>();
               */
            DBOperation dBOperation = new DBOperation();
            var resItem = dBOperation.SelectItem();

            Assert.Equal(2, resItem.Count/*resCol.Where(x=>x.UserId == 1).Select(x=>x.Count).First()*/); ;
            
        }
    }
}
