namespace Infosis_Banco
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string? Numero { get; set; }
        public string CEP { get; set; }
        public char UF { get; set; }
        public IEnumerable<Funcionario> Funcionarios{ get; set; }
    }
}
