using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIA.Models.dbModels
{
    [Table("categorias")]
    public partial class Categoria
    {
        public Categoria()
        {
            Libros = new HashSet<Libro>();
        }

        [Key]
        [Column("idCategoria")]
        public int IdCategoria { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Descripción { get; set; } = null!;

        [InverseProperty("CategoriaNavigation")]
        public virtual ICollection<Libro> Libros { get; set; }
    }
}
