using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Caffe.Povar
{
    /// <summary>
    /// Логика взаимодействия для OrderPovar.xaml
    /// </summary>
    public partial class OrderPovar : Window
    {

        private C6Order _currentOrderPovar;

        public OrderPovar(C6Order selectedOrderPovar)
        {
            InitializeComponent();
            
            if (selectedOrderPovar !=null)
            {
                _currentOrderPovar = selectedOrderPovar;
                var orderMenu = App.Context.C6OrderMenu.ToList();
                orderMenu = orderMenu.Where(p => p.OrderID.ToString().ToLower().Contains(selectedOrderPovar.ToString().ToLower())).ToList();
                LViewOrderPovar.ItemsSource = orderMenu;
            }
            DataContext = _currentOrderPovar;
        }


        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }
    }
}
