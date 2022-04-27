using System.ComponentModel.DataAnnotations.Schema;

namespace Infosis_Banco
{
    public class DepositoBeneficio
    {
        public int Id { get; set; }
        public decimal ValorDepositoBeneficio { get; set; }
        public  DateTime Vencimento { get; set; }
        [ForeignKey("Beneficio")]
        public int BeneficioId { get; set; }
        public virtual Beneficio Beneficio { get; set; }
        [ForeignKey("Funcionario")]
        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
    }
}