﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PIA.Models.dbModels
{
    public partial class LibreriaProyectoContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public LibreriaProyectoContext()
        {
        }

        public LibreriaProyectoContext(DbContextOptions<LibreriaProyectoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; } = null!;
        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Cmetodopag> Cmetodopags { get; set; } = null!;
        public virtual DbSet<Editoriale> Editoriales { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<Orden> Ordens { get; set; } = null!;
        public virtual DbSet<Ordendetalle> Ordendetalles { get; set; } = null!;
        public virtual DbSet<Solicitude> Solicitudes { get; set; } = null!;
        public virtual DbSet<Sugerencia> Sugerencias { get; set; } = null!;
        public virtual DbSet<ApplicationUser> Usuarios { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {     
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdLibro });

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_carrito_libro");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_carrito_usuarios");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasOne(d => d.AutorNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.Autor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_libro_Autores");

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.Categoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_libro_categorias");

                entity.HasOne(d => d.EditorialNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.Editorial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_libro_editoriales");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasOne(d => d.IdmetodopagNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.Idmetodopag)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orden_cmetodopag");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orden_usuarios");
            });

            modelBuilder.Entity<Ordendetalle>(entity =>
            {
                entity.HasKey(e => new { e.Idorden, e.Idlibros })
                    .HasName("PK_ordendetalle_1");

                entity.HasOne(d => d.IdlibrosNavigation)
                    .WithMany(p => p.Ordendetalles)
                    .HasForeignKey(d => d.Idlibros)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ordendetalle_libro");

                entity.HasOne(d => d.IdordenNavigation)
                    .WithMany(p => p.Ordendetalles)
                    .HasForeignKey(d => d.Idorden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ordendetalle_orden");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
