using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infosis_Banco.Data.Mappings
{
    public class ModalidadeCargoMapping : IEntityTypeConfiguration<ModalidadeCargo>
    {
        public void Configure(EntityTypeBuilder<ModalidadeCargo> builder)
        {
            builder.HasOne(d => d.Cargo)
            .WithMany(p => p.ModalidadeCargos)
            .HasForeignKey(a => a.CargoId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.ModalidadeContrato)
            .WithMany(p => p.ModalidadeCargos)
            .HasForeignKey(a => a.ModalidadeContratoId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Nivel)
            .WithMany(p => p.ModalidadeCargos)
            .HasForeignKey(a => a.NivelId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
