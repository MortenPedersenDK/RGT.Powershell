using System;

namespace RGT.Services.Core.DTO
{
    public class SegmentResult
    {
        public TimeSpan Time { get; set; }
        public bool Best { get; set; }
        public DateTime Created  { get; set; }

        public Rider Rider { get; set; }
    }
}
