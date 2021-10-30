using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ZooPlanet.Models
{
    public partial class animalesContext : DbContext
    {
        public animalesContext()
        {
        }

        public animalesContext(DbContextOptions<animalesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clase> Clases { get; set; }
        public virtual DbSet<Especies> Especies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=animales", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.ToTable("clase");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Nombre).HasMaxLength(45);
            });

            modelBuilder.Entity<Especies>(entity =>
            {
                entity.ToTable("especies");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.IdClase, "fk_especie_clase_idx");

                entity.Property(e => e.Especie)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Habitat).HasMaxLength(45);

                entity.Property(e => e.Observaciones).HasMaxLength(100);

                entity.Property(e => e.Peso).HasColumnType("double(7,2)");

                entity.HasOne(d => d.IdClaseNavigation)
                    .WithMany(p => p.Especies)
                    .HasForeignKey(d => d.IdClase)
                    .HasConstraintName("fk_especie_clase");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
