using System.ComponentModel.DataAnnotations.Schema;
using Infosis_Banco;

namespace Infosis_Banco
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public long Telefone { get; set; }
        public string CPF { get; set; }
        [ForeignKey("ModalidadeCargo")]
        public int ModalidadeCargoId { get; set; }
        public virtual ModalidadeCargo ModalidadeCargo{ get; set; }
        public IEnumerable<DepositoBeneficio> DepositoBeneficios { get; set; }
        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

    }
}
