using Reserve.manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReserve.pojo
{
    public class User
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Seat { get; set; }
        public string OptionalSeat { get; set; }
        public string Time { get; set; }
        public string ReserveInfo { get; set; }
        public bool IsReserve { get; set; }
        public int Row { get; set; }
        public User(string id, string password, string name, string seat, string time, object optinalSeat)
        {
            Id = id;
            Password = password;
            Name = name;
            Seat = seat;
            Time = time;
            if (optinalSeat != null)
                OptionalSeat = optinalSeat.ToString();
            IsReserve = false;
        }


        public override string ToString()
        {
            string info = $"id:{Id},password:{Password},name:{Name},seat:{Seat},time:{Time},明天是否预约:{IsReserve}";
            if (OptionalSeat != null)
                info += $",optinalSeat:{OptionalSeat}";
            return info;
        }
    }
}
