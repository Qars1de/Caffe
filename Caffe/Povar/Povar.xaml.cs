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
using System.Windows.Shapes;

namespace Caffe.Povar
{
    /// <summary>
    /// Логика взаимодействия для Povar.xaml
    /// </summary>
    public partial class Povar : Window
    {
        public Povar()
        {
            InitializeComponent();
            Update();
            UpdateOrder();
        }

        private void Update()
        {
            var menu = App.Context.C6Order.ToList();
            LViewMenu.ItemsSource = menu;
        }

        private void UpdateOrder()
        {

        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateOrder();
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOrder();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OrderPovar order = new OrderPovar((sender as ListViewItem).DataContext as C6Order);
            if (order.ShowDialog() == true)
            {
                Update();
            }
        }

       
    }
}
