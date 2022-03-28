using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReserve.pojo.response
{
	public class ReservationData
	{
		public int id { get; set; }
		public string date { get; set; }
		public string begin { get; set; }
		public string end { get; set; }
		public string awayBegin { get; set; }
		public string awayEnd { get; set; }
		public string loc { get; set; }
		public string stat { get; set; }

		public override string ToString()
		{
			return $"{{{id},{date},{begin},{end},{loc},{stat}}}";
		}
	}
	public class Reservations
	{
		public List<ReservationData> reservations { get; set; }

		public Reservations()
		{
			reservations = new List<ReservationData>();
		}

		public override string ToString()
		{
			string s = "[";
			reservations?.ForEach(reservation => s += reservation.ToString());
			s += "]";
			return s;
		}
	}

	public class ReservationResponse
	{
		public string status { get; set; }
		public Reservations data { get; set; }
		public string message { get; set; }
		public string code { get; set; }

		public ReservationResponse()
		{
			
		}

		public override string ToString()
		{
			return $"status{status}, data={data}, message={message}, code={code}";
		}
	}
}
