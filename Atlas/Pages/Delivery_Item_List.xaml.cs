using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Atlas.Model_Classes;
using System.Collections.Generic;
using System;

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for Delivery_Item_List.xaml
    /// </summary>
    public partial class Delivery_Item_List : Page
    {
        
        public Delivery_Item_List()
        {
            InitializeComponent();
            Information();
            
        }
        public void Information()
        {           
            using (DataContext context = new DataContext())
            {
                CSCustomer cSCustomer = context.Customers.Find(Delivery.CustomerID);
                customerName.Content = cSCustomer.CustomerName;
                customerAddress.Content = cSCustomer.Address;
                quantity.Text = Delivery.Quantity.ToString();
                total.Text = "P" + Delivery.Total.ToString();
                trackingNumber.Content = Delivery.TrackingNumber;

                itemsTable.ItemsSource = null;

                //var DeliObject = from d in context.Deliveries
                //                 join o in context.Orderitems on d.TrackingNumber equals o.TrackingNumber
                //                 join p in context.Products on o.ProductID equals p.ID

                var customerid = Delivery.selectedDel.TrackingNumber;

                var DeliObject = from o in context.Orderitems
                                 from p in context.Products
                                 where o.ProductID == p.ID && o.TrackingNumber == customerid
                                 select new 
                                 {
                                     id = o.ProductID,
                                     productName = p.ProductName,
                                     price = o.UnitPrice,
                                     quantity = o.Quantity,
                                     amount = o.TotPrice
                                 };
                //foreach (var item in DeliObject)
                //{
                //    MessageBox.Show($"{item.productName} + {item.quantity}");
                //    itemsTable.ItemsSource = item;
                //    //Console.WriteLine();
                //}

                itemsTable.ItemsSource = DeliObject.ToList();

                //itemsTable.ItemsSource = context.DeliInfos.FromSqlRaw("SELECT Products.ID, ProductName, Price, Quantity, Amount " +
                //                                                      "FROM Products " +
                //                                                      "Inner JOIN Deliveries ON Deliveries.ProductID = Products.ID " +
                //                                                      "INNER JOIN Customers ON Customers.ID = Deliveries.CustomerID " +
                //                                                      "WHERE CustomerID = {0}", Delivery.CustomerID).ToList();

            }
        }

       
        private void close_btn_click(object sender, RoutedEventArgs e)
        {
            Delivery gotopage = new Delivery();
            this.NavigationService.Navigate(gotopage);
        }

        private void itemsTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void invoice_click(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                CSCustomer cSCustomer = context.Customers.Find(Delivery.CustomerID);
                Invoice popup = new Invoice();
                popup.cust_name.Text = cSCustomer.CustomerName;
                popup.date_issued.Text = Delivery.OrderDate;
                popup.tracking_no.Text = Delivery.TrackingNumber.ToString();
                var TrackingNum = Delivery.TrackingNumber;

                popup.cust_address.Text = cSCustomer.Address;
                popup.cust_connum.Text = cSCustomer.ContactNumber;

                var invoice_items = context.Invoiceitems.FromSqlRaw("SELECT Brand, Quantity, UnitPrice, TotPrice FROM Orderitems as o JOIN Products as p on o.ProductID = p.ID AND TrackingNumber = {0}", TrackingNum).ToList();
                popup.Invoice_list.ItemsSource = invoice_items;

                var totalamt = context.Deliveries.Single(b => b.TrackingNumber == TrackingNum);
                popup.total_amount.Text = '₱' + totalamt.Amount.ToString();
                popup.ShowDialog();
            }
        }
    }
}
