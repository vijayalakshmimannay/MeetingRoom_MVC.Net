
using System;

namespace MeetingRoom1.Models
{
    public class RequestModel
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string MDate { get; set; }
        public string Purpose { get; set; }
        public string RequestFor { get; set; }
        public int NoOfEmps { get; set; }
    }
}
