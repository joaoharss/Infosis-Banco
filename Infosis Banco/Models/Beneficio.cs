using System.ComponentModel.DataAnnotations.Schema;

namespace Infosis_Banco
{
    public class Beneficio
    {
        public int Id { get; set; }
        [ForeignKey("TipoBeneficio")]
        public int TipoBeneficioId { get; set; }
        public virtual TipoBeneficio TipoBeneficio { get; set; }
        [ForeignKey("Nivel")]
        public int NivelId { get; set; }
        public virtual Nivel Nivel { get; set; }
        public IEnumerable<DepositoBeneficio> DepositoBeneficios { get; set; }
    }
}
