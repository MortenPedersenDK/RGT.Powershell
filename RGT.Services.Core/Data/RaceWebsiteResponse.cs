using System;
using System.Collections.Generic;
using System.Text;

namespace RGT.Services.Core.Data.RaceWebsite
{
    public class RaceWebsiteResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public int timestamp { get; set; }
        public Request request { get; set; }
        public Data data { get; set; }
    }

    public class Activity
    {
        public int id { get; set; }
        public int race_id { get; set; }
        public int distance { get; set; }
        public double avg_speed { get; set; }
        public int avg_power { get; set; }
        public int best_20_min_avg_power { get; set; }
        public int avg_heart_rate { get; set; }
        public int weight { get; set; }
    }

    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code1 { get; set; }
        public string code2 { get; set; }
        public int hidden { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int laps { get; set; }
        public int type { get; set; }
        public DateTime start_at { get; set; }
        public string finished_at { get; set; }
        public object workout_id { get; set; }
        public string banner_link { get; set; }
        public string roadbanner_url { get; set; }
        public int do_not_share { get; set; }
        public List<Subscriber> subscribers { get; set; }
        public bool subscribed { get; set; }
        public Params @params { get; set; }
        public int params_preset { get; set; }
        public int rubber_band { get; set; }
        public List<Result> results { get; set; }
        public Owner owner { get; set; }
        public List<SegmentsLeaderboard> segments_leaderboards { get; set; }
        public Road road { get; set; }
        public List<object> restrictions { get; set; }
    }

    public class Owner
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string uuid { get; set; }
        public int weight { get; set; }
        public int is_premium { get; set; }
        public string premium_source { get; set; }
        public string short_name { get; set; }
        public int team { get; set; }
        public int beta { get; set; }
        public int press { get; set; }
        public int retailer { get; set; }
        public int partner { get; set; }
        public int supertester { get; set; }
        public int temp { get; set; }
        public int race_params_access_level { get; set; }
        public Country country { get; set; }
        public List<RedeemCode> redeem_codes { get; set; }
    }

    public class Params
    {
        public int laps { get; set; }
        public bool drafting { get; set; }
        public bool collision_brake { get; set; }
        public bool mass_start { get; set; }
        public int start_gap_time { get; set; }
        public int start_wave_size { get; set; }
        public bool elimination_mode { get; set; }
        public int elim_position_laps { get; set; }
        public int elim_laps_freq { get; set; }
        public int elim_drop_num { get; set; }
        public bool physics_test { get; set; }
        public bool allow_virt_power { get; set; }
    }

    public class Pivot
    {
        public int user_id { get; set; }
        public int redeem_code_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class RedeemCode
    {
        public int id { get; set; }
        public string code { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int duration { get; set; }
        public string expired_at { get; set; }
        public string affiliate { get; set; }
        public int notified { get; set; }
        public int multiple_users { get; set; }
        public Pivot pivot { get; set; }
    }

    public class Request
    {
    }

    public class Result
    {
        public int id { get; set; }
        public int race_id { get; set; }
        public int user_id { get; set; }
        public int activity_id { get; set; }
        public int time { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public double avg_wpk { get; set; }
        public int rank { get; set; }
        public string time_min_sec { get; set; }
        public User user { get; set; }
        public Activity activity { get; set; }
    }

    public class Road
    {
        public int id { get; set; }
        public string name { get; set; }
        public int is_reversed { get; set; }
        public double top_left_lat { get; set; }
        public double top_left_long { get; set; }
        public double bot_right_lat { get; set; }
        public double bot_right_long { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public double map_width { get; set; }
        public double map_height { get; set; }
        public int type { get; set; }
        public string label { get; set; }
        public int available { get; set; }
        public string ip { get; set; }
        public int shape { get; set; }
        public int length { get; set; }
        public int elevation { get; set; }
        public double avg_slope { get; set; }
        public int flipped { get; set; }
        public string description { get; set; }
        public double scaling { get; set; }
        public int start_section { get; set; }
        public int country_id { get; set; }
        public string banner_url { get; set; }
        public string map_url { get; set; }
        public string elevation_url { get; set; }
        public int version { get; set; }
        public int top_left_unit_x { get; set; }
        public double top_left_unit_y { get; set; }
        public int top_left_unit_z { get; set; }
        public int bottom_right_unit_x { get; set; }
        public double bottom_right_unit_y { get; set; }
        public int bottom_right_unit_z { get; set; }
        public string satellite_url { get; set; }
        public string heightmap_url { get; set; }
        public double displacement_amount { get; set; }
        public double pin_lat { get; set; }
        public double pin_long { get; set; }
        public object gen_scene { get; set; }
        public int validated { get; set; }
        public object user_id { get; set; }
        public int is_magic_road { get; set; }
        public int processed { get; set; }
        public int workout { get; set; }
        public object code { get; set; }
        public int premium { get; set; }
        public int special { get; set; }
        public int surface { get; set; }
        public int ride_left { get; set; }
        public int data_format { get; set; }
        public int has_assets { get; set; }
        public int road_channel_enabled { get; set; }
        public int custom_channel_enabled { get; set; }
        public object forced_custom_channel_name { get; set; }
        public object forced_road_channel_name { get; set; }
        public int road_channel_range { get; set; }
        public int custom_channel_range { get; set; }
        public int featured { get; set; }
        public string nodes_url { get; set; }
        public int full_width { get; set; }
        public Country country { get; set; }
    }


    public class Segment
    {
        public int id { get; set; }
        public int road_id { get; set; }
        public string name { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public int length { get; set; }
        public double avg_grade { get; set; }
        public double elevation_gain { get; set; }
        public int default_selection { get; set; }
        public int activation_distance { get; set; }
        public int asset_id { get; set; }
        public int start_distance { get; set; }
        public int type { get; set; }
        public int review_time { get; set; }
        public int impossible_time { get; set; }
    }

    public class SegmentsLeaderboard
    {
        public int id { get; set; }
        public int segment_id { get; set; }
        public int user_id { get; set; }
        public int time { get; set; }
        public string created_at { get; set; }
        public int best_time { get; set; }
        public int race_id { get; set; }
        public Segment segment { get; set; }
        public User user { get; set; }
    }

    public class Subscriber
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string uuid { get; set; }
        public int gender { get; set; }
        public int is_premium { get; set; }
        public string premium_source { get; set; }
        public string short_name { get; set; }
        public int team { get; set; }
        public int beta { get; set; }
        public int press { get; set; }
        public int retailer { get; set; }
        public int partner { get; set; }
        public int supertester { get; set; }
        public int temp { get; set; }
        public int race_params_access_level { get; set; }
        public Country country { get; set; }
        public List<RedeemCode> redeem_codes { get; set; }
        public List<object> payments { get; set; }
    }

    public class User
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string uuid { get; set; }
        public int gender { get; set; }
        public int ai { get; set; }
        public int weight { get; set; }
        public int height { get; set; }
        public string birthday { get; set; }
        public int is_premium { get; set; }
        public string premium_source { get; set; }
        public string short_name { get; set; }
        public int team { get; set; }
        public int beta { get; set; }
        public int press { get; set; }
        public int retailer { get; set; }
        public int partner { get; set; }
        public int supertester { get; set; }
        public int temp { get; set; }
        public int race_params_access_level { get; set; }
        public Country country { get; set; }
        public List<object> redeem_codes { get; set; }
        public List<object> payments { get; set; }
    }

}
