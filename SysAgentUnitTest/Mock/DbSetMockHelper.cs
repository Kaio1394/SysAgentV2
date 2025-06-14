using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SysAgentUnitTest.Mock
{
    public static class DbSetMockHelper
    {
        public static Mock<DbSet<T>> CreateMockSet<T>(IEnumerable<T> data) where T: class
        {
            var queryable = data.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>()))
            .ReturnsAsync((object[] ids) => queryable.FirstOrDefault(e =>
                (int)e.GetType().GetProperty("Id").GetValue(e) == (int)ids[0]));

            return mockSet;
        }
    }
}
