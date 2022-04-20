namespace Infosis_Banco
{
    public class Beneficio
    {
        public int Id { get; set; }
        public TipoBeneficio TipoBeneficio { get; set; }
        public int TipoBeneficioId { get; set; }
        public Nivel Nivel { get; set; }
        public int NivelId { get; set; }

    }
}
