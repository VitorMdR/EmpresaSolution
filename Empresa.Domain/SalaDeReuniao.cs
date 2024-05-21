using System;

namespace Empresa.Domain
{
    public class SalaDeReuniao
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int QuantidadeLugares { get; set; }

        public Reservas Reserva { get; set; }

        public SalaDeReuniao(int id)
        {
            Reserva = new Reservas();
            Id = id;
        }
        public SalaDeReuniao()
        {

        }

        public void RealizarReserva(DateTime dtInicial, DateTime dtFinal, Funcionario funcionario)
        {
            Reserva.DataHoraInicial = dtInicial;
            Reserva.DataHoraFinal = dtFinal;
            Reserva.Funcionario.Nome = funcionario.Nome;
        }


    }
}