using Atlas.Model_Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Log.xaml
    /// </summary>
    public partial class Log : Page
    {

        public Log()
        {

            InitializeComponent();
            Read();
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void log_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void inventory_click(object sender, RoutedEventArgs e)
        {
            deliverylog_list.Visibility = Visibility.Hidden;
            inventorylog_list.Visibility = Visibility.Visible;
            accountlog_list.Visibility = Visibility.Hidden;
            currentList.Text = "Inventory Log";
            delete_btn.IsEnabled = false;
        }

        private void delivery_click(object sender, RoutedEventArgs e)
        {
            deliverylog_list.Visibility = Visibility.Visible;
            inventorylog_list.Visibility = Visibility.Hidden;
            accountlog_list.Visibility = Visibility.Hidden;
            currentList.Text = "Sales Log";         
        }

        private void account_click(object sender, RoutedEventArgs e)
        {
            deliverylog_list.Visibility = Visibility.Hidden;
            inventorylog_list.Visibility = Visibility.Hidden;
            accountlog_list.Visibility = Visibility.Visible;
            currentList.Text = "Account Log";
            delete_btn.IsEnabled = false;
        }

        private void Read()
        {
            var db = new DataContext();
            deliverylog_list.ItemsSource = db.DelLogitems.FromSqlRaw("Select * from DelLogitems").ToList();
            inventorylog_list.ItemsSource = db.InvLogitems.FromSqlRaw("Select * from InvLogitems").ToList();
            accountlog_list.ItemsSource = db.AccLogitems.FromSqlRaw("Select * from AccLogitems").ToList();
        }
        
        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            var db = new DataContext();
            if (deliverylog_list.Visibility == Visibility.Visible)
            {
                
                Deliverylog selectedDel = deliverylog_list.SelectedItem as Deliverylog;
                db.Remove(selectedDel);
                db.SaveChanges();
                Read();
            }
            else if (inventorylog_list.Visibility == Visibility.Visible)
            {
                Inventorylog selectedDel = inventorylog_list.SelectedItem as Inventorylog;
                db.Remove(selectedDel);
                db.SaveChanges();
                Read();
            }
            else if (accountlog_list.Visibility == Visibility.Visible)
            {
                Accountlog selectedDel = accountlog_list.SelectedItem as Accountlog;
                db.Remove(selectedDel);
                db.SaveChanges();
                Read();
            }
        }

        private void deliverylog_list_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
                delete_btn.IsEnabled = true;
        }

        private void print_btn_Click(object sender, RoutedEventArgs e)
        {
            var db = new DataContext();
            if (deliverylog_list.Visibility == Visibility.Visible)
            {
                try
                {
                    this.IsEnabled = false;
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(deliverylog_list, "Invoice");
                    }
                }
                finally
                {
                    this.IsEnabled = true;
                }
            }
            else if (inventorylog_list.Visibility == Visibility.Visible)
            {
                try
                {
                    this.IsEnabled = false;
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(inventorylog_list, "Invoice");
                    }
                }
                finally
                {
                    this.IsEnabled = true;
                }
            }
            else if (accountlog_list.Visibility == Visibility.Visible)
            {
                try
                {
                    this.IsEnabled = false;
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(accountlog_list, "Invoice");
                    }
                }
                finally
                {
                    this.IsEnabled = true;
                }
            }
        }
    }
}
