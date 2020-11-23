using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CadastroClienteZerrenner.Models
{
    public partial class CadastroClienteZNContext : DbContext
    {
        public CadastroClienteZNContext()
        {
        }

        public CadastroClienteZNContext(DbContextOptions<CadastroClienteZNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbZnCadastroCliente> TbZnCadastroCliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-KBEOT2G;Database=CadastroClienteZN;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbZnCadastroCliente>(entity =>
            {
                entity.HasKey(e => e.IdCadastroCliente);

                entity.ToTable("TB_ZN_CADASTRO_CLIENTE");

                entity.Property(e => e.IdCadastroCliente).HasColumnName("ID_CADASTRO_CLIENTE");

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("DATA_CRIACAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nome).HasColumnName("NOME");

                entity.Property(e => e.Profissao).HasColumnName("PROFISSAO");

                entity.Property(e => e.Telefone).HasColumnName("TELEFONE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
