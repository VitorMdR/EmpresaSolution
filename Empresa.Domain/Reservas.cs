using System;

namespace Empresa.Domain
{
    public class Reservas
    {
        public int Id { get; set; }

        public SalaDeReuniao SalaDeReuniaoReservada { get; set; }

        public DateTime DataHoraInicial { get; set; }

        public DateTime DataHoraFinal { get; set; }

        public Funcionario FuncionarioReserva { get; set; }

        public Reservas()
        {
            
        }
       
    }
    
}
