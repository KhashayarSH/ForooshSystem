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
using DataModelLayer;

namespace foroosh.window
{
    /// <summary>
    /// Interaction logic for win_forooshchart.xaml
    /// </summary>
    public partial class win_forooshchart : Window
    {
        public win_forooshchart()
        {
            InitializeComponent();
        }
        forooshEntities database = new forooshEntities();

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btn_showchart_Click(object sender, RoutedEventArgs e)
        {
            List<KeyValuePair<string, long>> chartValue = new List<KeyValuePair<string, long>>();
            if (rdb_forooshruzane.IsChecked == true)
            {


                /////////////////////////////////////////////////
                var query = database.Sp_Foroosh_Chart();
                /////////////////////////////////////////////////
                var result = query.ToList();
                for (int i = 0; i < result.Count; i++)
                {
                    chartValue.Add(new KeyValuePair<string, long>(result[i].InvoiceDate, Convert.ToInt64(result[i].TotalPrice)));
                }
            }
            else if (rdb_forooshcustomer.IsChecked == true)
            {
                var query = database.Sp_CustomerForooshChart();
                /////////////////////////////////////////////////
                var result = query.ToList();
                for (int i = 0; i < result.Count; i++)
                {
                    chartValue.Add(new KeyValuePair<string, long>(result[i].CustomerName, Convert.ToInt64(result[i].TotalPrice)));
                }
            }

            else if (rdb_forooshproduct.IsChecked == true)
            {
                var query = database.Sp_Productforooshchart();
                /////////////////////////////////////////////////
                var result = query.ToList();
                for (int i = 0; i < result.Count; i++)
                {
                    chartValue.Add(new KeyValuePair<string, long>(result[i].ProductName, Convert.ToInt64(result[i].TotalPrice)));
                }
            }

            chart_foroosh.DataContext = chartValue;
        }
    }
}
