using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGT.Services.Core.Data
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);



    public class EventWithBrandingCreationResponse
    {
        public class Data
        {
            public int id { get; set; }
            public string code { get; set; }
        }

        public int status { get; set; }
        public string message { get; set; }
        public int timestamp { get; set; }
        public Data data { get; set; }
    }


}
