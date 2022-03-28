using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReserve.pojo.response
{
    public class SeatData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public bool window { get; set; }
        public bool power { get; set; }
        public bool computer { get; set; }
        public bool local { get; set; }

		public override string ToString()
		{
            return $"{{id:{id},name:{name},type:{type},status:{status},window:{window},power:{power},computer:{computer},local:{local}}}";
		}
	}

    public class LayoutData
    {
        public LayoutData()
        {
            layout = new Dictionary<string, SeatData>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public int cols { get; set; }
        public int rows { get; set; }
        public Dictionary<string, SeatData> layout { get; set; }

		public override string ToString()
		{
            string s1 = $"{{id:{id},name:{name},cols:{cols},rows:{rows},layout{{";
			foreach (var item in layout)
			{
                s1 += $"{item.Key}:{item.Value},";
			}
            return s1 + "}}";
		}
	}
    public class SeatResponse
    {
        public string status { get; set; }
        public LayoutData data { get; set; }

		public override string ToString()
		{
            return $"status:{status},data:{data}";
		}
	}
}
