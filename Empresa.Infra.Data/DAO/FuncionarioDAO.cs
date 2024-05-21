using Empresa.Domain;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Empresa.Infra.Data.DAO
{
    public class FuncionarioDAO
    {
        private readonly string _connectionString =
         @"data source=.\SQLEXPRESS;initial catalog=EmpresaDB;uid=sa;pwd=bocaum24;";
        public void AdicionarFuncionario(Funcionario funcionario)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT FUNCIONARIO 
                                    VALUES (@NOME, @CARGO, @RAMAL)";

                    comando.Parameters.AddWithValue("@NOME", funcionario.Nome);
                    comando.Parameters.AddWithValue("@CARGO", funcionario.Cargo);
                    comando.Parameters.AddWithValue("@RAMAL", funcionario.Ramal);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Funcionario> ListarFuncionarios()
        {
            var listaFuncionarios = new List<Funcionario>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM FUNCIONARIO";

                    comando.CommandText = sql;

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var funcionarioBuscado = new Funcionario
                        {
                            Id = int.Parse(leitor["ID"].ToString()),
                            Nome = leitor["NOME"].ToString(),
                            Cargo = leitor["CARGO"].ToString(),
                            Ramal = leitor["RAMAL"].ToString(),
                        };

                        listaFuncionarios.Add(funcionarioBuscado);
                    }
                }
            }

            return listaFuncionarios;
        }

        public Funcionario BuscarFuncionarioPorNome(Funcionario funcionario)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM FUNCIONARIO WHERE NOME = @NOME";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@NOME", funcionario.Nome);

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var funcionarioBuscado = new Funcionario
                        {
                            Id = int.Parse(leitor["ID"].ToString()),
                            Nome = leitor["NOME"].ToString(),
                            Cargo = leitor["CARGO"].ToString(),
                            Ramal = leitor["RAMAL"].ToString(),
                        };

                        return funcionarioBuscado;
                    }
                }
            }
            return null;
        }
        public Funcionario BuscarFuncionarioPorId(int id)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM FUNCIONARIO WHERE ID = @ID";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@ID", id);

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var funcionarioBuscado = new Funcionario
                        {
                            Id = int.Parse(leitor["ID"].ToString()),
                            Nome = leitor["NOME"].ToString(),
                            Cargo = leitor["CARGO"].ToString(),
                            Ramal = leitor["RAMAL"].ToString(),
                        };

                        return funcionarioBuscado;
                    }
                }
            }
            return null;
        }

    }
}
