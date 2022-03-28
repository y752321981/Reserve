using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace LibraryReserve.pojo.response
{
    public class data
    {
        public string token { get; set; }
    }
    public class LoginResponse
    {
        public string status { get; set; }
 
        public string code { get; set; }
   
        public string message { get; set; }
 
        public data data { get; set; }

     
        public override string ToString()
        {
            return $"status:{status},data:{{token:{data.token}}},code:{code},message:{message}";
        }
    }
}
