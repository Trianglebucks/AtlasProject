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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Security;
using System.Data.SQLite;
using Atlas.Model_Classes;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;




namespace Atlas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            
        }        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            var Username = txtUsername.Text;
            var Password = txtPassword.Password;
            try
            {
                using (DataContext context = new DataContext())
                {
                    if (!context.AccInfo.Any())
                    {
                       
                        context.AccInfo.Add(new Accounts { AccID = 1, User = "admin", Password = "1234" });
                        context.SaveChanges();
                    }
                    var account = context.AccInfo.Max(p => p.AccID);
                    var accverify = context.AccInfo.FirstOrDefault(p => p.AccID == account);

                    if (accverify.User == Username && accverify.Password == Password)
                    {              
                        DateTime date = DateTime.Now;
                        CultureInfo ci = CultureInfo.InvariantCulture;

                        var orderdate = date.ToString("yyyy-MM-dd HH:mm:ss", ci);

                        context.AccLogitems.Add(new Accountlog()
                        {
                            LogDateandTime = orderdate,
                            LogAccRemarks = "LOGIN"
                        });


                        context.SaveChanges();
                        SecondWindow secondWindow = new SecondWindow();
                        secondWindow.Show();
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Username or password is wrong! Who are you!?");
                    }
                }
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
         
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

      
    }
}
