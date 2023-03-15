using System;
using System.Collections.Generic;
using System.Text;

namespace RGT.Services.Core.Data
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);



    public class RoadsRealResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public int timestamp { get; set; }
        public Request request { get; set; }
        public List<Road> data { get; set; }

        public class Request
        {
            public string limit { get; set; }
            public string order { get; set; }
            public string direction { get; set; }
        }

        public class Road
        {
            public int id { get; set; }
            public string uuid { get; set; }
            public string ip { get; set; }
            public int inputUdpPort { get; set; }
            public int outputUdpPort { get; set; }
            public int tcpPort { get; set; }
            public int udpPort { get; set; }
            public string name { get; set; }
            public string label { get; set; }
            public string description { get; set; }
            public double avg_slope { get; set; }
            public int elevation { get; set; }
            public int length { get; set; }
            public int flipped { get; set; }
            public int ride_left { get; set; }
            public int surface { get; set; }
            public int data_format { get; set; }
            public int type { get; set; }
            public int event_id { get; set; }
            public int users { get; set; }
            public double scaling { get; set; }
            public int start_section_normal { get; set; }
            public int start_section_reversed { get; set; }
            public Country country { get; set; }
            public string banner_url { get; set; }
            public string roadbanner_url { get; set; }
            public string map_url { get; set; }
            public string elevation_url { get; set; }
            public string nodes_url { get; set; }
            public int nodes_version { get; set; }
            public int score { get; set; }
            public double top_left_unit_x { get; set; }
            public double top_left_unit_y { get; set; }
            public double top_left_unit_z { get; set; }
            public double bottom_right_unit_x { get; set; }
            public double bottom_right_unit_y { get; set; }
            public double bottom_right_unit_z { get; set; }
            public string satellite_url { get; set; }
            public string heightmap_url { get; set; }
            public double displacement_amount { get; set; }
            public double pin_lat { get; set; }
            public double pin_long { get; set; }
            public int gen_start { get; set; }
            public int gen_end { get; set; }
            public int shape { get; set; }
            public object gen_scene { get; set; }
            public double map_width { get; set; }
            public double map_height { get; set; }
            public double top_left_lat { get; set; }
            public double top_left_long { get; set; }
            public double bot_right_lat { get; set; }
            public double bot_right_long { get; set; }
            public CustomTextures custom_textures { get; set; }
            public int branding_level { get; set; }
            public int premium { get; set; }
            public int special { get; set; }
            public int do_not_share { get; set; }
            public object radio_id { get; set; }
            public int road_channel_enabled { get; set; }
            public int custom_channel_enabled { get; set; }
            public object forced_custom_channel_name { get; set; }
            public object forced_road_channel_name { get; set; }
            public string road_channel_range { get; set; }
            public string custom_channel_range { get; set; }
            public int featured { get; set; }

            public class Country
            {
                public int id { get; set; }
                public string name { get; set; }
                public string code1 { get; set; }
                public string code2 { get; set; }
                public int hidden { get; set; }
            }

            public class CustomTextures
            {
                public string mr_gate_banner { get; set; }
                public string mr_billboard01 { get; set; }
                public string mr_fence01 { get; set; }
                public string billboard01 { get; set; }
                public string billboard02 { get; set; }
                public string billboard03 { get; set; }
                public string fence01 { get; set; }
                public string fence02 { get; set; }
                public string fence03 { get; set; }
                public string fence04 { get; set; }
                public string fence05 { get; set; }
                public string fence06 { get; set; }
                public string flag01 { get; set; }
                public string flag02 { get; set; }
                public string flag03 { get; set; }
                public string gaterouge { get; set; }
                public string gaterougebody { get; set; }
                public string gatehalf { get; set; }
                public string gatehalfbody { get; set; }
                public string gatemaintop { get; set; }
                public string gatemainside { get; set; }
                public string gatesegmenttop { get; set; }
                public string gatesegmentside { get; set; }
                public string signdistance { get; set; }
                public string decal01 { get; set; }
                public string decal02 { get; set; }
                public string tentbasictop { get; set; }
                public string tentbasicwall { get; set; }
                public string tenttechtop { get; set; }
                public string tenttechwall { get; set; }
            }
        }


    }


}
