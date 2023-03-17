using System.Collections.Generic;

namespace RGT.Services.Core.DTO
{
    public class EventResult
    {
        public string Name { get; set; }
        public List<Rider> Signups { get; set; }
        public List<RaceResult> Result { get; set; }
        public List<Segment> Segments { get; set; }
    }
}
