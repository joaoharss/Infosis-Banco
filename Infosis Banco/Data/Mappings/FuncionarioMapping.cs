using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infosis_Banco.Data.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasOne(d => d.ModalidadeCargo)
            .WithMany(p => p.Funcionarios)
            .HasForeignKey(a => a.ModalidadeCargoId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Endereco)
                .WithMany(p => p.Funcionarios)
                .HasForeignKey(a => a.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.Nome)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Sobrenome)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Telefone)
                .HasColumnType("BIGINT")
                .HasMaxLength(12)
                .IsRequired();

            builder.Property(d => d.CPF)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(13)
                .IsRequired();
        }
    }
}
