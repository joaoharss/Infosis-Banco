namespace Infosis_Banco
{
    public class TipoBeneficio
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorTipoBeneficio { get; set; }
        public decimal PorcentagemPadrao { get; set; }
        public IEnumerable<Beneficio> Beneficios { get; set; }
    }
}
