namespace Empresa.Domain
{
    public class Funcionario
    {
        public int Id { get; set; }

        public string Nome{ get; set; }

        public string Cargo { get; set; }

        public string Ramal { get; set; }

        public Funcionario()
        {

        }
        public override string ToString()
        {
            return $"ID: {Id}\nNome: {Nome}\nCargo: {Cargo}\nRamal: {Ramal}\n---------------------- ";
        }
    }
}
