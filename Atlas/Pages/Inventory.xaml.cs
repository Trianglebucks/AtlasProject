using Atlas.Model_Classes;
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
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Page
    {
     
        public List<CSProduct> products { get; private set; }
        public static  int ID;
        public static CSProduct selectedPro;

        //public static string productName;
        //public static float price;
        //public static string measurement;
        //public static string color;
        //public static string category;
        //public static int stocks;

        public Inventory()
        {
            InitializeComponent();
            Read();
            sortAvailability.Text = "All";
            Category_Cmbox.Text = "All";
        }
        public DataTemplate ItemTemplate { get; set; }

        private void add_btn_click(object sender, RoutedEventArgs e)
        {
            AddInventory gotopage = new AddInventory();
            this.NavigationService.Navigate(gotopage);
        }
        private void delete_btn_click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Delete selected item?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                using (DataContext context = new DataContext())
                {
                    if (inventory_list.SelectedItems.Count > 0)
                    {
                        CSProduct delProduct = inventory_list.SelectedItem as CSProduct;
                        DateTime date = DateTime.Now;
                        CultureInfo ci = CultureInfo.InvariantCulture;

                        var orderdate = date.ToString("yyyy-MM-dd HH:mm:ss", ci);

                        context.InvLogitems.Add(new Inventorylog()
                        {
                            ProdID = delProduct.ID,
                            ProductName = delProduct.ProductName,
                            Brand = delProduct.Brand,
                            Price = delProduct.Price,
                            Measurement = delProduct.Measurement,
                            Color = delProduct.Color,
                            Category = delProduct.Category,
                            Stocks = delProduct.Stocks,
                            Defectives = delProduct.Defectives,
                            Date = orderdate,
                            LogActivity = "Delete"
                        }) ;

                        context.Remove(delProduct);
                        context.SaveChanges();
                        Read();
                    }
                    else
                        MessageBox.Show("Please select a product to be deleted!");
                }
            }
            else if (result == MessageBoxResult.No)
            {
                Read();
            }
            
        }
        private void edit_btn_click(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                if (inventory_list.SelectedItems.Count > 0)
                {
                    CSProduct product = inventory_list.SelectedItem as CSProduct;
                    ID = product.ID;
                    //productName = product.ProductName;
                    //price = product.Price;
                    //measurement = product.Measurement;
                    //color = product.Color;
                    //category = product.Category;
                    //stocks = product.Stocks;
                    
                    EditInventory gotopage = new EditInventory();
                    this.NavigationService.Navigate(gotopage);
                }
                else
                    MessageBox.Show("Please select a product to edit!");
            }            
        }
        private void inventory_list_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            delete_btn.IsEnabled = true;
            edit_btn.IsEnabled = true;
            defectives_btn.IsEnabled = true;
        }

        public void Read()
        {
            
            var db = new DataContext();
            inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products ORDER BY ProductName").ToList();
            
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            /*if (!String.IsNullOrEmpty(SearchField.Text) && Category_Cmbox.SelectedIndex > -1)*/
            if (!String.IsNullOrEmpty(SearchField.Text))
            {
                ComboBoxItem category = (ComboBoxItem)Category_Cmbox.SelectedItem;
                ComboBoxItem status = (ComboBoxItem)sortAvailability.SelectedItem;

                string strCategory = category.Content.ToString();
                string strStatus = status.Content.ToString();
                using (DataContext context = new DataContext())
                {
                    //MessageBox.Show("Hello 1");
                    var input =   SearchField.Text.ToString()  + "%" ;
                    /*ComboBoxItem combCategory = (ComboBoxItem)Category_Cmbox.SelectedItem;
                    string category = combCategory.Content.ToString();*/
                    //MessageBox.Show(input);
                    //inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0} AND Category = {1}", input, category).ToList();

                    if (strCategory == "All" &&  strStatus == "All")
                    {
                        inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0}",input).ToList();

                    }
                    else if (strCategory == "All" && strStatus == "Available")
                    {
                        inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0} AND Stocks > 0", input).ToList();

                    }
                    else if (strCategory == "All" && strStatus == "Unavailable")
                    {
                        inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0} AND Stocks = 0", input).ToList();

                    }
                    else if (strCategory == "Art Materials" || strCategory == "Books" || strCategory == "School Supplies" || strCategory == "Stationary Items" && strStatus == "All")
                    {
                        inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0} AND Category = {1}", input, strCategory).ToList();

                    }
                    else if (strCategory == "Art Materials" || strCategory == "Books" || strCategory == "School Supplies" || strCategory == "Stationary Items" && strStatus == "Available")
                    {
                        inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0} AND Category = {1} AND Stocks > 0", input, strCategory).ToList();
                    }
                    else if (strCategory == "Art Materials" || strCategory == "Books" || strCategory == "School Supplies" || strCategory == "Stationary Items" && strStatus == "Unavailable")
                    {
                        inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0} AND Category = {1} AND Stocks = 0", input, strCategory).ToList();
                    }
                }
            }
            /*else if(!String.IsNullOrEmpty(SearchField.Text) && Category_Cmbox.SelectedIndex == -1)
            {
                using (DataContext context = new DataContext())
                {
                    //MessageBox.Show("Hello 2");

                    var input = SearchField.Text + "%";
                    ComboBoxItem combCategory = (ComboBoxItem)Category_Cmbox.SelectedItem;
                    //MessageBox.Show(input);
                    inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0}", input).ToList();
                }
            }*/
            else
            {
                using (DataContext context = new DataContext())
                {
                    
                    inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products").ToList();
                }
            }

        }
        private void Category_Cmbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem category = (ComboBoxItem)Category_Cmbox.SelectedItem;
            string strCategory = category.Content.ToString();
            SearchField.Text = String.Empty;
            var db = new DataContext();
            if(strCategory == "All")
            {
                Read();
            }
            else
                inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products where Category = {0}", strCategory).ToList();
        }

        private void change_availability(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem category = (ComboBoxItem)sortAvailability.SelectedItem;
            string strCategory = category.Content.ToString();
            var noStock = 0;
            var db = new DataContext();

            if (strCategory == "Available")
            {
                inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products where Stocks > {0}", noStock).ToList();
            }
            else if (strCategory == "Unavailable")
            {
                inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products where Stocks = {0}", noStock).ToList();
            }
            else
                inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products").ToList();

        }

        private void search_enter(object sender, KeyEventArgs e)
        {
            ComboBoxItem category = (ComboBoxItem)Category_Cmbox.SelectedItem;
            ComboBoxItem status = (ComboBoxItem)sortAvailability.SelectedItem;

            string strCategory = category.Content.ToString();
            string strStatus = status.Content.ToString();
            if (e.Key == Key.Return)
            {
                using (DataContext context = new DataContext())
                {
                    var input = SearchField.Text.ToString() + "%";

                    if (strCategory == "All" && strStatus == "All")
                    {
                        inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0}", input).ToList();

                    }
                    else if (strCategory == "All" && strStatus == "Available")
                    {
                        inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0} AND Stocks > 0", input).ToList();

                    }
                    else if (strCategory == "All" && strStatus == "Unavailable")
                    {
                        inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0} AND Stocks = 0", input).ToList();

                    }
                    else if (strCategory == "Art Materials" || strCategory == "Books" || strCategory == "School Supplies" || strCategory == "Stationary Items" && strStatus == "All")
                    {
                        inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0} AND Category = {1}", input, strCategory).ToList();

                    }
                    else if (strCategory == "Art Materials" || strCategory == "Books" || strCategory == "School Supplies" || strCategory == "Stationary Items" && strStatus == "Available")
                    {
                        inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0} AND Category = {1} AND Stocks > 0", input, strCategory).ToList();
                    }
                    else if (strCategory == "Art Materials" || strCategory == "Books" || strCategory == "School Supplies" || strCategory == "Stationary Items" && strStatus == "Unavailable")
                    {
                        inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0} AND Category = {1} AND Stocks = 0", input, strCategory).ToList();
                    }

                }
            }            
        }

        private void defectives_btn_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Defectives popup = new Defectives();
                selectedPro = inventory_list.SelectedItem as CSProduct;
                popup.cur_item.Content = selectedPro.Brand + " - " + selectedPro.ProductName;
                popup.def_quantity.Text = selectedPro.Defectives.ToString();

                if ((bool)popup.ShowDialog())
                {
                    Read();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a Product!");
            }
            
        }

    }
}
