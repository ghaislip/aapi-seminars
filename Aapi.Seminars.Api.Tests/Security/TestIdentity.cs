using System;
using System.Security.Principal;

namespace Aapi.Seminars.Security
{
    public class TestIdentity : IIdentity
    {
        public string AuthenticationType => "Integration Test";

        public bool IsAuthenticated => true;

        public string Name => "Test User";
    }
}
