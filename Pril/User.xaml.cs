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

namespace Pril
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            SqlCommand command = new SqlCommand("Select * From [5Client]", db.getConnection());
            DataTable dt = new DataTable();

            db.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.Fill(dt);
            vivod.ItemsSource = dt.DefaultView;
            db.closeConnection();
        }
    }
}
