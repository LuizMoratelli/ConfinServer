using ConFinServer.Controllers;
using ConFinServer.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConFinServer.Repositories
{
    public class CityDB
    {
        public static List<City> GetCities()
        {
            List<City> cities = new List<City>();

            try
            {
                string sql = "SELECT * from cidade";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection.GetConnection());
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = (int) dr["cid_codigo"];
                    string nome = (string) dr["nome"];
                    string est_sigla = (string) dr["est_sigla"];

                    cities.Add(new City(id, nome, est_sigla));
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return cities;
        }

        public static City GetCity(int cid_codigo)
        {
            City city = null;

            try
            {
                string sql = "SELECT * FROM cidade WHERE cid_codigo = @cid_codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection.GetConnection());
                cmd.Parameters.Add("@cid_codigo", NpgsqlTypes.NpgsqlDbType.Integer).Value = cid_codigo;
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = (int) dr["cid_codigo"];
                    string nome = (string) dr["nome"];
                    string est_sigla = (string) dr["est_sigla"];

                    city = new City(id, nome, est_sigla);
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return city;
        }

        public static bool AddCity(City city)
        {
            bool success = false;

            try
            {
                string sql = "INSERT INTO cidade(cid_codigo, nome, est_sigla) VALUES(@cid_codigo, @nome, @est_sigla)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection.GetConnection());
                cmd.Parameters.Add("@cid_codigo", NpgsqlTypes.NpgsqlDbType.Integer).Value = city.cid_codigo;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = city.nome;
                cmd.Parameters.Add("@est_sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = city.est_sigla;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    success = true;
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return success;
        }

        public static bool ChangeCity(City city)
        {
            bool success = false;

            try
            {
                string sql = "UPDATE cidade SET nome = @nome, est_sigla = @nome WHERE cid_codigo = @cid_codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection.GetConnection());
                cmd.Parameters.Add("@cid_codigo", NpgsqlTypes.NpgsqlDbType.Integer).Value = city.cid_codigo;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = city.nome;
                cmd.Parameters.Add("@est_sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = city.est_sigla;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    success = true;
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return success;
        }

        public static bool RemoveCity(City city)
        {
            bool success = false;

            try
            {
                string sql = "DELETE FROM cidade WHERE cid_codigo = @cid_codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection.GetConnection());
                cmd.Parameters.Add("@cid_codigo", NpgsqlTypes.NpgsqlDbType.Integer).Value = city.cid_codigo;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    success = true;
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return success;
        }
    }
}
