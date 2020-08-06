using System;
using System.Collections.Generic;
using System.Text;

namespace DataStore.Customization.Paths
{
    // https://gorest.co.in/
    // API details about Features, Authentication, Response Codes
    
    public static class ApiResources
    {

#if DEBUG
        public static readonly string EndpointPath = "https://mobileapp.jazz.com.pk/";
        public static readonly string RootPath = "api/v1.0/";
#else
        public static readonly string EndpointPath = "https://mobileapp.jazz.com.pk/";
        public static readonly string RootPath = "api/v1.0/";
#endif

        public static readonly string Login = $"{EndpointPath}{RootPath}Login/";
        public static readonly string Signup = $"{EndpointPath}{RootPath}Signup/";

        public static readonly string Test_GETAPI = $"https://jsonplaceholder.typicode.com/users";
        public static readonly string Test_POSTAPI = $"http://dummy.restapiexample.com/api/v1/create";
        public static readonly string Test_PUTAPI = $"http://dummy.restapiexample.com/update/";
        public static readonly string Test_DELETEAPI = $"http://dummy.restapiexample.com/delete/";
    }
}
