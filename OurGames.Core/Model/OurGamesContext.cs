using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OurGames.Core.Model
{
    public partial class OurGamesContext : DbContext
    {
        public OurGamesContext()
        {
        }

        public OurGamesContext(DbContextOptions<OurGamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<NivelAcesso> NivelAcesso { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoProduto> PedidoProduto { get; set; }
        public virtual DbSet<Plataforma> Plataforma { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("CEP")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Endereco__Usuari__4CA06362");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Media__ProdutoId__3E52440B");
            });

            modelBuilder.Entity<NivelAcesso>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("date");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pedido__UsuarioI__5812160E");
            });

            modelBuilder.Entity<PedidoProduto>(entity =>
            {
                entity.HasKey(e => new { e.PedidoId, e.ProdutoId });

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.PedidoProduto)
                    .HasForeignKey(d => d.PedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PedidoPro__Pedid__44FF419A");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.PedidoProduto)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PedidoPro__Produ__45F365D3");
            });

            modelBuilder.Entity<Plataforma>(entity =>
            {
                entity.Property(e => e.Nome)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Classificacao)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Lancamento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Requisitos)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Plataforma)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.PlataformaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Produto__Platafo__3B75D760");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Avatar)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.NivelAcesso)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.NivelAcessoId)
                    .HasConstraintName("FK__Usuario__NivelAc__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}