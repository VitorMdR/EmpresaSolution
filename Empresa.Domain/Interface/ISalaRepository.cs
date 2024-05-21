namespace Empresa.Domain
{
    public interface ISalaRepository
    {
        SalaDeReuniao BuscarSalaPorId(int id);
    }
}
