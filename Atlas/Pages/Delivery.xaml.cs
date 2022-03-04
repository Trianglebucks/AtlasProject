﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System;
using Microsoft.EntityFrameworkCore;
using Atlas.Model_Classes;

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for Delivery.xaml
    /// </summary>
    public partial class Delivery : Page
    {
        public static CSDelivery selectedDel;

        
        public List<CSDelivery> deliveries { get; private set; }
        public static string TrackingNumber;
        public static int CustomerID;
        public static string Address;
        public static int Quantity;
        public static float Total;
        public static string OrderDate;

        public Delivery()
        {
            InitializeComponent();
            Read();
        }

        private void SearchBar_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(delivery_list.ItemsSource).Refresh();
        }

        private void delivery_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                //deliveries = context.Deliveries.ToList();               
                //deliveries = context.Deliveries.OrderByDescending(d => d.OrderDate).ToList();
                //if (deliveries.Count > 0)
                    //delivery_list.ItemsSource = context.Deliveries.ToList();
                delivery_list.ItemsSource = context.Deliveries.FromSqlRaw("Select * FROM Deliveries ORDER BY OrderDate").ToList();

            }
        }

        private void add_btn_click(object sender, RoutedEventArgs e)
        {
            AddDelivery gotopage = new AddDelivery();
            this.NavigationService.Navigate(gotopage);
        }

        private void item_dbl_click(object sender, MouseButtonEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                var item = delivery_list.SelectedItem as CSDelivery;

                if (item != null)
                {
                    CSDelivery cSDelivery = context.Deliveries.Find(item.TrackingNumber);
                    //TrackingNumber = cSDelivery.TrackingNumber;
                    //CustomerID = cSDelivery.CustomerID;
                    //Address = cSDelivery.Address; //change product ID to address...
                    //Quantity = cSDelivery.Quantity; //display total quantity of items ordered
                    //Total = cSDelivery.Amount;      //display total amount of orders
                    //OrderDate = cSDelivery.OrderDate;
                    //selectedDel = (CSDelivery)delivery_list.SelectedItems[0];

                    Invoice popup = new Invoice();
                    var selCus = context.Customers.Single(b => b.ID == cSDelivery.CustomerID);
                    popup.cust_name.Text = selCus.CustomerName;
                    popup.date_issued.Text = cSDelivery.OrderDate;
                    popup.tracking_no.Text = cSDelivery.TrackingNumber.ToString();
                    popup.cust_address.Text = cSDelivery.Address;
                    popup.cust_connum.Text = selCus.ContactNumber;
                    var invoice_items = context.Invoiceitems.FromSqlRaw("SELECT Brand ||' '|| ProductName as Brand, Quantity, UnitPrice, TotPrice " +
                            "FROM Orderitems WHERE TrackingNumber = {0}", cSDelivery.TrackingNumber).ToList();
                    popup.Invoice_list.ItemsSource = invoice_items;
                    var totalamt = context.Deliveries.Single(b => b.TrackingNumber == cSDelivery.TrackingNumber);

                    popup.total_amount.Text = '₱' + totalamt.Amount.ToString("n2");

                    popup.ShowDialog();


                    //Delivery_Item_List gotopage = new Delivery_Item_List();
                    //this.NavigationService.Navigate(gotopage);
                }
            }
        }

        private void btnCustomer(object sender, RoutedEventArgs e)
        {
            //Customer gotopage = new Customer();
            //this.NavigationService.Navigate(gotopage);
            
        }

        private void delivery_list_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            delete_btn.IsEnabled = true;
        }

        private void delete_order(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                var result = MessageBox.Show("Delete selected item?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    CSDelivery delOrder = delivery_list.SelectedItem as CSDelivery;


                    context.Remove(delOrder);
                    context.SaveChanges();
                    Read();


                }
                else if (result == MessageBoxResult.No)
                {
                    Read();
                }
            }
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {

            using (DataContext context = new DataContext())
            {
                var trackingNumber = SearchBar.Text + "%";
                if (String.IsNullOrEmpty(trackingNumber))
                    delivery_list.ItemsSource = context.Deliveries.OrderByDescending(d => d.OrderDate).ToList();
                else
                    delivery_list.ItemsSource = context.Deliveries.FromSqlRaw("SELECT * FROM Deliveries WHERE TrackingNumber LIKE {0}", trackingNumber).ToList();
            }
        }

        private void search_enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                using (DataContext context = new DataContext())
                {
                    var trackingNumber = SearchBar.Text;
                    if (String.IsNullOrEmpty(trackingNumber))
                        delivery_list.ItemsSource = context.Deliveries.OrderByDescending(d => d.OrderDate).ToList();
                    else
                        delivery_list.ItemsSource = context.Deliveries.FromSqlRaw("SELECT * FROM Deliveries WHERE TrackingNumber = {0}", trackingNumber).ToList();
                }
            }
        }
    }
}