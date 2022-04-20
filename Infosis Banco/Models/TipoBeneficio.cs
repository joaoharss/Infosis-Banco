namespace Infosis_Banco
{
    public class TipoBeneficio
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorTipoBeneficio { get; set; }
        public decimal PorcentagemPadrao { get; set; }

        internal object FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
