using System.Collections.Generic;

namespace Empresa.Domain
{
    public interface IReservaRepository
    {
        void CadastrarReserva(Reservas reservas);
        List<Reservas> ListarReservas();
    }
}
