using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для TaskListPage.xaml
    /// </summary>
    public partial class TaskListPage : Page
    {
        public TaskListPage()
        {
            InitializeComponent();
        }

        public List<task> tasks = new List<task>();
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await GetTaskList();
            
           
        }
        public async Task GetTaskList()
        {
            
            using (HttpClient client = new HttpClient())
            {
                string responce = await client.GetStringAsync(MainFunc.ip + "/task_list");
                tasks = MainFunc.taskListHandler(responce);
                if (tasks == null)
                    MessageBox.Show("Ошибка");
                else
                {
                    foreach (task item in tasks)
                    {
                        StackPanel panel = new StackPanel();
                        panel.Orientation = Orientation.Horizontal;
                        panel.Height = 84;
                        TaskItem taskItem = new TaskItem(item.id,item.pr,item.status);
                        taskItem.lbName.Text = item.name;
                        ToolTip t = new ToolTip();
                        t.Content = "Описание: "+ item.desc+"\nДата создания:"+item.time_cr+"\nСодатель:"+item.userF;
                        t.Background = new SolidColorBrush(Color.FromArgb(100, 50,36,130));
                        t.FontSize = 18;
                        t.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        taskItem.ToolTip = t;
                        panel.Children.Add(taskItem);
                        lstCars.Items.Add(panel);
                    }

                }
            }
        }
    }
}
