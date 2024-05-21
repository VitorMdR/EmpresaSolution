using Empresa.Domain;
using System.Data.SqlClient;

namespace Empresa.Infra.Data.DAO
{
    public class SalaDAO
    {
        private readonly string _connectionString =
         @"data source=.\SQLEXPRESS;initial catalog=EmpresaDB;uid=sa;pwd=bocaum24;";
        public SalaDeReuniao BuscarSalaPorId(int id)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM SALA WHERE ID = @ID";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@ID", id);

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var salaBuscada = new SalaDeReuniao
                        {
                            Id = int.Parse(leitor["ID"].ToString()),
                            Nome = leitor["NOME"].ToString(),
                            QuantidadeLugares = int.Parse(leitor["CARGO"].ToString())
                        };
                        return salaBuscada;
                    }
                }
            }
            return null;
        }
    }
}
