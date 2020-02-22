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

            //Creating Sql Query
            string selectquery = "Select * from Employee";
            ReadAllRecord(connect, selectquery);

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
        }
    }
}
