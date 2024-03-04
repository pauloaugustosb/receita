using MySqlConnector;
using Dapper;
using System;
using System.Linq;

namespace ProjetoReceita.Infrastructure.Migrations
{
    public static class Database
    {
        public static void CriarDataBase(string conexaoComBancoDeDados, string nomeDataBase)
        {
                using var minhaConexao = new MySqlConnection(conexaoComBancoDeDados);
                

                var parametros = new DynamicParameters();
                parametros.Add("nome", nomeDataBase);

                // Verificar se existe o DataBase, procurando se existe o SCHEMA
                var registros = minhaConexao.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @nome", parametros);

                // Caso não tenha registro de conexão, criar um DataBase
                if (!registros.Any())
                {
                    minhaConexao.Execute($"CREATE DATABASE `{nomeDataBase}`"); // Use backticks para evitar problemas com caracteres especiais
                }

        }
    }
}