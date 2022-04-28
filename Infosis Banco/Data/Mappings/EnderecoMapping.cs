using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infosis_Banco.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(d => d.Rua)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(d => d.Bairro)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.Cidade)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.Numero)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.Property(d => d.CEP)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(d => d.UF)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(2)
                .IsRequired();
        }
    }
}
