using System.Collections.Generic;

namespace RGT.Services.Core.Data
{

    public class RadioUsersResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public int timestamp { get; set; }
        public Request request { get; set; }
        public List<RadioUser> data { get; set; }

        public class RadioUser
        {
            public int id { get; set; }
            public string fname { get; set; }
            public string lname { get; set; }
        }

        public class Request
        {
            public string race_id { get; set; }
        }

    }


}
