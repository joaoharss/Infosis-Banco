using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infosis_Banco.Data.Mappings
{
    public class BeneficioMapping : IEntityTypeConfiguration<Beneficio>
    {
        public void Configure(EntityTypeBuilder<Beneficio> builder)
        {           
                builder.HasOne(d => d.TipoBeneficio)
                .WithMany(p => p.Beneficios)
                .HasForeignKey(a => a.TipoBeneficioId)
                .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(d => d.Nivel)
                .WithMany(p => p.Beneficios)
                .HasForeignKey(a => a.NivelId)
                .OnDelete(DeleteBehavior.Restrict);   
        }
    }
}
