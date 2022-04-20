using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infosis_Banco
{
    public class ModalidadeCargo
    {
        public int Id { get; set; }
        public Nivel Nivel { get; set; }
        public int NivelId { get; set; }
        public Cargo Cargo { get; set; }
        public int CargoId { get; set; }
        public ModalidadeContrato ModalidadeContrato { get; set; }
        public int ModalidadeContratoId { get; set; }


    }
}
