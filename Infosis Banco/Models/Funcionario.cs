namespace Infosis_Banco
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public long Telefone { get; set; }
        public string Sobrenome { get; set; }
        public long CPF { get; set; }
        public ModalidadeCargo ModalidadeCargo{ get; set; }
        public int ModalidadeCargoId { get; set; }
        public IEnumerable<DepositoBeneficio> DepositoBeneficios { get; set; }

    }
}
