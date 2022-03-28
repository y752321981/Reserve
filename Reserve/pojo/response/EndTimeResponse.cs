using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReserve.pojo.response
{
    public class TimeData1
    {
        public string id { get; set; }
        public string value { get; set; }
    }

    public class EndTimeData
    {
        public List<TimeData1> endTimes { get; set; }

        public EndTimeData()
        {
            endTimes = new List<TimeData1>();
        }
    }
    public class EndTimeResponse
    {
        public string status { get; set; }
        public EndTimeData data { get; set; }
        public string message { get; set; }
        public string code { get; set; }

        public override string ToString()
        {
            return $"status:{status},data:{data},message:{message},code:{code}";
        }
    }
}
