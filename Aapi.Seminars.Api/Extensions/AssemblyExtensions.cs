using Aapi.Seminars.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Aapi.Seminars.Extensions
{
    public static class AssemblyExtensions
    {
        public static IList<Type> GetAllControllerTypes(this Assembly self)
        {
            return self
                .GetTypes()
                .Where(x => typeof(AapiSeminarsControllerBase).IsAssignableFrom(x))
                .Where(x => !x.GetTypeInfo().IsAbstract)
                .ToList();
        }
    }
}
