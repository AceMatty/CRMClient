using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для JurnPage.xaml
    /// </summary>
    public partial class JurnPage : Page
    {
   
        public JurnPage()
        {
            InitializeComponent();
        }
        List<LogItem> log = new List<LogItem>();

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                 await GetLog();
                 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async Task GetLog()
        {
            using(HttpClient client = new HttpClient())
            {
                string responce = await client.GetStringAsync(MainFunc.ip + "/log");
                log = MainFunc.logMsgHandler(responce);
                if (log == null)
                    MessageBox.Show("Ошибка");
                //dataDd.Items.Clear();
                dataDd.ItemsSource = log;
                dataDd.Columns[0].Header = "События";


            }
      
        }

        private async void btnClearDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AcceptForm form = new AcceptForm();
                form.ShowDialog();
                if (form.IsActive == false)
                {
                    if (form.isAccepted == true)
                    {
                        await ClearLog();
                        form.Close();
                    }
                    else
                    {
                        form.Close();
                    }

                }
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
            
        }
        public async Task ClearLog()
        {
            using (HttpClient client = new HttpClient())
            {
                string responce = await client.GetStringAsync(MainFunc.ip + "/clear_log?user_id="+MainFunc.auth_user.id);
                //MessageBox.Show(responce);
                await GetLog();


            }

        }
    }
}
