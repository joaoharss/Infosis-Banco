namespace Infosis_Banco
{
    public class ModalityOffice
    {
        public int Id { get; set; }
        public Nivel Nivel { get; set; }
        public int NivelId { get; set; }
        public Office Office { get; set; }
        public int OfficeId { get; set; }
        public ContractModality ContractModality { get; set; }
        public int ContractModalityId { get; set; }


    }
}
