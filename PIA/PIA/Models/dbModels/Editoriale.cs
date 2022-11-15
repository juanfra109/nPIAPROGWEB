using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIA.Models.dbModels
{
    [Table("editoriales")]
    public partial class Editoriale
    {
        public Editoriale()
        {
            Libros = new HashSet<Libro>();
        }

        [Key]
        [Column("ideditorial")]
        public int Ideditorial { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;

        [InverseProperty("EditorialNavigation")]
        public virtual ICollection<Libro> Libros { get; set; }
    }
}
