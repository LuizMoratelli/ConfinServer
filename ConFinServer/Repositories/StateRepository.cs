using ConFinServer.Controllers;
using ConFinServer.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConFinServer.Repositories
{
    public class StateRepository
    {
        public static List<State> All()
        {
            List<State> states = new List<State>();

            try
            {
                string sql = "SELECT * from estado";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection.GetConnection());
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string sigla = (string)dr["est_sigla"];
                    string nome = (string)dr["nome"];

                    states.Add(new State(sigla, nome));
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return states;
        }

        public static State Find(string est_sigla)
        {
            State state = null;

            try
            {
                string sql = "SELECT * FROM estado WHERE est_sigla = @est_sigla";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection.GetConnection());
                cmd.Parameters.Add("@est_sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = est_sigla;
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string sigla = (string)dr["est_sigla"];
                    string nome = (string)dr["nome"];

                    state = new State(sigla, nome);
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return state;
        }

        public static bool Add(State state)
        {
            bool success = false;

            try
            {
                string sql = "INSERT INTO estado(est_sigla, nome) VALUES(@sigla, @nome)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection.GetConnection());
                cmd.Parameters.Add("@sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = state.est_sigla;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = state.nome;

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

        public static bool Update(State state)
        {
            bool success = false;

            try
            {
                string sql = "UPDATE estado SET nome = @nome WHERE est_sigla = @sigla";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection.GetConnection());
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = state.nome;
                cmd.Parameters.Add("@est_sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = state.est_sigla;

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

        public static bool Delete(State state)
        {
            bool success = false;

            try
            {
                string sql = "DELETE FROM estado WHERE est_sigla = @sigla";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connection.GetConnection());
                cmd.Parameters.Add("@sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = state.est_sigla;

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
