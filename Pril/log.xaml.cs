using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Pril
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (logBox.Text == "" || passBox.Text == "")
            {
                MessageBox.Show("Заполните поля");
            }
            else
            {


                DB db = new DB();

                DataTable table = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter();


                SqlCommand command = new SqlCommand("SELECT * FROM klients WHERE login = @login AND Pass= @pass", db.getConnection());
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = logBox.Text;
                command.Parameters.Add("@pass", SqlDbType.VarChar).Value = passBox.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    this.Hide();
                    User f = new User();
                    f.Show();
                }

                else
                    MessageBox.Show("Неверный номер счёта или пин-код");
            }
        }
    }
}
