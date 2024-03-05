using System;
using System.Data;
using System.Data.SqlClient;

namespace storeprocCRUD
{
    public class DataAccess
    {
        private string connectionString = "server=TEJASGOWDA05\\SQLEXPRESS;initial catalog=storeproc;integrated security=SSPI";


        public void InsertRecord(int a, string b, int c)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertRecord", connection);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@id", a);
                cmd.Parameters.AddWithValue("@name", b);
                cmd.Parameters.AddWithValue("@age", c);


                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void GetRecords()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetRecords", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Column1: {reader["id"]}, Column2: {reader["name"]}, column3:{reader["age"]}");
                }

            }
        }

        public void UpdateRecord(int a, string b, int c)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateRecord", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", a);
                cmd.Parameters.AddWithValue("@name", b);
                cmd.Parameters.AddWithValue("@age", c);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteRecord(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteRecord", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccess da = new DataAccess();
            bool continueLoop = true;

            while (continueLoop)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Insert record");
                Console.WriteLine("2. Get records");
                Console.WriteLine("3. Update record");
                Console.WriteLine("4. Delete record");
                Console.WriteLine("5. Exit");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("enter id");
                            int id = int.Parse(Console.ReadLine());

                            Console.WriteLine("enter name");
                            string name = Console.ReadLine();

                            Console.WriteLine("enter age");
                            int age = int.Parse(Console.ReadLine());
                            da.InsertRecord(id, name, age);
                            Console.WriteLine("Record inserted successfully.");
                            break;
                        case 2:
                            da.GetRecords();
                            break;
                        case 3:
                            Console.WriteLine("Enter  ID of record to update:");
                            int newid;
                            if (int.TryParse(Console.ReadLine(), out newid))
                            {
                                Console.WriteLine("Enter new name:");
                                string newname = Console.ReadLine();
                                Console.WriteLine("Enter new age:");
                                int newage = int.Parse(Console.ReadLine());
                                da.UpdateRecord(newid, newname, newage);
                                Console.WriteLine("Record updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter ID of record to delete:");
                            int idToDelete;
                            if (int.TryParse(Console.ReadLine(), out idToDelete))
                            {
                                da.DeleteRecord(idToDelete);
                                Console.WriteLine("Record deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                            }
                            break;
                        case 5:
                            continueLoop = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                }
            }
        }
    }
}
