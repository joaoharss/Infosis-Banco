using Infosis_Banco;
using Microsoft.EntityFrameworkCore;

namespace Infosis_Banco
{
    public class AppContext : DbContext
    {
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<BenefitType> BenefitTypes{ get; set; }
        //public DbSet<Contract> Contracts { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<DepositVerification> DepositVerifications{ get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ModalityOffice> ModalityOffices{ get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Nivel> Niveis { get; set; }
        public DbSet<ContractModality> ContractModalitys { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=WIN-LOLP65ONQT1\SQLEXPRESS;Initial Catalog=InfoSis Banco;Integrated Security=True");
        }
    }
}
