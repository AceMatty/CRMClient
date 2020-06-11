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
    /// Логика взаимодействия для TaskItem.xaml
    /// </summary>
    public partial class TaskItem : UserControl
    {
        public int TaskId;
        public int TaskPr;
        public int TaskSt;
        public TaskItem(int id,int pr, int st)
        {
            TaskId = id;
            TaskPr = pr;
            TaskSt = st;
            InitializeComponent();
        }
        private async void btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AcceptForm form = new AcceptForm();
                form.ShowDialog();
                if (form.IsActive == false)
                {
                    if (form.isAccepted == true)
                    {
                        await CompleteTask();
                        
                    }
                    else
                    {
                        
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async Task CompleteTask()
        {
            using (HttpClient client = new HttpClient())
            {
                string responce = await client.GetStringAsync(MainFunc.ip + "/complete_task?id=" + TaskId);
                MessageBox.Show(responce);
                MainFunc.mainForm.frm1.Content = new UserTaskList();
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(TaskPr == 0)
            {
                lbPr.Content = "Низкий приоритет";
                lbPr.Foreground= new SolidColorBrush(Color.FromRgb(23, 236, 81));
            }
            if (TaskPr == 1)
            {
                lbPr.Content = "Средний приоритет";
                lbPr.Foreground = new SolidColorBrush(Color.FromRgb(255, 197, 1));
            }
            if (TaskPr == 2)
            {
                lbPr.Content = "Высокий приоритет";
                lbPr.Foreground = new SolidColorBrush(Color.FromRgb(255, 42, 42));
            }
        }
    }
}
