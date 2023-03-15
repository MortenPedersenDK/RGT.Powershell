using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGT.Services.Core.DTO
{
    public class EventInformation
    {
        public string EventId { get; set; }
        public string SignupLink { get; set; }
        public int TotalDistance { get; set; }
        public int TotalElevation { get; set; }
    }
}
