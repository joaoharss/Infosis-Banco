using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infosis_Banco.Data.Mappings
{
    public class TipoBeneficioMapping : IEntityTypeConfiguration<TipoBeneficio>
    {
        public void Configure(EntityTypeBuilder<TipoBeneficio> builder)
        {
            builder.Property(d => d.Descricao).HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.ValorTipoBeneficio)
                .HasColumnType("DECIMAL")
                .IsRequired();

            builder.Property(c => c.PorcentagemPadrao)
                .HasColumnType("DECIMAL")
                .IsRequired();
        }
    }
}
