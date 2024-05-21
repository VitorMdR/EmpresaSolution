using System.Collections.Generic;

namespace Empresa.Domain.Interface
{
    public interface IFuncionarioRepository
    {
        string AdicionarFuncionario(Funcionario funcionario);
        List<Funcionario> BuscarTodosFuncionarios();
        Funcionario BuscarFuncionarioPorNome(Funcionario funcionario);
    }
}
