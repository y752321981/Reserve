using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReserve.pojo.response
{
    public class TimeData
    {
        public string id { get; set; }
        public string value { get; set; }
    }

    public class BeginTimeData
    {
        public List<TimeData> startTimes { get; set; }

        public BeginTimeData()
        {
            startTimes = new List<TimeData>();
        }
    }

    public class BeginTimeResponse
    {
        public string status { get; set; }
        public BeginTimeData data { get; set; }
        public string message { get; set; }
        public string code { get; set; }
    }
}
