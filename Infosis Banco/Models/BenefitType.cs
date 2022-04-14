namespace Infosis_Banco
{
    public class BenefitType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public decimal PercentDefault { get; set; }

        internal object FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
