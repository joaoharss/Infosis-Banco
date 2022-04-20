namespace Infosis_Banco
{
    public class DepositoBeneficio
    {
        public int Id { get; set; }
        public decimal ValorDepositoBeneficio { get; set; }
        public  DateTime Vencimento { get; set; } //alterar o int para data
        public Beneficio Beneficio { get; set; }
        public int BeneficioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }

    }
}
