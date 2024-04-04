using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        CustomersTableAdapter customers = new CustomersTableAdapter();
        public Window1()
        {
            InitializeComponent();
            TableWindow.ItemsSource = customers.GetData();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void InsertCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            customers.InsertQuery(CustomerTextBox1.Text, CustomerTextBox2.Text, CustomerTextBox3.Text);
            TableWindow.ItemsSource = customers.GetData();
        }

        private void UpdateCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (TableWindow.SelectedItem as DataRowView).Row[0];
            customers.UpdateQuery(CustomerTextBox1.Text, CustomerTextBox2.Text, CustomerTextBox3.Text, Convert.ToInt32(id));
            TableWindow.ItemsSource = customers.GetData();
        }

        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (TableWindow.SelectedItem as DataRowView).Row[0];
            customers.DeleteQuery(Convert.ToInt32(id));
            TableWindow.ItemsSource = customers.GetData();
        }
    }
}
