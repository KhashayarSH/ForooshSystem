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
using foroosh.Module;
using System.Transactions;
using System.Text.RegularExpressions;

namespace foroosh.window
{
    /// <summary>
    /// Interaction logic for win_invoice.xaml
    /// </summary>
    public partial class win_invoice : Window
    {
        public win_invoice()
        {
            InitializeComponent();
        }

        public int InvoiceId { get; set; }

        public string CustomerName { get; set; }

        public long InvoicePrice_foroosh { get; set; }

        public long InvoicePrice_kharid { get; set; }

        public string InvoiceDate { get; set;}

        public byte Win_type { get; set; }







        forooshEntities database = new forooshEntities();
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            if (Win_type == 1)
            {


                /////////نمایش مشتری 
                ShowCustomer(SearchStatement_Customer);
                /////////نمایش اطلاعات فاکتور
                ShowInvoiceInformation();
                ///////نمایش کالا ها 
                ShowProduct(SearchStatement_Product);
                /////////غیرفعال کردن دکمه
                btn_sabtekala.IsEnabled = false;
                btn_selectProduct.IsEnabled = false;
                btn_closeinvoice.IsEnabled = false;
            }
            else if (Win_type==2)
            {
                /////////////////////////////نمایش مشتریان
                ShowCustomer(SearchStatement_Customer);
                dataGrid_customer.IsEnabled = false;
                /////////////////////////////هیدن کردن دکمه ایجاد فاکتور 
                btn_newinvoice.Visibility = Visibility.Hidden;
                //////////////////////////نمایش کاربر ثبت کننده
                lbl_username.Content = PublicVariable.gUserName + " " + PublicVariable.gUserFamily;
                ///////نمایش کالا ها 
                ShowProduct(SearchStatement_Product);
                /////////////////////نمایش کالاهای ثبت شده در فاکتور 
                ShowProductOrdered();
                /////////////////////////////////////////نمایش اطلاعات فاکتور
                lbl_date.Content = InvoiceDate;
                lbl_customername.Content = CustomerName;
                lbl_invoiceNo.Content = InvoiceId;
                lbl_InvoicePrice.Content = InvoicePrice_foroosh;
                lbl_invoiceprice_purch.Content = InvoicePrice_kharid;
                btn_closeinvoice.Content = "بروزرسانی فاکتور";
            }


        }
        private void ShowProduct(Func<string> Search_Product)
        {
            var query = database.Database.SqlQuery<Vw_product>("Select * From Vw_product where ProductActive =1" + Search_Product());
            //MessageBox.Show(query.ToString());
            //  var u = query.ToList();
            var u = query.ToList();
            dataGrid_product.ItemsSource = u;
        }
        private string SearchStatement_Product()
        {

            string searchstring = "" ;
            if ((txt_searchproduct.Text != ""))
            {
                searchstring += " and ProductName Like '%" + txt_searchproduct.Text.Trim() + "%'";
            }
            

            return searchstring;
        }
        private void ShowInvoiceInformation()
        {
            lbl_username.Content = PublicVariable.gUserName + " " + PublicVariable.gUserFamily;
            lbl_date.Content = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar.Text));
        }
        private void ShowCustomer(Func<string> SearchInCustomer)
        {
            var query = database.Database.SqlQuery<Vw_Customer>("Select * From Vw_Customer where 1=1  and CustomerActive = 1 " + SearchInCustomer());
            //MessageBox.Show(query.ToString());
            //  var u = query.ToList();
            var u = query.ToList();
            dataGrid_customer.ItemsSource = u;
        }
        private string SearchStatement_Customer()
        {

            string searchstring = "";
            if ((txt_customername.Text != ""))
            {
                searchstring += " and CustomerName Like '%" + txt_customername.Text.Trim() + "%'";
            }
            if ((txt_customertel.Text != ""))
            {
                searchstring += " and CustomerTell Like '%" + txt_customertel.Text.Trim() + "%'";
            }
           
            return searchstring;
        }

        private void img_search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowCustomer(SearchStatement_Customer);
        }
        private void btn_newinvoice_Click(object sender, RoutedEventArgs e)
        {
            object item = dataGrid_customer.SelectedItem;
            if (item==null)
            {
                MessageBox.Show("لطفا ابتدا یک مشتری را انتخاب نمایید");
                return;
            }
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    //////////////////////////////////////////////////////////////ایجاد فاکتور جدید


                    Invoice I = new Invoice();
                    I.CustomerId = Convert.ToInt32((dataGrid_customer.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    I.InvoicePrice = 0;
                    I.InvoicePrice_purch = 0;
                    I.InvoiceDate = string.Format("{0:yyyy/MM/dd}", Convert.ToDateTime(calendar.Text));
                    I.Userid = PublicVariable.gUserId;
                    database.Invoices.Add(I);
                    database.SaveChanges();
                    ////////////////////////////////////////////////

                    ///////////////////////نمایش اطلاعات فاکتور در قسمتهای مربوطه 
                    lbl_customername.Content = (dataGrid_customer.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

                    var query = database.Database.SqlQuery<Invoice>("Select Top 1  * from Invoice order by InvoiceId desc ");

                    var result = query.ToList();
                    this.InvoiceId= result[0].InvoiceId;
                    lbl_invoiceNo.Content = this.InvoiceId;
                    ////////////////////////////////////////////////////////////////////
                    btn_selectProduct.IsEnabled = true;

                    btn_closeinvoice.IsEnabled = true;
                    ////////////////////////////////////////////////////////////////////
                    ts.Complete();

                }
                catch
                {
                    MessageBox.Show("در ایجاد فاکتور جدید مشکلی بوجود آمد . لطفا مجددا سعی کنید");
                }
                 
                finally
                {
                    btn_newinvoice.IsEnabled = false;
                }
            }
        }

        private void image_searchProduct_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowProduct(SearchStatement_Product);
        }

        private void txt_customertel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //استفاده از عبارات با قاعده برای ورود متن فقط به صورت عدد
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_productcountorder_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //استفاده از عبارات با قاعده برای ورود متن فقط به صورت عدد
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btn_selectProduct_Click(object sender, RoutedEventArgs e)
        {

            object item = dataGrid_product.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("لطفا ابتدا یک کالا را اتنخاب کنید.");
                return;
            }
            else
            {


                lbl_productname.Content = (dataGrid_product.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                lbl_product_stock.Content = (dataGrid_product.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                lbl_productprice.Content = (dataGrid_product.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                lbl_productprice_purch.Content = (dataGrid_product.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                btn_sabtekala.IsEnabled = true;
                lbl_productid.Content=Convert.ToInt32( (dataGrid_product.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

            }
        }
        private void btn_sabtekala_click(object sender, RoutedEventArgs e)
        {
                 


            object item = dataGrid_product.SelectedItem;

            /////////////////////////////////////////////////////////////////مقایسه تعداد کالای سفارش داده شده
            int ProductCountOrder = Convert.ToInt32(txt_productcountorder.Text.Trim());
            int ProductStock = Convert.ToInt32((dataGrid_product.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
            if (ProductCountOrder > ProductStock)
            {
                MessageBox.Show("تعداد سفارش داده شده از موجودی بیشتر است");
                return;
            }

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    /////////////////////////////////////////////////////////////////بررسی موجود بودن کالا در فاکتور
                    var Query = from II_search in database.InvoiceItems
                                where II_search.Invoiceid == this.InvoiceId
                                select II_search;
                    var result = Query.ToList();
                    for (int i = 0; i < result.Count; i++)
                    {
                        if (result[i].Productid == Convert.ToInt32(lbl_productid.Content))
                        {
                            MessageBox.Show("  این کالا از قبل در این فاکتور وجود دارد برای ویرایش تعداد این کالا ابتدا آن را حذف نمایید");
                            return;
                        }
                    }

                    //////////////////////////////////////////////////////////////ذخیره کالاهای سفارش داده شده 

                    InvoiceItem II = new InvoiceItem();
                    II.InvoiceItemCount = Convert.ToInt32(txt_productcountorder.Text.Trim());
                    II.InvoiceItemFeeSell = Convert.ToInt64((dataGrid_product.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
                    II.InvoiceItemPurchFee = Convert.ToInt64((dataGrid_product.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
                    II.Productid = Convert.ToInt32((dataGrid_product.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    II.Invoiceid = this.InvoiceId;

                    database.InvoiceItems.Add(II);
                    database.SaveChanges();
                    //////////////////////////////////////////////////////////////بروزرسانی موجودی کالا 
                    database.Sp_Update_ProductLastStock(-Convert.ToInt32(txt_productcountorder.Text.Trim()), II.Productid);
                    //////////////////////////////////////////////////////////////نمایش اطلاعات کالاهای سفارش داده شده
                    ShowProductOrdered();
                    ShowProduct(SearchStatement_Product);
                    lbl_InvoicePrice.Content = Convert.ToInt64(lbl_InvoicePrice.Content) + (Convert.ToInt32(txt_productcountorder.Text.Trim()) * Convert.ToInt64(lbl_productprice.Content));
                    lbl_invoiceprice_purch.Content = Convert.ToInt64(lbl_invoiceprice_purch.Content) + (Convert.ToInt32(txt_productcountorder.Text.Trim()) * Convert.ToInt64(lbl_productprice_purch.Content));

                    ts.Complete();
                }
                catch
                {
                    MessageBox.Show("در ثبت اطلاعات مشکلی بوجود آمده است");
                }
                finally
                {
                  
                     lbl_productname.Content = "...";
                    lbl_product_stock.Content = "...";
                    lbl_productprice.Content = "...";
                    txt_productcountorder.Text = "";
                    lbl_productid.Content = "...";
                    btn_sabtekala.IsEnabled = false;


                }
            }
        }

        private void ShowProductOrdered ()
        {
            var query = database.Database.SqlQuery<Vw_InvoiceItem>("Select * From Vw_InvoiceItem Where InvoiceId = " + this.InvoiceId);
            //MessageBox.Show(query.ToString());
            //  var u = query.ToList();
            var u = query.ToList();
            datagrid_productorder.ItemsSource = u;
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            object item = datagrid_productorder.SelectedItem;
            if (item == null)
            {
                return;
            }
            if (MessageBox.Show("آیا کالای انتخاب شده از فاکتور حذف شود؟", "حذف کالا", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                int getProductid = Convert.ToInt32((datagrid_productorder.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                int getProductcount = Convert.ToInt32((datagrid_productorder.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
                long getproductprice_purch = Convert.ToInt64((datagrid_productorder.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
                long getProductPrice = Convert.ToInt64((datagrid_productorder.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
                using (TransactionScope ts = new TransactionScope())
                {
                    try
                    {
                        ///////////////حذف کالا با استفاده از دستورات linq 
                        var Deletequery = (from II in database.InvoiceItems
                                           where II.Productid == getProductid

                                           where II.Invoiceid == this.InvoiceId

                                           select II).SingleOrDefault();
                        database.InvoiceItems.Remove(Deletequery);
                        database.SaveChanges();

                        ShowProductOrdered();
                        /////////////////////////////////////بروزرسانی موجودی 
                        database.Sp_Update_ProductLastStock(getProductcount, getProductid);
                        ///////////////////////////////////بروزرسانی جدول کالاها
                        ShowProduct(SearchStatement_Product);
                        ///////////////////////////////////////////بروزرسانی مبلغ کل فاکتور 

                        lbl_InvoicePrice.Content = Convert.ToInt64(lbl_InvoicePrice.Content) - (getProductPrice * getProductcount);
                        lbl_invoiceprice_purch.Content = Convert.ToInt64(lbl_invoiceprice_purch.Content) - (getproductprice_purch * getProductcount);
                        ts.Complete();
                    }
                    catch
                    {
                        MessageBox.Show("در حذف اطلاعات مشکلی بوجود آمد");
                        return;
                    }
                }
            }
        }

        private void btn_closeinvoice_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("آیا از بستن فاکتور اطمینان دارید؟","بستن فاکتور",MessageBoxButton.YesNo) ==  MessageBoxResult.Yes)
            {
                try
                {
                    Invoice Invoic = (from I in database.Invoices where I.InvoiceId == this.InvoiceId select I).SingleOrDefault();
                    Invoic.InvoicePrice = Convert.ToInt64(lbl_InvoicePrice.Content);
                    Invoic.InvoicePrice_purch = Convert.ToInt64(lbl_productprice_purch.Content);

                    Invoic.InvoiceType = 1;

                    database.SaveChanges();
                    MessageBox.Show("فاکتور با موفقیت بسته شد");
                }
                catch
                {
                    MessageBox.Show("در ثبت اطلاعات مشکلی بوجود آمد");
                    return;
                }
                finally
                {
                    ClearForm();
                }
            }
        }
        private void ClearForm()
        {
            txt_customername.Text = "";
            txt_customertel.Text = "";
            btn_newinvoice.IsEnabled = true;
            lbl_customername.Content = "...";
            lbl_invoiceNo.Content = "0";
            lbl_InvoicePrice.Content = "0";
            lbl_invoiceprice_purch.Content = "0";
            txt_searchproduct.Text = "";
            btn_selectProduct.IsEnabled = false;
            btn_sabtekala.IsEnabled = false;
            btn_closeinvoice.IsEnabled = true;
            lbl_productname.Content = "...";
            lbl_product_stock.Content = "...";
            lbl_productprice.Content = "...";
            txt_productcountorder.Text = "";
            lbl_productprice_purch.Content = "";
            lbl_productid.Content = "";
            this.InvoiceId = 0;
            datagrid_productorder.ItemsSource = null;
            datagrid_productorder.Items.Clear();

            ShowCustomer(SearchStatement_Customer);
            ShowProduct(SearchStatement_Product);
        }
    }
    
}
