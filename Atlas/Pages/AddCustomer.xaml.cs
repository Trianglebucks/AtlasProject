﻿using Atlas.Model_Classes;
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

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Page
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Customer gotopage = new Customer();
            this.NavigationService.Navigate(gotopage);
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(customer_name.Text) && !String.IsNullOrEmpty(address.Text) && !String.IsNullOrEmpty(contactnumber.Text))
            {
                Create();
                MessageBox.Show("Customer successfully added!");
                Customer gotopage = new Customer();
                this.NavigationService.Navigate(gotopage);
            }
            else
                MessageBox.Show("Please fill the necessary information.");

            
        }

        public void Create()
        {
            using (DataContext context = new DataContext())
            {
                var name = customer_name.Text;
               
                var custaddress = address.Text;

                var number = contactnumber.Text;


                //if (product != null && cost != null && _color != null && _category != null && _status != null && _stocks != null)
                if (!String.IsNullOrEmpty(custaddress) && !String.IsNullOrEmpty(number) && !String.IsNullOrEmpty(name))
                {
                    context.Customers.Add(new CSCustomer()
                    {
                        CustomerName = name,
                        Address = custaddress,
                        ContactNumber = number
                    });
                    context.SaveChanges();
                }
                

            }
        }
    }
}
