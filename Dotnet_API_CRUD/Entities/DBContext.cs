using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_CRUD.Entities
{
    public partial class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Produtos> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3333;user=projeto;password=dbR00tP455;database=db_projeto");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.ToTable("tbProdutos");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.descProduto)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.situacao)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.dtFabricacao)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasMaxLength(10);

                entity.Property(e => e.dtValidade)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasMaxLength(10);

                entity.Property(e => e.cdFornecedor).HasColumnType("int(11)");

                entity.Property(e => e.descFornecedor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.cnpjFornecedor)
                    .IsRequired()
                    .HasMaxLength(18);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}