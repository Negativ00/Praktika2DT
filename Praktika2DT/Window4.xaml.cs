﻿using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using Praktika2DT.Praktika2UPDataSetTableAdapters;

namespace Praktika2DT
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        StoreTableAdapter store = new StoreTableAdapter();
        public Window4()
        {
            InitializeComponent();
            TableWindow.ItemsSource = store.GetData();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(); 
            main.Show();
            Close();
        }

        private void InsertStoreButton_Click(object sender, RoutedEventArgs e)
        {
            store.InsertQuery(StoreTextBox1.Text, StoreTextBox2.Text, Convert.ToInt32(StoreTextBox3.Text));
            TableWindow.ItemsSource = store.GetData();
        }

        private void UpdateStoreButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (TableWindow.SelectedItem as DataRowView).Row[0];
            store.UpdateQuery(StoreTextBox1.Text, StoreTextBox2.Text, Convert.ToInt32(StoreTextBox3.Text), Convert.ToInt32(id));
            TableWindow.ItemsSource = store.GetData();
        }

        private void DeleteStoreButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (TableWindow.SelectedItem as DataRowView).Row[0];
            store.DeleteQuery(Convert.ToInt32(id));
            TableWindow.ItemsSource = store.GetData();
        }
    }
}