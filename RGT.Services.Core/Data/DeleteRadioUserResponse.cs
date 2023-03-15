namespace RGT.Services.Core.Data
{
    public class Request
    {
        public string race_id { get; set; }
        public string user_id { get; set; }
    }

    public class DeleteRadioUserResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public int timestamp { get; set; }
        public Request request { get; set; }
        public object data { get; set; }
    }
}
