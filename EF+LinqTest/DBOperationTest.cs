using System;
using Xunit;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EF_linq;

namespace TestLinq
{
    public class DBOperationTest
    {
        DBOperation dBOperation = new DBOperation();

        [Fact]
        public void DBOperationTestCountUsers()
        {
            Assert.Equal(2, dBOperation.SelectItem(Convert.ToDateTime(DateTime.Today.AddMonths(-1))).Count);
        }
        [Fact]
        public void DBOperationTestCountLikes()
        {
            Assert.Equal(0, dBOperation.SelectItem(Convert.ToDateTime(DateTime.Today.AddMonths(-1))).Where(x => x.UserId == 1).Select(x => x.Count).First());
        }
        [Fact]
        public void DBOperationTestPeriod()
        {
            Assert.Equal(3, dBOperation.SelectItem(Convert.ToDateTime(DateTime.Today.AddMonths(-1))).Where(x => x.UserId == 1).Select(x => x.Count).First());
            var resItemMoreMonth = dBOperation.SelectItem(Convert.ToDateTime(DateTime.Today.AddMonths(-2)));
            Assert.Equal(3, resItemMoreMonth.Where(x => x.UserId == 1).Select(x => x.Count).First());
        }
    }
}
