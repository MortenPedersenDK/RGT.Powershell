using System.Collections.Generic;

namespace RGT.Services.Core.Data
{

    public class RoadsMagicResponse
    {
        public class Country
        {
            public int id { get; set; }
            public string name { get; set; }
            public string code1 { get; set; }
            public string code2 { get; set; }
            public int hidden { get; set; }
        }

        public class Road
        {
            public int id { get; set; }
            public string name { get; set; }
            public string gen_scene { get; set; }
            public string label { get; set; }
            public string description { get; set; }
            public int validated { get; set; }
            public int length { get; set; }
            public int elevation { get; set; }
            public double avg_slope { get; set; }
            public int country_id { get; set; }
            public Country country { get; set; }
            public string banner_url { get; set; }
            public int processed { get; set; }
            public int nodes_version { get; set; }
            public int created_at { get; set; }
            public object user_uuid { get; set; }
            public object user_id { get; set; }
            public int shape { get; set; }
            public int has_assets { get; set; }
            public double top_left_lat { get; set; }
            public double top_left_long { get; set; }
            public double bot_right_lat { get; set; }
            public double bot_right_long { get; set; }
            public double map_width { get; set; }
            public double map_height { get; set; }
        }
        public class Request
        {
            public string limit { get; set; }
            public string order { get; set; }
            public string direction { get; set; }
        }

        public int status { get; set; }
        public string message { get; set; }
        public int timestamp { get; set; }
        public Request request { get; set; }
        public List<Road> data { get; set; }
    }

}
