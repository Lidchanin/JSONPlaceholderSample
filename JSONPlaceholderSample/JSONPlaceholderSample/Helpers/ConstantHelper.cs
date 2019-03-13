using System;

namespace JSONPlaceholderSample.Helpers
{
    public static class ConstantHelper
    {
        public const string ServiceUrl = "https://jsonplaceholder.typicode.com/";

        public static readonly TimeSpan ServiceTimeout = new TimeSpan(0,0,1,0);

        public const string DashboardPageTitle = "Dashboard";
        public const string UsersPageTitle = "Users";

        public const string Loading = "Loading";
        public const string Error = "Error";
        public const string Ok = "OK";
    }
}