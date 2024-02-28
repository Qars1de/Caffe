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
using System.Data.SqlClient;
using System.Data;

namespace Caffe.Admin
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            Update();
            UpdateUser();

            var roleType = App.Context.C6Role.ToList();
            roleType.Insert(0, new C6Role
            {
                Nazvanie = "Роль"
            });
            ComboSort.ItemsSource = roleType;
            ComboSort.SelectedIndex = 0;
        }

        private void Update()
        {
            var user = App.Context.C6User.ToList();
            userGrid.ItemsSource = user;
        }

        public List<C6Role> roles { get; set; } = App.Context.C6Role.ToList();
        private void UpdateUser()
        {
            var current = App.Context.C6User.ToList();
            current = current.Where(p => p.LastName.ToLower().Contains(searchBox.Text.ToLower())).ToList();

            if (ComboSort.SelectedItem!= null)
            {
                var selected = (ComboSort.SelectedItem as C6Role).RoleID;
                if (ComboSort.SelectedIndex > 0)
                {
                    current = current.Where(p => p.Role == selected).ToList();
                }
            }

            userGrid.ItemsSource = current;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            InsertFormAdmin insert = new InsertFormAdmin((sender as Button).DataContext as C6User);

            if (insert.ShowDialog() == true)
            {
                Update();
            }
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertFormAdmin insert = new InsertFormAdmin(null);
            if ( insert.ShowDialog() == true)
            {
                DB db = new DB();

                SqlCommand command = new SqlCommand("insert into [6User] (LastName, FirstName, Patronymic, Phone, Login, Password, UserStatus, Role) select @lastname, @firstname, @patronym, @phone, @login, @pass, UserStatusID, RoleID from [6UserStatus], [6Role] where [6UserStatus].Name = @stat and [6Role].Nazvanie = @role", db.getConnection());
                command.Parameters.Add("@lastname", SqlDbType.VarChar).Value = insert.lastNameBox.Text;
                command.Parameters.Add("@firstname", SqlDbType.VarChar).Value = insert.firstNameBox.Text;
                command.Parameters.Add("@patronym", SqlDbType.VarChar).Value = insert.patrBox.Text;
                command.Parameters.Add("@phone", SqlDbType.Int).Value = Convert.ToInt32(insert.phoneBox.Text);
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = insert.loginBox.Text;
                command.Parameters.Add("@pass", SqlDbType.VarChar).Value = insert.passBox.Text;
                command.Parameters.Add("@stat", SqlDbType.VarChar).Value = insert.statusCombo.Text;
                command.Parameters.Add("@role", SqlDbType.VarChar).Value = insert.roleCombo.Text;

                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                Update();
                db.closeConnection();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var userDelete = userGrid.SelectedItems.Cast<C6User>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {userDelete.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.Context.C6User.RemoveRange(userDelete);
                    App.Context.SaveChanges();
                    Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUser();
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUser();
        }

        private void signOut_Click(object sender, RoutedEventArgs e)
        {
            log logForm = new log();
            logForm.Show();
            this.Close();
        }
    }
}
