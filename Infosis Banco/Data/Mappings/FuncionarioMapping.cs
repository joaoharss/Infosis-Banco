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
        }
    }
}
