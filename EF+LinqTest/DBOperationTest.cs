using System;
using Xunit;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EF_linq;
using Moq;

namespace TestLinq
{
    public class DBOperationTest
    {
        public DBOperation GetDBContext()
        {
            var usersTestData = new List<User>()
            {
                                                new User
                                                {
                                                    UserId = 1,
                                                    Name = "Tom",
                                                    Photos = new List<Photo>() { new Photo
                                                                                            {
                                                                                                PhotoId = 1,
                                                                                                Context = "meeting",
                                                                                                CreatedDate = Convert.ToDateTime("2.8.2021"),
                                                                                                UserId = 1,
                                                                                                Likes = new List<Like>() { new Like { LikeId = 1, CreatedDate = Convert.ToDateTime("2/8/2021"), PhotoId = 1 },
                                                                                                                            new Like { LikeId = 2, CreatedDate = Convert.ToDateTime("2/8/2021"), PhotoId = 1 }}
                                                                                            },
                                                                                    new Photo
                                                                                            {
                                                                                                PhotoId = 2,
                                                                                                Context = "daily",
                                                                                                CreatedDate = Convert.ToDateTime("2.8.2021"),
                                                                                                UserId = 1,
                                                                                                Likes = new List<Like>() { new Like { LikeId = 3, CreatedDate = Convert.ToDateTime("2/8/2021"), PhotoId = 2 },
                                                                                                                            new Like { LikeId = 3, CreatedDate = Convert.ToDateTime("7/7/2021"), PhotoId = 2 }}
                                                                                            },
                                                                                    new Photo
                                                                                            {
                                                                                                PhotoId = 3,
                                                                                                Context = "dogs",
                                                                                                CreatedDate = Convert.ToDateTime("2.8.2021"),
                                                                                                UserId = 2,
                                                                                                Likes = new List<Like>() { }
                                                                                            }
                                                                                }
                                                },

                                                new User
                                                {
                                                    UserId = 2,
                                                    Name = "Sam",
                                                    Photos = new List<Photo>() { }
                                                }
            };
            var users = MockDbSet(usersTestData);
            //Set up mocks for db sets
            var dbContext = new Mock<IDbContext>();
            dbContext.Setup(m => m.User).Returns(users.Object);
            return new DBOperation(dbContext.Object);
        }

        Mock<DbSet<T>> MockDbSet<T>(IEnumerable<T> list) where T : class, new()
        {
            IQueryable<T> queryableList = list.AsQueryable();
            Mock<DbSet<T>> dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(() => queryableList.GetEnumerator());
            dbSetMock.Setup(x => x.Create()).Returns(new T());

            return dbSetMock;
        }

        [Fact]
        public void DBOperationTestCountUsers()
        {
            var dbContext = GetDBContext();
            //Act
            var results = dbContext.SelectItem(Convert.ToDateTime(DateTime.Today.AddMonths(-1)));
            //Assert
             Assert.Equal(2, results.Count);
        }

        [Fact]
        public void DBOperationTestCountLikes()
        {
            var dbContext = GetDBContext();
            //Act
            var results = dbContext.SelectItem(Convert.ToDateTime(DateTime.Today.AddMonths(-1))).Where(x => x.UserId == 1).Select(x => x.Count).First();
            //Assert
            Assert.Equal(3, results);
            //Assert.Equal(3, results2M.Where(x => x.UserId == 1).Select(x => x.Count).First());
        }
         
        [Fact]
        public void DBOperationTestPeriod()
        {
            var dbContext = GetDBContext();
            //Act
            var results = dbContext.SelectItem(Convert.ToDateTime(DateTime.Today.AddMonths(-1))).Where(x => x.UserId == 1).Select(x => x.Count).First();
            //Assert
            Assert.Equal(3, results);
            var resItemMoreMonth = dbContext.SelectItem(Convert.ToDateTime(DateTime.Today.AddMonths(-2))).Where(x => x.UserId == 1).Select(x => x.Count).First();
            Assert.Equal(3, resItemMoreMonth);
        }
        
    }
}
