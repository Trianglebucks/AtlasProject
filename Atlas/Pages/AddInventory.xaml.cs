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

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for AddInventory.xaml
    /// </summary>
    public partial class AddInventory : Page
    {
        public AddInventory()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            var context = new DataContext();
            if (!(String.IsNullOrEmpty(product_name.Text) && String.IsNullOrEmpty(price.Text) && String.IsNullOrEmpty(category.Text)))
            {
                try
                {
                    bool isvalid = true;
                    var product = product_name.Text;
                    var cost = 0f;
                    var _stocks = 0;
                    if (price.Text.All(char.IsDigit) && stocks.Text.All(char.IsDigit))
                    {
                        _stocks = int.Parse(stocks.Text);
                        cost = float.Parse(price.Text);                      
                    }
                    else
                    {
                        isvalid = false;
                        MessageBox.Show("Invalid input");
                    }

                    var measure = measurement.Text;
                    var _color = color.Text;
                    var _category = category.Text;

               
                    
                    var _brand = brand.Text;



                    //if (product != null && cost != null && _color != null && _category != null && _status != null && _stocks != null)
                    if (isvalid)
                    {
                        context.Products.Add(new CSProduct()
                        {
                            ProductName = product,
                            Brand = _brand,
                            Price = cost,
                            Measurement = measure,
                            Color = _color,
                            Category = _category,
                            Stocks = _stocks,
                            Defectives = 0,
                        });
                        context.SaveChanges();

                        MessageBox.Show("Successsfully added!");

                        Inventory gotopage = new Inventory();
                        this.NavigationService.Navigate(gotopage);
                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("Some information are still missing!");
                }
                //Create();
               
            }
            else
                MessageBox.Show("Please fill the needed information!");


        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Inventory gotopage = new Inventory();
            this.NavigationService.Navigate(gotopage);
        }

        //public void Create()
        //{
        //    using (DataContext context = new DataContext())
        //    {
                
               
                
                


        //            //var max = context.Products.Max(p => p.ID);
        //            //var lastrecord = context.Products.FirstOrDefault(x => x.ID == max);
        //            //context.InvLogitems.Add(new Inventorylog()
        //            //{
        //            //    ProdID = lastrecord.ID,
        //            //    ProductName = product,
        //            //    Brand = _brand,
        //            //    Price = cost,
        //            //    Measurement = measure,
        //            //    Color = _color,
        //            //    Category = _category,
        //            //    Stocks = _stocks,
        //            //    Defectives = 0,
        //            //    LogActivity = "Add"
        //            //}); 

        //            //  context.SaveChanges();
        //    }
        //}
    }
}
