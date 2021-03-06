using Atlas.Model_Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for _2ndPageAddDel.xaml
    /// </summary>
    public partial class _2ndPageAddDel : Page
    {
        private static float Price = 0f;
        //private static float iniTotal;

        public delegate void SendBool(bool Valid);

        public static event SendBool onValidsend;

        ObservableCollection<iniOrder> iniitem = new ObservableCollection<iniOrder>();

        public _2ndPageAddDel()
        {
           
            InitializeComponent();
            
            Category_Cmbox.Text = "All";
            DateTime date = DateTime.Now;
            Read();
            SelCustomer();

        }
        private void inventory_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //btn_Order_Click(sender, e);
        }
        private void initial_Order_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Category filter
        private void Category_Cmbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem category = (ComboBoxItem)Category_Cmbox.SelectedItem;

            string strCategory = category.Content.ToString();
            var db = new DataContext();
            if (strCategory == "All")
            {
                Read();
            }
            else
                inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products where Category = {0}", strCategory).ToList();
   
            //MessageBox.Show(category.Content.ToString());





        }
        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Cancel_Orders();
        }

        //Parcel is added to delivery
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            //Create();
            var result = MessageBox.Show("Confirm Order?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Random rnd = new Random();
                int TrackingNumint = rnd.Next(100000000, 999999999);
                string TrackingNum = "PH" + TrackingNumint.ToString() + "AT";

                using (DataContext context = new DataContext())
                {
                    if (initial_Order.HasItems)
                    {
                        var finOrder = iniitem.ToList();

                        int custQuantity = 0;
                        float custTotal = 0;
                        DateTime date = DateTime.Now;
                        CultureInfo ci = CultureInfo.InvariantCulture;

                        var orderdate = date.ToString("yyyy-MM-dd HH:mm:ss", ci);
                        foreach (var eachorder in finOrder)
                        {
                            var finalID = int.Parse(eachorder.ProductID.ToString());
                            var finalQuan = int.Parse(eachorder.Quantity.ToString());
                            var finalpri = float.Parse(eachorder.Price.ToString());
                            var finaltot = float.Parse(eachorder.Total.ToString());

                            var prodobj = context.Products.Single(b => b.ID == finalID);
                            var finalbrand = prodobj.Brand;
                            var finalprodname = prodobj.ProductName;
                            var finalmeas = prodobj.Measurement;
                            var finalcolor = prodobj.Color;

                            context.Orderitems.Add(new CSOrderitems()
                            {
                                TrackingNumber = TrackingNum,
                                ProductID = finalID,
                                Brand = finalbrand,
                                Measurement = finalmeas,
                                Color = finalcolor,
                                ProductName = finalprodname,
                                Quantity = finalQuan,
                                UnitPrice = finalpri,
                                TotPrice = finaltot,
                                OrderDate = orderdate
                            });

                            custQuantity += finalQuan;
                            custTotal += finaltot;


                        }
                        foreach (var item in finOrder)
                        {
                            iniitem.Remove(item);                                                        
                        }
                        
                        var customerid = AddDelivery.selectedCus.ID;
                        var custaddress = AddDelivery.selectedCus.Address;
                        var custconnum = AddDelivery.selectedCus.ContactNumber;
                        var customername = AddDelivery.selectedCus.CustomerName;

                        context.Deliveries.Add(new CSDelivery()
                        {
                            TrackingNumber = TrackingNum,
                            CustomerID = customerid,
                            CustomerName = customername,
                            Address = custaddress,
                            Amount = custTotal,
                            Quantity = custQuantity,
                            OrderDate = orderdate

                        });


                        //deliverylog
                        context.DelLogitems.Add(new Deliverylog()
                        {
                            TrackingNumber = TrackingNum,
                            CustomerID = customerid,
                            Address = custaddress,
                            Amount = custTotal,
                            Quantity = custQuantity,
                            OrderDate = orderdate
                        });

                        context.SaveChanges();
                       // MessageBox.Show("Done!");
                        Read();
                        Price = 0;
                        totalamount.Text = Price.ToString();

                        //Shows invoice
                        Invoice popup = new Invoice();
                        popup.cust_name.Text = customername;
                        popup.date_issued.Text = orderdate;
                        popup.tracking_no.Text = TrackingNum.ToString();
                        popup.cust_address.Text = custaddress;
                        popup.cust_connum.Text = custconnum;
                        //var invoice_items = context.Invoiceitems.FromSqlRaw("SELECT Brand, Quantity, UnitPrice, TotPrice " +
                        //    "FROM Orderitems as o JOIN Products as p on o.ProductID = p.ID AND TrackingNumber = {0}", TrackingNum).ToList();

                        var invoice_items = context.Invoiceitems.FromSqlRaw("SELECT Brand ||' '|| ProductName ||' ('|| Color ||'-'|| Measurement ||')' as Brand, Quantity, UnitPrice, TotPrice " +
                            "FROM Orderitems WHERE TrackingNumber = {0}", TrackingNum).ToList();
                        popup.Invoice_list.ItemsSource = invoice_items;
                        var totalamt = context.Deliveries.Single(b => b.TrackingNumber == TrackingNum);

                        popup.total_amount.Text = '₱' + totalamt.Amount.ToString("n2");

                        
                        //popup.ShowDialog();

                        if ((bool)popup.ShowDialog())
                        {
                            onValidsend(true);
                            Delivery gotopage = new Delivery();
                            this.NavigationService.Navigate(gotopage);                        

                        }
                        
                    }
                    else
                    {                        
                        totalamount.Text = Price.ToString();
                        MessageBox.Show("No products to add!");
                    }                  
                }               
            }
            else if (result == MessageBoxResult.No)
            {                
                Read();
            }
        }

        private void btn_Order_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                orderBtn(sender);

            }
            catch (Exception)
            {

                MessageBox.Show("error!");
            }
        }

        //removes selected item
        private void remove_item_Click(object sender, RoutedEventArgs e)
        {
            if (initial_Order.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Remove Item", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                       
            
                if (result == MessageBoxResult.Yes)
                {
                var remove_sel_item = (iniOrder)initial_Order.SelectedItems[0];
                using (DataContext context = new DataContext())
                {
                    var cancelOrderQuantity = remove_sel_item.Quantity;
                    var productUpdate = context.Products.Single(b => b.ID == remove_sel_item.ProductID);
                    productUpdate.Stocks += cancelOrderQuantity;
                    context.Products.Update(productUpdate);                    
                    iniitem.Remove(remove_sel_item);
                    context.SaveChanges();
                }
                    //MessageBox.Show("Item removed!");
                    Price -= remove_sel_item.Total;
                    totalamount.Text = Price.ToString("n2");
                Read();                  
                }
                else if (result == MessageBoxResult.No)
                Read();
            }
            else MessageBox.Show("Select an item to be remove.");

        }

        //For initial orders
        private void orderBtn(object sender)
        {
            try
            {
                CSProduct selProduct = (CSProduct)inventory_list.SelectedItems[0];
                Button targetbutton = (sender as Button);

                if (targetbutton != null && targetbutton.Name == "btn_Order")
                {
                    if (inventory_list.SelectedItems.Count > 0)
                    {
                        using (DataContext context = new DataContext())
                        {
                            var db = new DataContext();
                            var quantityval = int.Parse(quantityValue.Text);
                            var uprice = float.Parse(selProduct.Price.ToString());
                            var productnameval = selProduct.ProductName.ToString();
                            var prodid = int.Parse(selProduct.ID.ToString());
                            var iniTotal = quantityval * uprice;
                            Price += iniTotal;


                            var id = selProduct.ID;

                            if (selProduct.Stocks >= int.Parse(quantityValue.Text) && selProduct.Stocks != 0)
                            {

                                if (iniitem.Any(p => p.ProductID == id))
                                {
                                    /*MessageBox.Show("Already exists");*/
                                    iniOrder duplicateOrd = iniitem.Where(x => x.ProductID == id).FirstOrDefault();
                                    var requantityval = duplicateOrd.Quantity + quantityval;
                                    duplicateOrd.Quantity = requantityval;
                                    duplicateOrd.Total = requantityval * duplicateOrd.Price;
                                    selProduct.Stocks = selProduct.Stocks - quantityval;
                                    context.Products.Update(selProduct);
                                    context.SaveChanges();
                                }
                                else if (!iniitem.Any(p => p.ProductID == id))
                                {
                                  //  MessageBox.Show("Added! Second");
                                    iniitem.Add(new iniOrder()
                                    {
                                        ProductID = prodid,
                                        ProductName = productnameval,
                                        Quantity = quantityval,
                                        Price = uprice,
                                        Total = iniTotal                                 
                                    });
                                    selProduct.Stocks = selProduct.Stocks - quantityval;
                                    context.Products.Update(selProduct);
                                    context.SaveChanges();
                                }
                                
                                Read();                                
                                totalamount.Text = Price.ToString("n2");
                            }
                            else if (selProduct.Stocks == 0)
                            {
                                
                                MessageBox.Show("Selected Product is out of stocks!");
                                Price -= uprice;
                                

                            }
                            else
                            {                                
                                MessageBox.Show("Stocks is lower than the quantity required");
                            }                               
                        }
                    }
                    else
                        MessageBox.Show("No product Selected.\nPlease select a Product!");
                }
            }
            catch (Exception)
            {
              MessageBox.Show("Select Product First!");
            }


        }

        //Reads from local database
        public void Read()
        {

            var db = new DataContext();

            inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products").ToList();
            //initial_Order.ItemsSource = db.Orders.FromSqlRaw("Select * from Orders").ToList();
            initial_Order.ItemsSource = iniitem;
            
        }

        //Goes back
       private void go_back_btn_click(object sender, RoutedEventArgs e)
        {
            Go_Back();
            
            /*AddDelivery gotopage = new AddDelivery();
            this.NavigationService.Navigate(gotopage);*/
        }

        //Selects customer
        public void SelCustomer()
        {
            sel_Customerlbl.Content = AddDelivery.selectedCus.CustomerName.ToString();
        }

        //Deletes initial orders
        public void Cancel_Orders()
        {
            var result = MessageBox.Show("Cancel Orders?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                using (DataContext context = new DataContext())
                {
                    var cancelOrder = iniitem.ToList();

                    foreach (var item in cancelOrder)
                    {
                        var cancelOrderQuantity = item.Quantity;
                        var productUpdate = context.Products.Single(b => b.ID == item.ProductID);
                        productUpdate.Stocks += cancelOrderQuantity;
                        context.Products.Update(productUpdate);
                        Price = 0;
                        totalamount.Text = Price.ToString();
                        iniitem.Remove(item);
                    }
                    context.SaveChanges();
                   // MessageBox.Show("Orders cancelled!");
                    Read();
                    
                }
            }
            else if (result == MessageBoxResult.No)
            {
                Read();
            }
            
        }

        public void Go_Back()
        {
            
            var result = MessageBox.Show("Go back to Choosing Customer?\n Your order will not be saved."
                , "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                using (DataContext context = new DataContext())
                {
                    var cancelOrder = iniitem.ToList();

                    foreach (var item in cancelOrder)
                    {
                        var cancelOrderQuantity = item.Quantity;
                        var productUpdate = context.Products.Single(b => b.ID == item.ProductID);
                        productUpdate.Stocks += cancelOrderQuantity;
                        context.Products.Update(productUpdate);
                        iniitem.Remove(item);
                    }
                    context.SaveChanges();



                    Read();
                }
                onValidsend(true);
                /*Price = 0;
                totalamount.Text = Price.ToString();*/
                AddDelivery gotopage = new AddDelivery();
                this.NavigationService.Navigate(gotopage);
               
            }
            else if (result == MessageBoxResult.No)
            {
                Read();
            }

        }

        public class iniOrder : INotifyPropertyChanged
        {
            private int idvalue;
            public int ID { get { return idvalue; } set { idvalue = value; RaiseProperChanged(); } }

            private int prodidvalue;
            public int ProductID { get { return prodidvalue; } set { prodidvalue = value; RaiseProperChanged(); } }

            private string prodnamevalue;
            public string ProductName { get { return prodnamevalue; } set { prodnamevalue = value; RaiseProperChanged(); } }

            private int quantityvalue;
            public int Quantity { get { return quantityvalue; } set { quantityvalue = value; RaiseProperChanged(); } }

            private float pricevalue;
            public float Price { get { return pricevalue; } set { pricevalue = value; RaiseProperChanged(); } }

            private float totalvalue;
            public float Total { get { return totalvalue; } set { totalvalue = value; RaiseProperChanged(); } }

            public event PropertyChangedEventHandler PropertyChanged;
            private void RaiseProperChanged([CallerMemberName] string caller = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(caller));
                }
            }
        }
    }
}