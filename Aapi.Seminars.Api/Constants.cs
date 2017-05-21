using Aapi.Seminars.Api;
using System.Reflection;

namespace Aapi.Seminars
{
    public static class Constants
    {
        public static Assembly AapiSeminarsApiAssembly => typeof(Program).GetTypeInfo().Assembly;
    }
}
