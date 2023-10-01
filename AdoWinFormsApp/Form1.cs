using System.Data;
using Microsoft.Data.SqlClient;

namespace AdoWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=work_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection is open\n");

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM products";

                SqlDataAdapter adapter = new(command);
                // SqlDataAdapter adapter = new("SELECT * FROM products", connection);
                DataSet dataSet = new();

                adapter.Fill(dataSet);

                dataGridView1.DataSource = dataSet.Tables[0];
            }
        }
    }
}