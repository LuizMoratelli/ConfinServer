using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConFinServer.Controllers
{
    public class Connection
    {
        public static NpgsqlConnection GetConnection()
        {
            NpgsqlConnection connection = null;

            try
            {
                connection = new NpgsqlConnection(
                    "Server=localhost;Port=5432;User Id=postgres;Password=;Database=financeiro;"
                );

                connection.Open();
            } catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return connection;
        }

        public static void CloseConnection(NpgsqlConnection connection)
        {
            try
            {
                connection?.Close();
            } catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
