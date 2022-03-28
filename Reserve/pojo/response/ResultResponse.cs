using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReserve.pojo.response
{
    public class ResultData
    {
        public int id { get; set; }
        public string receipt { get; set; }
        public string onDate { get; set; }
        public string begin { get; set; }
        public string end { get; set; }
        public string location { get; set; }
        public bool checkedIn { get; set; }
        public string checkInMsg { get; set; }
    }
    public class ResultResponse
    {
        public string status { get; set; }
        public ResultData data { get; set; }
        public string message { get; set; }
        public string code { get; set; }
    }
}
