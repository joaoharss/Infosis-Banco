using Infosis_Banco;
using Infosis_Banco.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Infosis_Banco
{
    public class AppContext : DbContext
    {
        public DbSet<Beneficio> Beneficios { get; set; }
        public DbSet<TipoBeneficio> TipoBeneficios { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<DepositoBeneficio> DepositoBeneficios { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<ModalidadeCargo> ModalidadeCargos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Nivel> Niveis { get; set; }
        public DbSet<ModalidadeContrato> ModalidadeContratos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=WIN-LOLP65ONQT1\SQLEXPRESS;Initial Catalog=InfoSis Banco;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BeneficioMapping());
            modelBuilder.ApplyConfiguration(new DepositoBeneficioMapping());
            modelBuilder.ApplyConfiguration(new FuncionarioMapping());
            modelBuilder.ApplyConfiguration(new ModalidadeCargoMapping());
            modelBuilder.ApplyConfiguration(new TipoBeneficioMapping());
            modelBuilder.ApplyConfiguration(new CargoMapping());
            modelBuilder.ApplyConfiguration(new ModalidadeContratoMapping());
            modelBuilder.ApplyConfiguration(new NivelMapping());
            modelBuilder.ApplyConfiguration(new DepositoMapping());
        }
    }
}
