using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace clientCrm
{
    /// <summary>
    /// Логика взаимодействия для UserTaskList.xaml
    /// </summary>

    public partial class UserTaskList : Page
    {
        string[] week = new string[5];
        public List<task> tasks = new List<task>();
        List<task> tasks1 = new List<task>();
        List<task> tasks2 = new List<task>();
        List<task> tasks3 = new List<task>();
        List<task> tasks4 = new List<task>();
        List<task> tasks5 = new List<task>();
        DateTime day;

        public static List<User> UsersList;
        public UserTaskList()
        {
            InitializeComponent();
        }
        public async Task GetUserList()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string responce = await client.GetStringAsync(MainFunc.ip + "/user_list");
                    UsersList = MainFunc.usersListHandler(responce);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
           
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                day = DateTime.Now;
                await GetTaskList();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }
        void DrawDays()
        {
            lbMon.Content ="Понедельник "+week[0] + " число";
            lbTuesd.Content = "Вторник " + week[1] + " число";
            lbWed.Content = "Среда " + week[2] + " число";
            lbThurs.Content = "Четверг " + week[3] + " число";
            lbFrid.Content = "Пятница " + week[4] + " число";
        }
        StackPanel GetTaskItem(task item)
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Height = 84;
            TaskItem taskItem = new TaskItem(item.id, item.pr, item.status);
            taskItem.lbName.Text = item.name;
            ToolTip t = new ToolTip();
            t.Content = "Описание: " + item.desc + "\nДата создания: " + item.time_cr + "\nСодатель: " + MainFunc.FindUser(item.userT, UsersList).fio;
            t.Background = new SolidColorBrush(Color.FromArgb(100, 50, 36, 130));
            t.FontSize = 18;
            t.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            taskItem.ToolTip = t;
            panel.Children.Add(taskItem);
            return panel;
        }
        void DrawTasks()
        {
            try
            {
                foreach (task item in tasks)
                {
                    if (item.status != 1)
                    {
                        if (DateTime.Parse(item.time_work) == DateTime.Parse(week[0] + "." + day.Month + "." + day.Year))
                        {
                            tasks1.Add(item);
                        }
                        if (DateTime.Parse(item.time_work) == DateTime.Parse(week[1] + "." + day.Month + "." + day.Year))
                        {
                            tasks2.Add(item);
                        }
                        if (DateTime.Parse(item.time_work) == DateTime.Parse(week[2] + "." + day.Month + "." + day.Year))
                        {
                            tasks3.Add(item);
                        }
                        if (DateTime.Parse(item.time_work) == DateTime.Parse(week[3] + "." + day.Month + "." + day.Year))
                        {
                            tasks4.Add(item);
                        }
                        if (DateTime.Parse(item.time_work) == DateTime.Parse(week[4] + "." + day.Month + "." + day.Year))
                        {
                            tasks5.Add(item);
                        }
                    }

                }
                tasks1.Sort((a, b) => b.pr.CompareTo(a.pr));
                tasks2.Sort((a, b) => b.pr.CompareTo(a.pr));
                tasks3.Sort((a, b) => b.pr.CompareTo(a.pr));
                tasks4.Sort((a, b) => b.pr.CompareTo(a.pr));
                tasks5.Sort((a, b) => b.pr.CompareTo(a.pr));
                foreach (task item in tasks1)
                {
                    lsMonday.Items.Add(GetTaskItem(item));
                }
                foreach (task item in tasks2)
                {
                    lsTuesday.Items.Add(GetTaskItem(item));
                }
                foreach (task item in tasks3)
                {
                    lsWednesday.Items.Add(GetTaskItem(item));
                }
                foreach (task item in tasks4)
                {
                    lsThursday.Items.Add(GetTaskItem(item));
                }
                foreach (task item in tasks5)
                {
                    lsFriday.Items.Add(GetTaskItem(item));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }
        void ClearLists()
        {
            lsMonday.Items.Clear();
            lsTuesday.Items.Clear();
            lsThursday.Items.Clear();
            lsWednesday.Items.Clear();
            lsFriday.Items.Clear();
            tasks1.Clear();
            tasks2.Clear();
            tasks3.Clear();
            tasks4.Clear();
            tasks5.Clear();
        }
        public void LoadWeek()
        {
            switch (day.DayOfWeek) 
            {
                case DayOfWeek.Monday:
                    week[0] = day.Date.ToString("dd");
                    week[1] = day.AddDays(1).ToString("dd");
                    week[2] = day.AddDays(2).ToString("dd");
                    week[3] = day.AddDays(3).ToString("dd");
                    week[4] = day.AddDays(4).ToString("dd");
                    DrawDays();
                    DrawTasks();
                    break;
                case DayOfWeek.Tuesday:
                    week[0] = day.AddDays(-1).ToString("dd");
                    week[1] = day.Date.ToString("dd");
                    week[2] = day.AddDays(1).ToString("dd");
                    week[3] = day.AddDays(2).ToString("dd");
                    week[4] = day.AddDays(3).ToString("dd");
                    DrawDays();
                    DrawTasks();
                    break;
                case DayOfWeek.Wednesday:
                    week[0] = day.AddDays(-2).ToString("dd");
                    week[1] = day.AddDays(-1).ToString("dd");
                    week[2] = day.Date.ToString("dd");
                    week[3] = day.AddDays(1).ToString("dd");
                    week[4] = day.AddDays(2).ToString("dd");
                    DrawDays();
                    DrawTasks();
                    break;
                case DayOfWeek.Thursday:
                    week[0] = day.AddDays(-3).ToString("dd");
                    week[1] = day.AddDays(-2).ToString("dd");
                    week[2] = day.AddDays(-1).ToString("dd");
                    week[3] = day.Date.ToString("dd");
                    week[4] = day.AddDays(1).ToString("dd");
                    DrawDays();
                    DrawTasks();
                    break;
                case DayOfWeek.Friday:
                    week[0] = day.AddDays(-4).ToString("dd");
                    week[1] = day.AddDays(-3).ToString("dd");
                    week[2] = day.AddDays(-2).ToString("dd");
                    week[3] = day.AddDays(-1).ToString("dd");
                    week[4] = day.Date.ToString("dd");
                    DrawDays();
                    DrawTasks();
                    break;
                case DayOfWeek.Saturday:
                    week[0] = day.AddDays(-5).ToString("dd");
                    week[1] = day.AddDays(-4).ToString("dd");
                    week[2] = day.AddDays(-3).ToString("dd");
                    week[3] = day.AddDays(-2).ToString("dd");
                    week[4] = day.AddDays(-1).ToString("dd");
                    DrawDays();
                    DrawTasks();
                    break;
                case DayOfWeek.Sunday:
                    week[0] = day.AddDays(-6).ToString("dd");
                    week[1] = day.AddDays(-5).ToString("dd");
                    week[2] = day.AddDays(-4).ToString("dd");
                    week[3] = day.AddDays(-3).ToString("dd");
                    week[4] = day.AddDays(-2).ToString("dd");
                    DrawDays();
                    DrawTasks();
                    break;
            }
        }
        public async Task GetTaskList()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string responce = await client.GetStringAsync(MainFunc.ip + "/tasks_forUS?user_id=" + MainFunc.auth_user.id);
                    tasks = MainFunc.taskListHandler(responce);
                    if (tasks == null)
                        MessageBox.Show("Ошибка");
                    else
                    {
                        await GetUserList();
                        LoadWeek();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }
        private async void dtP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtP.SelectedDate.Value.DayOfWeek == DayOfWeek.Saturday || dtP.SelectedDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Вы выбрали выходной день! \n Пожалуйста выберете другой рабочий день.", "Ошибка!");
                dtP.SelectedDate = DateTime.Now.Date;
            }
            else
            {
                try
                {
                    day = dtP.SelectedDate.Value;
                    ClearLists();
                    await GetTaskList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
        }
    }
}
