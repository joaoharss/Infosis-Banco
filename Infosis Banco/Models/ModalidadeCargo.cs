using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infosis_Banco
{
    public class ModalidadeCargo
    {
        public int Id { get; set; }
        [ForeignKey("Nivel")]
        public int NivelId { get; set; }
        public Nivel Nivel { get; set; }
        [ForeignKey("Cargo")]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }
        [ForeignKey("ModalidadeContrato")]
        public int ModalidadeContratoId { get; set; }
        public virtual ModalidadeContrato ModalidadeContrato { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }


    }
}
