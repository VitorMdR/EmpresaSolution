using Empresa.Domain;
using Empresa.Domain.Interface;
using Empresa.Infra.Data.DAO;
using System.Collections.Generic;

namespace Empresa.Infra.Data
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private FuncionarioDAO _funcionarioDao = new FuncionarioDAO();  
        public string AdicionarFuncionario(Funcionario funcionario)
        {
            var verificaFuncionarioExiste = BuscarFuncionarioPorNome(funcionario);
            if(verificaFuncionarioExiste == null)
            {
                _funcionarioDao.AdicionarFuncionario(funcionario);
                var funcionarioCadastrado = BuscarFuncionarioPorNome(funcionario);  
                return $"O funcionário {funcionarioCadastrado.Nome} foi cadastrado com o ID: {funcionarioCadastrado.Id}";
            }
            else
            {
                return "Funcionário já cadastrado";
            }
        }

        public Funcionario BuscaFuncionarioPorId(int id)
        {
           var funcionarioBuscado =  _funcionarioDao.BuscarFuncionarioPorId(id);
            return funcionarioBuscado == null ? null : funcionarioBuscado;
        }

        public Funcionario BuscarFuncionarioPorNome(Funcionario funcionario)
        {
           var funcionarioEncontrado = _funcionarioDao.BuscarFuncionarioPorNome(funcionario);
            return funcionarioEncontrado;   
        }

        public List<Funcionario> BuscarTodosFuncionarios()
        {
            var listaFuncionarios = _funcionarioDao.ListarFuncionarios();
            return listaFuncionarios;
        }
    }
}
