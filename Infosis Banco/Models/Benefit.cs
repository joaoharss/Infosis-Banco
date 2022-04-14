namespace Infosis_Banco
{
    public class Benefit
    {
        public int Id { get; set; }
        public BenefitType BenefitType { get; set; }
        public int BenefitTypeId { get; set; }
        public Nivel Nivel { get; set; }
        public int NivelId { get; set; }

    }
}
