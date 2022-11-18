using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaMainSoft_2.Models
{
    public partial class PruebaMainSoftContext : DbContext
    {
        public PruebaMainSoftContext()
        {
        }

        public PruebaMainSoftContext(DbContextOptions<PruebaMainSoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<AutoresHasLibro> AutoresHasLibros { get; set; }
        public virtual DbSet<Editoriale> Editoriales { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=LAPTOP-5BUGCH90\\SQLEXPRESS; database=PruebaMainSoft; User Id=sa;Password=leosql;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AutoresHasLibro>(entity =>
            {
                entity.HasKey(e => e.AutoresId);

                entity.ToTable("Autores_has_Libros");

                entity.Property(e => e.AutoresId).HasColumnName("Autores_Id");

                entity.Property(e => e.LibrosIs8n).HasColumnName("Libros_IS8N");

                entity.HasOne(d => d.Autores)
                    .WithMany()
                    .HasForeignKey(d => d.AutoresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Autores_has_Libros_Autores");

                entity.HasOne(d => d.LibrosIs8nNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.LibrosIs8n)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Autores_has_Libros_Libros");
            });

            modelBuilder.Entity<Editoriale>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sede)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Is8n);

                entity.Property(e => e.Is8n)
                    .ValueGeneratedNever()
                    .HasColumnName("IS8N");

                entity.Property(e => e.EditorialesId).HasColumnName("Editoriales_id");

                entity.Property(e => e.NPaginas)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("N_Paginas");

                entity.Property(e => e.Sinopsis).HasColumnType("text");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Editoriales)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.EditorialesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libros_Editoriales");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
