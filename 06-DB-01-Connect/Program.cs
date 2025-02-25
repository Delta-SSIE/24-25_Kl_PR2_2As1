using Microsoft.Data.SqlClient;

namespace _06_DB_01_Connect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PR2A;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


            using SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            
            DumpDB(connection);

            //InsertCar(connection, 3, "5L62696", "Škoda", "Octavia", DateTime.Now);

            DumpDB(connection);

        }

        private static void InsertCar(SqlConnection connection, int id, string regPlate, string brand, string model, DateTime purchased)
        {
            string query = "INSERT INTO Cars(Id, RegPlate, Brand, Model, Purchased) VALUES (@Id, @RegPlate, @Brand, @Model, @Purchased)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@RegPlate", regPlate);
            command.Parameters.AddWithValue("@Brand", brand);
            command.Parameters.AddWithValue("@Model", model);
            command.Parameters.AddWithValue("@Purchased", purchased);

            command.ExecuteNonQuery();
        }

        private static void DumpDB(SqlConnection connection)
        {
            string query = "SELECT * FROM Cars ORDER BY Purchased DESC";
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //int id = reader.GetInt32(0);
                int id = (int)reader["Id"];
                //string regPlate = reader.GetString(1);
                string regPlate = (string)reader["RegPlate"];
                string brand = (string)reader["Brand"];
                string model = (string)reader["Model"];
                DateTime purchased = reader.GetDateTime(4);

                Console.WriteLine($"ID: {id}, reg. plate: {regPlate}, Type: {brand} {model}, purchased: {purchased}");
            }

            Console.WriteLine();
        }
    }
}
