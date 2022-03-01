using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Atlas.Model_Classes;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SQLite;

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        static string conn = @"Data Source=dbv3.db";
        SQLiteConnection connection = new SQLiteConnection(conn);
        public Home()
        {
            InitializeComponent();  
            

            Read();

            SetProductCount();
            SetCategoryCount();
            SetSalesCount();

        }
        public void  SetProductCount()
        {
            using (DataContext context = new DataContext()) 
            {
                List<CSProduct> products = context.Products.ToList();
                if (products.Count > 0)
                    productCount.Content = products.Count;
                else
                    productCount.Content = "0";
            }
            
        }

        public void SetCategoryCount()
        {
            categoryCount.Content = "4";
        }

        public void SetSalesCount()
        {
            using (DataContext context = new DataContext())
            {
                var totalsales = context.Deliveries.Sum(t => t.Amount);
                
                salesCount.Text = totalsales.ToString("#,##0.##");
            }
        }

        public void Read()
        {

            var db = new DataContext();

            using (DataContext context = new DataContext())
            {
                //var topitems = (from o in context.Orderitems
                //                join p in context.Products
                //                on o.ProductID equals p.ID

                //                orderby o.TotPrice descending
                //                select new
                //                {
                //                    ProductName = p.ProductName,
                //                    TotalSold = o.TotPrice,
                //                    TotalQuantity = o.Quantity

                //                }).Take(3);
                var curDate = DateTime.Now;
                var curYear = curDate.ToString("yyyy-MM-dd").Substring(0, 4);
                var add = "Add";
                var update = "Update";
                try
                {
                    connection.Open();
                    // create trigger
                    string top3view = "CREATE VIEW IF NOT EXISTS top3view AS SELECT ProductName, TotalPrice as TotalSold, Quantity as TotalQuantity FROM (SELECT ProductID, SUM(TotPrice) as TotalPrice, SUM(Quantity) as Quantity FROM Orderitems GROUP by ProductID Order By TotPrice DESC) as a Join Products on a.ProductID = Products.ID Order By TotalPrice DESC LIMIT 3 ";
                    string monthlysalesview = "CREATE VIEW IF NOT EXISTS monthlysalesview AS SELECT T.Month, ifnull(SUM(D.Amount), 0) as Amount FROM TopSalesDates as T LEFT JOIN Deliveries as D ON T.ID = substr(OrderDate, 6, 2) AND substr(OrderDate, 1, 4) = '" + curYear + "' Group By T.Month Order By T.ID; ";
                    string inserttrigger_prod = "CREATE TRIGGER IF NOT EXISTS inserttrigger_prod AFTER INSERT ON Products FOR EACH ROW BEGIN INSERT INTO InvLogitems(ProdID, ProductName, Brand, Price, Measurement, Color, Category, Stocks, Defectives, LogActivity) VALUES(new.ID, new.ProductName, new.Brand, new.Price, new.Measurement, new.Color, new.Category, new.Stocks, new.Defectives, '" + add + "');END";
                    string updatetrigger_prod = "CREATE TRIGGER IF NOT EXISTS updatetrigger_prod AFTER UPDATE ON Products FOR EACH ROW BEGIN INSERT INTO InvLogitems(ProdID, ProductName, Brand, Price, Measurement, Color, Category, Stocks, Defectives, LogActivity) VALUES(new.ID, new.ProductName, new.Brand, new.Price, new.Measurement, new.Color, new.Category, new.Stocks, new.Defectives, '" + update + "'); END";

                    SQLiteCommand cmd = new SQLiteCommand(top3view, connection);
                    SQLiteCommand cmd2 = new SQLiteCommand(monthlysalesview, connection);
                    SQLiteCommand cmd3 = new SQLiteCommand(inserttrigger_prod, connection);
                    SQLiteCommand cmd4 = new SQLiteCommand(updatetrigger_prod, connection);
                    string returnvalue = (string)cmd.ExecuteScalar();
                    string returnvalue2 = (string)cmd2.ExecuteScalar();
                    string returnvalue3 = (string)cmd3.ExecuteScalar();
                    string returnvalue4 = (string)cmd4.ExecuteScalar();
                    connection.Close();
                }
                catch (Exception ex)
                {

                  
                }

                if (!db.TopSalesDates.Any())
                {
                    context.TopSalesDates.Add(new MonthlySales{ Month = "January", ID = "01", Amount = 0 });
                    context.TopSalesDates.Add(new MonthlySales{ Month = "February", ID = "02", Amount = 0 });
                    context.TopSalesDates.Add(new MonthlySales{ Month = "March", ID = "03", Amount = 0 });
                    context.TopSalesDates.Add(new MonthlySales{ Month = "April", ID = "04", Amount = 0 });
                    context.TopSalesDates.Add(new MonthlySales{ Month = "May", ID = "05", Amount = 0 });
                    context.TopSalesDates.Add(new MonthlySales{ Month = "June", ID = "06", Amount = 0 });
                    context.TopSalesDates.Add(new MonthlySales{ Month = "July", ID = "07", Amount = 0 });
                    context.TopSalesDates.Add(new MonthlySales{ Month = "August", ID = "08", Amount = 0 });
                    context.TopSalesDates.Add(new MonthlySales{ Month = "September", ID = "09", Amount = 0 });
                    context.TopSalesDates.Add(new MonthlySales{ Month = "October", ID = "10", Amount = 0 });
                    context.TopSalesDates.Add(new MonthlySales{ Month = "November", ID = "11", Amount = 0 });
                    context.TopSalesDates.Add(new MonthlySales{ Month = "December", ID = "12", Amount = 0 });
                    MessageBox.Show("Hello");
                    context.SaveChanges();
                }

                try
                {
                    var topitems = context.Topchosen.FromSqlRaw("SELECT * FROM top3view");
                    HighestSale.ItemsSource = topitems.ToList();
                    SalesTable.ItemsSource = context.SalesDis.FromSqlRaw("SELECT * FROM monthlysalesview").ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }          
               
            }
            
            
            //SalesTable.ItemsSource = db.Orders.FromSqlRaw("Select * from Orders").ToList();
        }
        //public class Products : INotifyPropertyChanged
        //{           
        //    private string name;
        //    public string ProductName
        //    {
        //        get { return name; }
        //        set
        //        {
        //            name = value;
        //            RaiseProperChanged();
        //        }
        //    }

        //    private int sold;
        //    public int TotalSold
        //    {
        //        get { return sold; }
        //        set
        //        {
        //            sold = value;
        //            RaiseProperChanged();
        //        }
        //    }

        //    private int quantity;
        //    public int TotalQuantity
        //    {
        //        get { return quantity; }
        //        set
        //        {
        //            quantity = value;
        //            RaiseProperChanged();
        //        }
        //    }
        //    public static ObservableCollection<Products> GetHighestSales()
        //    {
        //        var item = new ObservableCollection<Products>();
        //        item.Add(new Products()
        //        {
        //            ProductName = "001",
        //            TotalSold = 10,
        //            TotalQuantity = 1,

        //        });
        //        item.Add(new Products()
        //        {
        //            ProductName = "001",
        //            TotalSold = 10,
        //            TotalQuantity = 1,

        //        });
        //        return item;
        //    }

        //    private string month;
        //    public string Month
        //    {
        //        get { return month; }
        //        set
        //        {
        //            month = value;
        //            RaiseProperChanged();
        //        }
        //    }

        //    private int sales;
        //    public int Sales
        //    {
        //        get { return sales; }
        //        set
        //        {
        //            sales = value;
        //            RaiseProperChanged();
        //        }
        //    }

        //    private int dif;
        //    public int Difference
        //    {
        //        get { return dif; }
        //        set
        //        {
        //            dif = value;
        //            RaiseProperChanged();
        //        }
        //    }

        //    public static ObservableCollection<Products> GetYearlySales()
        //    {
        //        var item = new ObservableCollection<Products>();
        //        item.Add(new Products()
        //        {
        //            Month = "January",
        //            Sales = 10,
        //            Difference = 1,

        //        });
        //        item.Add(new Products()
        //        {
        //            Month = "February",
        //            Sales = 10,
        //            Difference = 1,

        //        });
        //        item.Add(new Products()
        //        {
        //            Month = "March",
        //            Sales = 10,
        //            Difference = 1,

        //        });
        //        item.Add(new Products()
        //        {
        //            Month = "April",
        //            Sales = 10,
        //            Difference = 1,

        //        });
        //        item.Add(new Products()
        //        {
        //            Month = "May",
        //            Sales = 10,
        //            Difference = 1,

        //        });
        //        return item;
        //    }

        //    public event PropertyChangedEventHandler PropertyChanged;
        //    private void RaiseProperChanged([CallerMemberName] string caller = "")
        //    {

        //        if (PropertyChanged != null)
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        //        }
        //    }

        //}
    }
}
