using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiLibrosFinal.Models
{
    public partial class Librosv2Context : DbContext
    {
        public Librosv2Context()
        {
        }

        public Librosv2Context(DbContextOptions<Librosv2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<LibroAutor> LibroAutors { get; set; } = null!;
        public virtual DbSet<LibroPrestamo> LibroPrestamos { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
        public virtual DbSet<TarjetaRfid> TarjetaRfids { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__Autor__9AE8206A8F4FE8D6");

                entity.ToTable("Autor");

                entity.Property(e => e.IdAutor).HasColumnName("idAutor");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .HasColumnName("pais");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK__Libro__5BC0F026C4634007");

                entity.ToTable("Libro");

                entity.Property(e => e.IdLibro).HasColumnName("idLibro");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .HasColumnName("categoria");

                entity.Property(e => e.FechaPublicacion).HasColumnType("date");

                entity.Property(e => e.FkIdAutor).HasColumnName("fk_idAutor");

                entity.Property(e => e.Titulo).HasMaxLength(100);

                entity.HasOne(d => d.FkIdAutorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkIdAutor)
                    .HasConstraintName("FK__Libro__fk_idAuto__4CA06362");
            });

            modelBuilder.Entity<LibroAutor>(entity =>
            {
                entity.ToTable("Libro_Autor");

                entity.Property(e => e.LibroAutorId).HasColumnName("LibroAutorID");

                entity.Property(e => e.FkIdAutor).HasColumnName("fk_idAutor");

                entity.Property(e => e.FkIdLibro).HasColumnName("fk_idLibro");

                entity.HasOne(d => d.FkIdAutorNavigation)
                    .WithMany(/*p => p.LibroAutors*/)
                    .HasForeignKey(d => d.FkIdAutor)
                    .HasConstraintName("FK__Libro_Aut__fk_id__5165187F");

                entity.HasOne(d => d.FkIdLibroNavigation)
                    .WithMany(p => p.LibroAutors)
                    .HasForeignKey(d => d.FkIdLibro)
                    .HasConstraintName("FK__Libro_Aut__fk_id__5070F446");
            });

            modelBuilder.Entity<LibroPrestamo>(entity =>
            {
                entity.HasKey(e => e.DetallePrestamoId)
                    .HasName("PK__Libro_Pr__70FCB0B43220C871");

                entity.ToTable("Libro_Prestamo");

                entity.Property(e => e.DetallePrestamoId).HasColumnName("detallePrestamoID");

                entity.Property(e => e.EstadoLibro).HasMaxLength(50);

                entity.Property(e => e.FechaApartado)
                    .HasColumnType("date")
                    .HasColumnName("fechaApartado");

                entity.Property(e => e.FkIdLibro).HasColumnName("fk_idLibro");

                entity.Property(e => e.FkIdPrestamo).HasColumnName("fk_idPrestamo");

                entity.HasOne(d => d.FkIdLibroNavigation)
                    .WithMany(p => p.LibroPrestamos)
                    .HasForeignKey(d => d.FkIdLibro)
                    .HasConstraintName("FK__Libro_Pre__fk_id__5535A963");

                entity.HasOne(d => d.FkIdPrestamoNavigation)
                    .WithMany(p => p.LibroPrestamos)
                    .HasForeignKey(d => d.FkIdPrestamo)
                    .HasConstraintName("FK__Libro_Pre__fk_id__5441852A");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.IdPrestamo)
                    .HasName("PK__Prestamo__A4876C13E30CDA14");

                entity.ToTable("Prestamo");

                entity.Property(e => e.IdPrestamo).HasColumnName("idPrestamo");

                entity.Property(e => e.EstadoLibro)
                    .HasMaxLength(50)
                    .HasColumnName("estadoLibro");

                entity.Property(e => e.FechaApartado)
                    .HasColumnType("date")
                    .HasColumnName("fechaApartado");

                entity.Property(e => e.FechaDevolucion)
                    .HasColumnType("date")
                    .HasColumnName("fechaDevolucion");

                entity.Property(e => e.FkIdUsuario).HasColumnName("fk_idUsuario");

                entity.HasOne(d => d.FkIdUsuarioNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.FkIdUsuario)
                    .HasConstraintName("FK__Prestamo__fk_idU__3C69FB99");
            });

            modelBuilder.Entity<TarjetaRfid>(entity =>
            {
                entity.HasKey(e => e.IdTarjeta)
                    .HasName("PK__TarjetaR__C456D538518B453F");

                entity.ToTable("TarjetaRFID");

                entity.Property(e => e.IdTarjeta).HasColumnName("idTarjeta");

                entity.Property(e => e.FkIdUsuario).HasColumnName("FK_idUsuario");

                entity.HasOne(d => d.FkIdUsuarioNavigation)
                    .WithMany(p => p.TarjetaRfids)
                    .HasForeignKey(d => d.FkIdUsuario)
                    .HasConstraintName("FK__TarjetaRF__FK_id__398D8EEE");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A621C40D54");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellidos).HasMaxLength(100);

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
