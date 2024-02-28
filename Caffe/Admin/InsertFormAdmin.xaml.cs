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

namespace Caffe.Admin
{
    /// <summary>
    /// Логика взаимодействия для InsertFormAdmin.xaml
    /// </summary>
    public partial class InsertFormAdmin : Window
    {

        private C6User _currentUser;
        public InsertFormAdmin(C6User selectedUser)
        {
            InitializeComponent();

            if (selectedUser != null)
            {
                _currentUser = selectedUser;
            }
            DataContext = _currentUser;

            var statusType = App.Context.C6UserStatus.ToList();
            statusType.Insert(0, new C6UserStatus
            {
                Name = "Статус"
            });
            statusCombo.ItemsSource = statusType;
            statusCombo.SelectedIndex = 0;

            var roleType = App.Context.C6Role.ToList();
            roleType.Insert(0, new C6Role
            {
                Nazvanie = "Роль"
            });
            roleCombo.ItemsSource = roleType;
            roleCombo.SelectedIndex = 0;
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
