﻿using Infosis_Banco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Infosis_Banco
{
    public class AppContext : DbContext
    {
        public DbSet<Beneficio> Beneficios { get; set; }
        public DbSet<TipoBeneficio> TipoBeneficios{ get; set; }
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
            modelBuilder.Entity<Beneficio>(entity =>
            {
                entity.HasOne(d => d.TipoBeneficio)
                .WithMany(p => p.Beneficios)
                .HasForeignKey(a => a.TipoBeneficioId);

                entity.HasOne(d => d.Nivel)
                .WithMany(p => p.Beneficios)
                .HasForeignKey(a => a.NivelId);
            });

            //modelBuilder.Entity<DepositoBeneficio>(entity =>
            //{
            //    entity.HasOne(d => d.Beneficio)
            //    .WithMany(p => p.DepositoBeneficios)
            //    .HasForeignKey(a => a.BeneficioId);


            //    entity.HasOne(d => d.Funcionario)
            //    .WithMany(p => p.DepositoBeneficios)
            //    .HasForeignKey(a => a.FuncionarioId);

                
                
            //});


            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasOne(d => d.ModalidadeCargo)
                .WithMany(p => p.Funcionarios)
                .HasForeignKey(a => a.ModalidadeCargoId);
            });

            modelBuilder.Entity<ModalidadeCargo>(entity =>
            {
                entity.HasOne(d => d.Cargo)
                .WithMany(p => p.ModalidadeCargos)
                .HasForeignKey(a => a.CargoId);

                entity.HasOne(d => d.ModalidadeContrato)
                .WithMany(p => p.ModalidadeCargos)
                .HasForeignKey(a => a.ModalidadeContratoId);

                entity.HasOne(d => d.Nivel)
                .WithMany(p => p.ModalidadeCargos)
                .HasForeignKey(a => a.NivelId);
            });


        }
    }
}
