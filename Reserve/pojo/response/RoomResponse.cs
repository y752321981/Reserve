using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReserve.pojo.response
{
    public class RoomData
    {
        public int roomId { get; set; }
        public string room { get; set; }
        public int floor { get; set; }
        public int maxHour { get; set; }
        public int reserved { get; set; }
        public int inUse { get; set; }
        public int away { get; set; }
        public int totalSeats { get; set; }
        public int free { get; set; }

        public override string ToString()
        {
            return $"{{roomId:{roomId},room:{room},floor:{floor},maxHour:{maxHour},reserved:{reserved},inUse:{inUse},away:{away},totalSeats:{totalSeats},free:{free}}}";
        }
    }
    public class RoomResponse
    {
        public RoomResponse()
        {
            data = new List<RoomData>();
        }

        public string status { get; set; }

        public List<RoomData> data { get; set; }
        
        public string message  { get; set; }
        public string code { get; set; }


        public override string ToString()
        {
            return $"status:{status},data:{data}";
        }
    }
}
