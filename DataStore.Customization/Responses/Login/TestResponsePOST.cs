using System;
using System.Collections.Generic;
using System.Text;

namespace DataStore.Customization.Responses.Login
{
    public class TestResponsePOST
    {
        public string status { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string name { get; set; }
        public string salary { get; set; }
        public string age { get; set; }
        public string id { get; set; }
    }
}
