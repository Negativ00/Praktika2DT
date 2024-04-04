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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        DirectorsTableAdapter directors = new DirectorsTableAdapter();
        public Window2()
        {
            InitializeComponent();
            TableWindow.ItemsSource = directors.GetData();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void InsertDirectorButton_Click(object sender, RoutedEventArgs e)
        {
            directors.InsertQuery(DirectorTextBox1.Text, DirectorTextBox2.Text, DirectorTextBox3.Text);
            TableWindow.ItemsSource = directors.GetData();
        }

        private void UpdateDirectorButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (TableWindow.SelectedItem as DataRowView).Row[0];
            directors.UpdateQuery(DirectorTextBox1.Text, DirectorTextBox2.Text, DirectorTextBox3.Text, Convert.ToInt32(id));
            TableWindow.ItemsSource = directors.GetData();
        }

        private void DeleteDirectorButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (TableWindow.SelectedItem as DataRowView).Row[0];
            directors.DeleteQuery(Convert.ToInt32(id));
            TableWindow.ItemsSource = directors.GetData();
        }
    }
}
