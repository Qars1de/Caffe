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

namespace Caffe
{
    /// <summary>
    /// Логика взаимодействия для log.xaml
    /// </summary>
    public partial class log : Window
    {
        public log()
        {
            InitializeComponent();

            
        }

        string cap;

        private void Capcha()
        {
            String allowchar = " ";

            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";

            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";

            allowchar += "1,2,3,4,5,6,7,8,9,0";

            char[] a = { ',' };

            String[] ar = allowchar.Split(a);

            String pwd = "";

            string temp = "";

            Random r = new Random();



            for (int i = 0; i < 4; i++)

            {

                temp = ar[(r.Next(0, ar.Length))];



                pwd += temp;

            }


            capchaLabel.Content = pwd;
            cap = pwd;
        }
        int Error = 0;
        private void logButton_Click(object sender, RoutedEventArgs e)
        {

                    if (capchaBox.Text == cap)
                    {

                        if (loginBox.Text == "" || passBox.Text == "")
                        {
                            MessageBox.Show("Заполните поля");
                            Error += 1;
                        }
                        else
                        {

                            string UserLogin = "";
                            string Password = "";
                            string Role = "";

                            DB db = new DB();

                            DataTable table = new DataTable();

                            SqlDataAdapter adapter = new SqlDataAdapter();


                            SqlCommand command = new SqlCommand("SELECT * FROM [6User] where Login = @login and Password = @pass", db.getConnection());
                            command.Parameters.Add("@login", SqlDbType.VarChar).Value = loginBox.Text;
                            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = passBox.Text;


                            db.openConnection();
                            SqlDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                UserLogin = reader["Login"].ToString();
                                Password = reader["Password"].ToString();
                                Role = reader["Role"].ToString();
                            }
                            db.closeConnection();
                            adapter.SelectCommand = command;
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                if (Role == "1")
                                {
                                    this.Hide();
                                    Admin.Admin form = new Admin.Admin();
                                    form.Show();
                                }
                                else if (Role == "2")
                                {
                                    this.Hide();
                                    Povar.Povar form = new Povar.Povar();
                                    form.Show();
                                }
                                else
                                {
                                    this.Hide();
                                    Officiant.Officiant form = new Officiant.Officiant();
                                    form.Show();
                                }
                            }
                            else if (loginBox.Text == "" || passBox.Text == "")
                            {
                                MessageBox.Show("Заполнитеп поля");
                                Error += 1;
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль");
                                Error += 1;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверно введена капча");
                        Capcha();
                        Error += 1;
                    }
            if (Error == 3)
            {
                System.Threading.Thread.Sleep(5000);
                Error = 0;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Capcha();
        }
    }
}
