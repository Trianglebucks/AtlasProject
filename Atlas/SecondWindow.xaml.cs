﻿using Atlas.Model_Classes;
using Atlas.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            Main.Content = new Home();
        }        

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }


        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Inventory();
        }

        private void btnDelivery_click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Delivery();
        }

        private void btnHome_click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Home();
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Log();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Settings();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var db = new DataContext();

            DateTime date = DateTime.Now;
            CultureInfo ci = CultureInfo.InvariantCulture;

            var orderdate = date.ToString("yyyy-MM-dd HH:mm:ss", ci);

            db.AccLogitems.Add(new Accountlog()
            {
                LogDateandTime = orderdate,
                LogAccRemarks = "LOGOUT"
            });

            db.SaveChanges();
            MainWindow loginWin = new MainWindow();
            loginWin.Show();
            this.Close();
        }
    }
}
