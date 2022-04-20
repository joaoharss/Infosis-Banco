namespace Infosis_Banco
{
    public class Nivel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public IEnumerable<Beneficio> Beneficios { get; set; }
        public IEnumerable<ModalidadeCargo> ModalidadeCargos { get; set; } 
    }
}
