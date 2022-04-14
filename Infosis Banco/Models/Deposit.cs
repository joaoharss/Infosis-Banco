namespace Infosis_Banco
{
    public class Deposit
    {
        public int Id { get; set; }
        public decimal DepositEmployeeValue { get; set; }
        public DateTime Date { get; set; }
        public DepositVerification DepositVerification { get; set; }
        public int DepositVerificationId { get; set; }
      
    }
}
