using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("ModalidadeCargo")]
        public int ModalidadeCargoId { get; set; }
        public ModalidadeCargo ModalidadeCargo{ get; set; }
        public IEnumerable<DepositoBeneficio> DepositoBeneficios { get; set; }

    }
}
