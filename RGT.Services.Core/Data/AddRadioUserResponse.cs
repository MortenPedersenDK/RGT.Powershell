namespace RGT.Services.Core.Data
{

    public class AddRadioUserResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public int timestamp { get; set; }
        public Request request { get; set; }
        public Data data { get; set; }

        public class Data
        {
            public int id { get; set; }
            public string fname { get; set; }
            public string lname { get; set; }
        }

        public class Request
        {
            public int race_id { get; set; }
            public string email { get; set; }
        }

    }

}
