using Atlas.Model_Classes;
using Atlas.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Atlas
{
    /// <summary>
    /// Interaction logic for Defectives.xaml
    /// </summary>
    public partial class Defectives : Window 
    {
        public Defectives()
        {
            InitializeComponent();
        }

        private void Close_btn_Click(object sender, RoutedEventArgs e)
        {
                this.Close();
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            var db = new DataContext();
            CSProduct product = db.Products.Find(Inventory.selectedPro.ID);
            DateTime date = DateTime.Now;
            CultureInfo ci = CultureInfo.InvariantCulture;

            var orderdate = date.ToString("yyyy-MM-dd HH:mm:ss", ci);
            try
            {
                var quanti_Def = int.Parse(def_quantity.Text);
               
                if (quanti_Def > product.Defectives)
                {
                    var newquantimin = quanti_Def - product.Defectives;
                    product.Defectives = quanti_Def;
                    if ((product.Stocks - newquantimin) < 0)
                    {
                        MessageBox.Show("stocks is now negative!");
                    }
                    else
                    {
                        product.Stocks = product.Stocks - newquantimin;

                        //db.InvLogitems.Add(new Inventorylog()
                        //{
                        //    ProdID = product.ID,
                        //    ProductName = product.ProductName,
                        //    Brand = product.Brand,
                        //    Price = product.Price,
                        //    Measurement = product.Measurement,
                        //    Color = product.Color,
                        //    Category = product.Category,
                        //    Stocks = product.Stocks,
                        //    Defectives = product.Defectives,
                        //    Date = orderdate,
                        //    LogActivity = "Update"
                        //});

                        db.SaveChanges();
                        //                        MessageBox.Show("Saved!");
                        DialogResult = true;
                        this.Close();

                    }

                }
                else if (quanti_Def < product.Defectives)
                {
                    var newquantiadd = product.Defectives - quanti_Def;
                    product.Defectives = quanti_Def;
                    product.Stocks = product.Stocks + newquantiadd;
                    //db.InvLogitems.Add(new Inventorylog()
                    //{
                    //    ProdID = product.ID,
                    //    ProductName = product.ProductName,
                    //    Brand = product.Brand,
                    //    Price = product.Price,
                    //    Measurement = product.Measurement,
                    //    Color = product.Color,
                    //    Category = product.Category,
                    //    Stocks = product.Stocks,
                    //    Defectives = product.Defectives,
                    //    Date = orderdate,
                    //    LogActivity = "Update"
                    //});

                    db.SaveChanges();
                    //MessageBox.Show("Saved!");
                    DialogResult = true;
                    this.Close();
                }
                else if (quanti_Def == product.Defectives)
                {
                    MessageBox.Show("Current input is same as current defectives!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Input!");              
            }
                 
          
        }
    }
}
