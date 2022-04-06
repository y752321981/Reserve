using LibraryReserve.pojo;
using Reserve.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserve.manager
{
    public class UserManager
    {
        private static UserManager instance;
        public static UserManager Instance
        {
            get
            {
                return instance ?? (instance = new UserManager());
            }
        }
        private List<User> users;
        public List<User> Users { get { return users; } set { users = value; } }
        private UserManager()
        {
            users = new List<User>();
        }
        public List<User> FreshUserList()
        {
            users = ExcelManager.Instance.ReadUser();
            QueryReserveInfo();
            return users;
        }
        public User FindUserByRow(int row)
        {
            User user = null;
            users?.ForEach(u =>
            {
                if (u.Row == row)
                    user = u;
            });
            return user;
        }
        public void ResetReserveState()
        {
            users?.ForEach(item =>
            {
                item.IsReserve = false;
            });
        }

        public void QueryReserveInfo()
        {
            users?.ForEach(item =>
            {
                List<string> list = HttpManager.Instance.QueryReserveInfo(item);
                string info = string.Empty;
                item.IsReserve = false;
                list?.ForEach(s =>
                {
                    info += s + '\n';
                    string[] vs = s.Split(',');
                    if (vs[1] == DateTime.Now.AddDays(1).ToString("yyyy-M-d") && vs[3].Equals("RESERVE"))
                    {
                        item.IsReserve = true;
                    }
                    
                });
                item.ReserveInfo = info;
            });
        }

        public void StartReserve()
        {
            users?.ForEach(item =>
            {
                if (!item.IsReserve)
                {
                    Debug.Log(item.Id + "自动启动预约");
                    bool result = HttpManager.Instance.Reserve(item);
                    Debug.Log(item.Id + "预约结果:" + result);
                }
            });
        }
    }
}
