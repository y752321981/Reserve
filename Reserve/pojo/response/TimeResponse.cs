using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReserve.pojo.response
{
    public class TimeStruct
    {
        public string id { get; set; }
        public string value { get; set; }
    }

    public class TimeData
    {
        public List<TimeStruct> endTimes { get; set; }

        public TimeData()
        {
            endTimes = new List<TimeStruct>();
        }
    }
    public class TimeResponse
    {
        public string status { get; set; }
        public TimeData data { get; set; }
        public string message { get; set; }
        public string code { get; set; }

        public override string ToString()
        {
            return $"status:{status},data:{data},message:{message},code:{code}";
        }
    }
}
