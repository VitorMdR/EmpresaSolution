
using Empresa.Domain;
using Empresa.Domain.Interface;
using Empresa.Infra.Data;
using System;

namespace Empresa.ConsoleApp
{
    public class AcoesDoSistema
    {
        static IFuncionarioRepository _funcionarioRepository = new FuncionarioRepository();
        static ISalaRepository _salaRepository = new SalaRepository();
        public void CadastrarFuncionario()
        {
            Funcionario funcionario = new Funcionario();

            Console.WriteLine("Informe o nome do funcionario:");
            funcionario.Nome = Console.ReadLine();

            Console.WriteLine("Informe o cargo do funcionário:");
            funcionario.Cargo = Console.ReadLine();

            Console.WriteLine("Informe o ramal do funcionário:");
            funcionario.Ramal = Console.ReadLine();

            var funcionarioCadastrado = _funcionarioRepository.AdicionarFuncionario(funcionario);

            Console.WriteLine(funcionarioCadastrado);
            Console.ReadKey();
        }

        public void ListarFuncionarios()
        {
            var listaDeFuncionarios = _funcionarioRepository.BuscarTodosFuncionarios();
            foreach (var funcionario in listaDeFuncionarios)
            {
                Console.WriteLine(funcionario.ToString());
            }
            Console.ReadKey();
        }
        public void CadastrarReserva()
        {

            Console.WriteLine("Informe o identificador do funcionário:");
            var idFuncionario = int.Parse(Console.ReadLine());
            var buscaFuncionario = _funcionarioRepository.BuscaFuncionarioPorId(idFuncionario);
            if (buscaFuncionario == null)
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
            else
            {
                Console.WriteLine("informe a sala que será reservada:");
                var idSala = int.Parse(Console.ReadLine());
                var salaBuscada = _salaRepository.BuscarSalaPorId(idSala);
                if (salaBuscada == null)
                {
                    Console.WriteLine("Sala não encontrada.");
                }
                else
                {
                    Console.WriteLine("Informe a data incial da reseva:");
                    var dtInicial = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Informe a data final da reserva:");
                    var dtFinal = DateTime.Parse(Console.ReadLine());

                    salaBuscada.RealizarReserva(dtInicial, dtFinal, buscaFuncionario);
                }
            }
        }
    }
}
