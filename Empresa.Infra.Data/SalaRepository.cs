using Empresa.Domain;
using Empresa.Infra.Data.DAO;
using System.Collections.Generic;

namespace Empresa.Infra.Data
{
    public class SalaRepository : ISalaRepository
    {
        private SalaDAO _salaDao = new SalaDAO();
        public SalaDeReuniao BuscarSalaPorId(int id)
        {
            var salaBuscada = _salaDao.BuscarSalaPorId(id);
            return salaBuscada == null ? null : salaBuscada;
        }
    }
}
