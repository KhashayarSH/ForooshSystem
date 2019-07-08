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

namespace foroosh.window
{
    /// <summary>
    /// Interaction logic for win_ReportsList.xaml
    /// </summary>
    public partial class win_ReportsList : Window
    {
        public string GetListView_ReportName;
        public win_ReportsList()
        {
            InitializeComponent();
        }

        private void image_close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listView_reports.Items.Add("گزارش مشتریان فروشگاه");
            listView_reports.Items.Add("گزارش کاربران فروشگاه");
            listView_reports.Items.Add("گزارش کالاهای فروشگاه");
            listView_reports.Items.Add("گزارش ورود و خروج های سیستم");
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_ShowReport_Click(object sender, RoutedEventArgs e)
        {
            win_showReport w_SR = new win_showReport();
            w_SR.Report_Name = GetListView_ReportName;
            w_SR.ShowDialog();



        }

        

        private void listView_reports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView_reports.SelectedIndex == 0)
            {
                GetListView_ReportName = "CustomerList.rpt";
            }
        }
    }
}
