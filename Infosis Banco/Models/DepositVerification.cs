namespace Infosis_Banco
{
    public class DepositVerification
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public  DateTime Matureness { get; set; } //alterar o int para data
        public Benefit Benefit { get; set; }
        public int BenefitId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

    }
}
