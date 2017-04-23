using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace Aapi.Seminars.Extensions
{
    public static class DbContextExtensions
    {
        public static void QueryAnObjectOnEachModel(this DbContext self)
        {
            var queryablePropertyInfos = self.GetType().GetProperties()
                .Where(x => x.PropertyType.IsConstructedGenericType)
                .Where(x => x.PropertyType.GetInterfaces().Any(y => y.GetGenericTypeDefinition() == typeof(IQueryable<>)))
                .ToList();

            Assert.AreNotEqual(0, queryablePropertyInfos.Count);

            foreach(var queryablePropertyInfo in queryablePropertyInfos)
            {
                var entityType = queryablePropertyInfo.PropertyType.GetInterfaces()
                    .Where(x => x.IsConstructedGenericType && x.GetGenericTypeDefinition() == typeof(IQueryable<>))
                    .Select(x => x.GetGenericArguments().First()).FirstOrDefault();
                if (entityType == null)
                {
                    throw new Exception("Could not find an IQueryable<>.");
                }
                var queryable = (IQueryable<object>)self.GetType()
                    .GetMethod("Set").MakeGenericMethod(entityType)
                    .Invoke(self, null);
                var data = queryable
                    .Take(2)
                    .ToList();
                Assert.IsNotNull(data);
            }
        }
    }
}
