using System;
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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        PurchasesTableAdapter purchases = new PurchasesTableAdapter();
        public Window3()
        {
            InitializeComponent();
            TableWindow.ItemsSource = purchases.GetData();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void InsertPurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            purchases.InsertQuery(PurchaseTextBox1.Text, Convert.ToInt32(PurchaseTextBox2.Text), Convert.ToInt32(PurchaseTextBox3.Text), Convert.ToInt32(PurchaseTextBox4.Text));
            TableWindow.ItemsSource = purchases.GetData();
        }

        private void UpdatePurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (TableWindow.SelectedItem as DataRowView).Row[0];
            purchases.UpdateQuery(PurchaseTextBox1.Text, Convert.ToInt32(PurchaseTextBox2.Text), Convert.ToInt32(PurchaseTextBox3.Text), Convert.ToInt32(PurchaseTextBox4.Text), Convert.ToInt32(id));
            TableWindow.ItemsSource = purchases.GetData();
        }

        private void DeletePurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (TableWindow.SelectedItem as DataRowView).Row[0];
            purchases.DeleteQuery(Convert.ToInt32(id));
            TableWindow.ItemsSource = purchases.GetData();
        }
    }
}
