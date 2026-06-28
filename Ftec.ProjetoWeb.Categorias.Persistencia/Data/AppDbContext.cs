using Ftec.ProjetoWeb.Categorias.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Ftec.ProjetoWeb.Categorias.Persistencia.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Isso aqui diz ao EF Core: "Crie uma tabela chamada 'categoria' baseada na minha classe"
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento usando Fluent API (o jeito profissional de mapear)
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categoria");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nome).HasColumnName("nome");
                entity.Property(e => e.Descricao).HasColumnName("descricao");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                // Relacionamento (Uma categoria pode ter várias subcategorias)
                entity.HasOne(e => e.Parent)
                      .WithMany()
                      .HasForeignKey(e => e.ParentId);
            });
        }
    }
}