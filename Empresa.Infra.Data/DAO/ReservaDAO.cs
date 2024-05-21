using Empresa.Domain;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Empresa.Infra.Data.DAO

{
    public class ReservaDAO
    {
        private readonly string _connectionString =
         @"data source=.\SQLEXPRESS;initial catalog=EmpresaDB;uid=sa;pwd=bocaum24;";
        private object FuncionarioReserva;

        public void CadastrarReserva(Reservas reserva)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT RESERVA 
                                    VALUES (@SALA_ID, @FUNCIONARIO_ID, @DATA_HORA_INICIAL, @DATA_HORA_FINAL)";

                    comando.Parameters.AddWithValue("@SALA_ID", reserva.SalaDeReuniao.Id);
                    comando.Parameters.AddWithValue("@FUNCIONARIO_ID", reserva.Funcionario.Id);
                    comando.Parameters.AddWithValue("@DATA_HORA_INICIAL", reserva.DataHoraInicial);
                    comando.Parameters.AddWithValue("@DATA_HORA_FINAL", reserva.DataHoraFinal);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Reservas> ListarFuncionarios()
        {
            var listaReservas = new List<Reservas>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT R.ID,
                                    R.SALA_ID,
                                    R.FUNCIONARIO_ID
                                    DATA_HORA_INICIAL,
                                    DATA_HORA_FINAL,
                                    F.NOME,
                                    F.CARGO,
                                    F.RAMAL,
                                    S.NOME,
                                    S.QUANTIDADE_LUGARES FROM RESERVA R
                                    INNER JOIN FUNCIONARIO F ON (F.ID = R.FUNCIONARIO_ID)
                                    INNER JOIN SALA S ON (S.ID = R.SALA_ID)";

                    comando.CommandText = sql;

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var reservaBuscada = new Reservas
                        {
                            Id = int.Parse(leitor["ID"].ToString()),
                            FuncionarioReserva.Id = leitor["FUNCIONARIO_ID"].ToString(),
                            Ramal = leitor["DATA_HORA_INICIAL"].ToString(),
                            Ramal = leitor["DATA_HORA_FINAL"].ToString()
                        };

                        listaReservas.Add(reservaBuscada);
                    }
                }
            }

            return listaReservas;
        }
    }
}
