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
            var menu = App.Context.C6Menu.ToList();
            LViewMenu.ItemsSource = menu;
        }

        private void UpdateOrder()
        {
            var current = App.Context.C6Menu.ToList();
            current = current.Where(p => p.Name.ToLower().Contains(searchBox.Text.ToLower())).ToList();


            if (ComboSort.SelectedIndex == 1)
            {
                current = current.OrderByDescending(p => p.Cost).ToList();
            }
            else if (ComboSort.SelectedIndex == 2)
            {
                current = current.OrderBy(p => p.Cost).ToList();
            }
            else
            {
                Update();
            }

            LViewMenu.ItemsSource = current;
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateOrder();
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOrder();
        }
    }
}
