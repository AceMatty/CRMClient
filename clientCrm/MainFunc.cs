using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;

namespace clientCrm
{   
    public struct User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string fio { get; set; }
        public int perms { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
    public struct task
    {
        public int id;
        public string name;
        public string desc;
        public string time_cr;
        public string time_work;
        public int userT;
        public int userF;
        public int pr;
        public int status;
    }
    public class LogItem
    {
        public string desc { get; set; }
    }
    public static class MainFunc
    {
        public static User auth_user;
        public static DefForm mainForm;
        public const string ip = "http://localhost:9000";//82.146.63.120
        public static User userMsgHandler(string responce)
        {
            string typeMsg;
            typeMsg = responce.Remove(responce.IndexOf(':'));
            switch (typeMsg)
            {
                case "error":
                    break;
                case "user":
                    return userMsg(responce.Substring(responce.IndexOf(':')+1));
            }
            return new User();
        }
        static User userMsg(string msg)
        {
            User us = new User();
            msg = msg.Substring(1);
            msg = msg.Remove(msg.Length-1);
            string[] str = msg.Split(new char[] { ';'});
            //MessageBox.Show(str[0]+" "+str[1]+" "+str[2] + " " + str[3]);
            us.id = Int32.Parse(str[0]);
            us.login = str[1];
            us.fio = str[2];
            us.perms = Int32.Parse(str[3]);
            us.phone = str[5];
            us.email = str[4];
            return us;
        }
        public static List<LogItem> logMsgHandler(string responce)
        {
            List<LogItem> log = new List<LogItem>();
            string typeMsg;
            typeMsg = responce.Remove(responce.IndexOf(':'));
            if(typeMsg == "log")
            {
                string msg = responce.Substring(responce.IndexOf(':')+1);
                string[] s = msg.Split(new char[] {';'});
                foreach (string item in s)
                {
                    if(item != "")
                        log.Add(new LogItem { desc = item.Substring(item.IndexOf('-')+1) });
                }
            }
            else
            {
                return null;
            }
            return log;
        }
        public static List<User> usersListHandler(string responce)
        {
            List<User> UsersList = new List<User>();
            string typeMsg;
            typeMsg = responce.Remove(responce.IndexOf(':'));
            if(typeMsg == "userlist")
            {
                string msg = responce.Substring(responce.IndexOf('{') + 1);
                string[] s = msg.Split(new char[] { ';' });
                foreach  (string item in s)
                {
                    if (item != "" && item != "}")
                    {
                        string[] us = item.Split(':');
                        UsersList.Add(new User { id = Int32.Parse(us[0]), login = us[1], fio = us[2], perms = Int32.Parse(us[3]), email = us[5], phone = us[4] });
                    }
                }
            }
            else
            {
                return null;
            }
            return UsersList;
        }
        public static List<task> taskListHandler(string responce)
        {
            List<task> TasksList = new List<task>();
            string typeMsg;
            typeMsg = responce.Remove(responce.IndexOf(':'));
            if (typeMsg == "taskslist")
            {
                string msg = responce.Substring(responce.IndexOf('{') + 1);
                string[] s = msg.Split(new char[] { ';' });
                foreach (string item in s)
                {
                    if (item != "" && item != "}")
                    {
                        string[] us = item.Split(':');
                        TasksList.Add(new task{ id = Int32.Parse(us[0]), name = us[1],
                            desc = us[2], time_cr = us[3], time_work = us[4],
                            userT=Int32.Parse(us[5]), userF=Int32.Parse(us[6]), pr= Int32.Parse(us[7]), status= Int32.Parse(us[8]) });
                    }
                }
            }
            else
            {
                return null;
            }
            return TasksList;
        }
        public static User FindUser(int ind, List<User> ls)
        {
            User u = new User();
            foreach (User s in ls)
            {
                if(s.id == ind)
                {
                    u = s;
                }
            }
            return u;
        }
    }
}
