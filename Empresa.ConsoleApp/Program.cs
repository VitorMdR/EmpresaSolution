using System;
namespace Empresa.ConsoleApp
{
    internal class Program
    {
        private static AcoesDoSistema _acoesDoSistema = new AcoesDoSistema();
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                MenuPrincipal();
            }

        }
        public static bool MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("[1] - Cadastrar um funcionário");
            Console.WriteLine("[2] - Relatório de contas");
            Console.WriteLine("[3] - Buscar conta por mês e ano");
            Console.WriteLine("[4] - Sair");
            Console.Write("\r\nSelecione uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    _acoesDoSistema.CadastrarFuncionario();
                    return true;
                case "2":
                    _acoesDoSistema.ListarFuncionarios();
                    return true;
                case "3":
                    _acoesDoSistema.CadastrarReserva();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
    }
}
