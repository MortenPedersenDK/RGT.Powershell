namespace RGT.Services.Core.Data
{

    public class RoadMagicAttach
    {
        public class Request
        {
            public string code { get; set; }
        }
        public int status { get; set; }
        public string message { get; set; }
        public int timestamp { get; set; }
        public Request request { get; set; }
        public string data { get; set; }
    }
}
