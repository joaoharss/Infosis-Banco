using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infosis_Banco.Data.Mappings
{
    public class ModalidadeContratoMapping : IEntityTypeConfiguration<ModalidadeContrato>
    {
        public void Configure(EntityTypeBuilder<ModalidadeContrato> builder)
        {
            builder.Property(d => d.Hora)
                .HasColumnType("INT")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(d => d.Descricao)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
