namespace RGT.Services.Core.Data
{
    public class EventCreationInformation
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? StartDate { get; set; }
        public string? StartTime { get; set; }
        public string? StartAt { get; set; }
        public string? RoadId { get; set; }
        public string? Laps { get; set; } = "1";
        public string? Timezone { get; set; } = "2";
        public string? Type { get; set; } = "0";
        public string? BotsType { get; set; } = "1";
        public string? BotsReal { get; set; } = "0";
        public string? BotsMode { get; set; } = "3";
        public string? BotsNum { get; set; } = "0";
        public string? BotsMinPwr { get; set; } = "70";
        public string? BotsMaxPwr { get; set; } = "310";
        public string? Private { get; set; } = "1";
        public string? RubberBand { get; set; } = "0";
        public string? GenScene { get; set; } = "gen01";
        public string? ParamsPreset { get; set; } = "0";
        public string? Params { get; set; } = "{\"drafting\":\"true\",\"mass_start\":\"true\",\"start_gap_time\":\"15\",\"start_wave_size\":\"1\",\"allow_virt_power\":\"false\"}";
        public string? WorkoutName { get; set; } = string.Empty;
        public byte[]? EventThumbnail { get; set; } = null;
        public byte[]? Billboard01 { get; set; } = null;
        public byte[]? Billboard02 { get; set; } = null;
        public byte[]? Billboard03 { get; set; } = null;
        public byte[]? Fence01 { get; set; } = null;
        public byte[]? Fence02 { get; set; } = null;
        public byte[]? Fence03 { get; set; } = null;
        public byte[]? Fence04 { get; set; } = null;
        public byte[]? Fence05 { get; set; } = null;
        public byte[]? Fence06 { get; set; } = null;
        public byte[]? Flag01 { get; set; } = null;
        public byte[]? Flag02 { get; set; } = null;
        public byte[]? Flag03 { get; set; } = null;
        public byte[]? GateMainTop { get; set; } = null;
        public byte[]? GateMainSide { get; set; } = null;
        public byte[]? Decal01 { get; set; } = null;
        public byte[]? Decal02 { get; set; } = null;
        public byte[]? SignDistance { get; set; } = null;
        public byte[]? TentBasicTop { get; set; } = null;
        public byte[]? TentBasicWall { get; set; } = null;
        public byte[]? TentTechTop { get; set; } = null;
        public byte[]? TentTechWall { get; set; } = null;
        public byte[]? GateSegmentTop { get; set; } = null;
        public byte[]? GateSegmentSide { get; set; } = null;

    }
}
