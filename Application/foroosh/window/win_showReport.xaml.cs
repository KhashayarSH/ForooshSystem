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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;

namespace foroosh.window
{
    /// <summary>
    /// Interaction logic for win_showReport.xaml
    /// </summary>
    public partial class win_showReport : Window
    {
        public string Report_Name { get; set; }
        public win_showReport()
        {
            InitializeComponent();
        }

        private void CrystalReportsViewer_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReportDocument RD = new ReportDocument();
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "reports\\" + this.Report_Name;
            RD.Load(path);
            RD.SetParameterValue("ReportDate", string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar.Text)));
            




            CRV.ViewerCore.ReportSource = RD;
        }
    }
}
