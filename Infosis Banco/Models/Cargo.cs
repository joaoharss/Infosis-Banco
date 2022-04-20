namespace Infosis_Banco
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public IEnumerable<ModalidadeCargo> ModalidadeCargos { get; set; }  
    }
}
