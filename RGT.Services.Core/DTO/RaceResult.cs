using System;

namespace RGT.Services.Core.DTO
{
    public class RaceResult
    {
        public Rider Rider { get; set; }
        public int Rank { get; set; }
        public TimeSpan Time { get; set; }
        public double Distance { get; set; }
        public double Kmh { get; set; }
        public double Mph { get; set; }
        public int AvgPwr { get; set; }
        public int Best20MinPwr { get; set; }
        public int AvgHr { get; set; }

    }
}
