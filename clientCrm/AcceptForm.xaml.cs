using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace clientCrm
{
    /// <summary>
    /// Логика взаимодействия для AcceptForm.xaml
    /// </summary>
    public partial class AcceptForm : Window
    {
        public bool isAccepted = false;
        public AcceptForm()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            isAccepted = true;
            Hide();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            isAccepted = false;
            Hide();
        }
    }
}
