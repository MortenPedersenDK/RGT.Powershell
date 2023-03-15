namespace RGT.Services.Core.Data
{
    public class LoginResponse
    {
        public int status { get; set; }
        public string? message { get; set; }
        public class Data
        {
            public string? token { get; set; }
            public string? uuid { get; set; }
        }

        public Data? data { get; set; }
    }
}
