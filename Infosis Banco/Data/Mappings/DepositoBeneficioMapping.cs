using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infosis_Banco.Data.Mappings
{
    public class DepositoBeneficioMapping : IEntityTypeConfiguration<DepositoBeneficio>
    {
        public void Configure(EntityTypeBuilder<DepositoBeneficio> builder)
        { 
            builder.HasOne(d => d.Beneficio)
            .WithMany(p => p.DepositoBeneficios)
            .HasForeignKey(a => a.BeneficioId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Funcionario)
            .WithMany(p => p.DepositoBeneficios)
            .HasForeignKey(a => a.FuncionarioId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
