using AluguelToten.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TotenAluguel.Models;

namespace TotenAluguel.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CarroModel> Carros { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TotenModel> Totens { get; set; }
        public DbSet<CompraModel> Compras { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<AluguelModel> Aluguel { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }
        public DbSet<UsuarioCarro> UsuarioCarros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar a relação muitos-para-muitos entre Usuario e Carro
            modelBuilder.Entity<UsuarioCarro>()
                .HasKey(uc => new { uc.UsuarioId, uc.CarroId });

            modelBuilder.Entity<UsuarioCarro>()
                .HasOne(uc => uc.Usuario)
                .WithMany(u => u.UsuarioCarros)
                .HasForeignKey(uc => uc.UsuarioId);

            modelBuilder.Entity<UsuarioCarro>()
                .HasOne(uc => uc.Carro)
                .WithMany(c => c.UsuarioCarros)
                .HasForeignKey(uc => uc.CarroId);

            modelBuilder.Entity<UsuarioModel>()
                .HasMany(u => u.UsuarioCarros)
                .WithOne(uc => uc.Usuario)
                .HasForeignKey(uc => uc.UsuarioId);

            modelBuilder.Entity<CarroModel>()
                .HasMany(c => c.UsuarioCarros)
                .WithOne(uc => uc.Carro)
                .HasForeignKey(uc => uc.CarroId);

            // Configurar relacionamento entre Aluguel, Carro, Usuario, FormaPagamento e Toten
            modelBuilder.Entity<AluguelModel>()
                .HasOne(a => a.Carro)
                .WithMany()
                .HasForeignKey(a => a.CarroId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AluguelModel>()
                .HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AluguelModel>()
                .HasOne(a => a.FormaPagamento)
                .WithMany()
                .HasForeignKey(a => a.FormaPagamentoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AluguelModel>()
                .HasOne(a => a.Toten)
                .WithMany()
                .HasForeignKey(a => a.TotenId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }

}