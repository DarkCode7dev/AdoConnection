using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using statement in C# defines a boundary for the object outside of which, the object is automatically destroyed.
using System.Data;
using System.Data.SqlClient;

namespace Ado
{
    class Program
    {
        static void Main(string[] args)
        {
            //connection string 
            //use @ if \ is present in connection
            const string connect = @"Data Source=DESKTOP-452QJS5\PROGRAMMER;Initial Catalog=Ado;Integrated Security=True";

            //update Sql Query
            string updateQuery = "Update Employee set Empname=@Name, EmpAddress=@Address where EmpId=@Id";

           // UpdateRecords(connect, updateQuery);


            //Inserting Record
            string insertquery = "Insert into Employee values(@Id,@Name,@Address)";

            // InsertRecords(connect, insertquery);


            //DELETE SQL QUERY
            string deletequery = "delete from Employee where EmpId=@Id";

            DeleteRecords(connect, deletequery);



            //Creating Sql Query
            string selectquery = "Select * from Employee";
            ReadAllRecord(connect, selectquery);


           
        }

        private static void DeleteRecords(string connect, string deletequery)
        {
            int id = MyConsole.GetNumber("Enter the Id:");
            

            SqlConnection dbConnection = new SqlConnection(connect);
            SqlCommand command = new SqlCommand(deletequery, dbConnection);
            command.Parameters.AddWithValue("@id", id);
           

            try
            {
                //open Connection

                dbConnection.Open();

                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                Console.WriteLine("Someting went wrong");
            }
            finally
            {
                dbConnection.Close();
            }

        }

        private static void UpdateRecords(string connect, string updateQuery)
        {
            int id = MyConsole.GetNumber("Enter the Id:");
            string name = MyConsole.GetString("Enter the Name: ");
            string address = MyConsole.GetString("Enter the Address:");

            SqlConnection dbConnection = new SqlConnection(connect);
            SqlCommand command = new SqlCommand(updateQuery, dbConnection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Address", address);

            try
            {
                //open Connection

                dbConnection.Open();

                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                Console.WriteLine("Someting went wrong");
            }
            finally
            {
                dbConnection.Close();
            }

        }

        private static void InsertRecords(string connect, string insertquery)
        {
            int id = MyConsole.GetNumber("Enter the Id:");
            string name = MyConsole.GetString("Enter the Name: ");
            string address = MyConsole.GetString("Enter the Address:");

            SqlConnection dbConnection = new SqlConnection(connect);
            SqlCommand command = new SqlCommand(insertquery,dbConnection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Address", address);

            try
            {
                //open Connection

                dbConnection.Open();

                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                Console.WriteLine("Someting went wrong");
            }
            finally
            {
                dbConnection.Close();
            }





        }

        private static void ReadAllRecord(string connect, string selectquery)
        {
            //Creating connection between SQL and VS
            IDbConnection dbConnection = new SqlConnection(connect);
            IDbCommand command = new SqlCommand(selectquery, (SqlConnection)dbConnection);
            dbConnection.Open();
            // ExecuteReader used for getting the query results as a DataReader object. It is readonly forward only retrieval of records and it uses select command to read through the table from the first to the last.
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                    Console.WriteLine(reader["EmpName"] + "lives in " + reader["EmpAddress"]);
            }
            catch (SqlException)
            {

                Console.WriteLine("Sorry Something went wrong.....");
            }

            finally
            {
                dbConnection.Close();
            }
        }
    }
}
