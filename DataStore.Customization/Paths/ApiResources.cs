using System;
using System.Collections.Generic;
using System.Text;

namespace DataStore.Customization.Paths
{
    public static class ApiResources
    {
        public static readonly string EndpointPath = "https://mobileapp.jazz.com.pk/";
        public static readonly string RootPath = "api/v1.0/";

        public static readonly string Login = $"{EndpointPath}{RootPath}Login";
        public static readonly string Signup = $"{EndpointPath}{RootPath}Signup";

        public static readonly string Test_GETAPI = $"https://jsonplaceholder.typicode.com/users";
        public static readonly string Test_POSTAPI = $"http://dummy.restapiexample.com/api/v1/create";
    }
}
