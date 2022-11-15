using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIA.Models.dbModels
{
    [Table("libro")]
    public partial class Libro
    {
        public Libro()
        {
            Carritos = new HashSet<Carrito>();
            Ordendetalles = new HashSet<Ordendetalle>();
        }

        [Key]
        [Column("idLibro")]
        public int IdLibro { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        public int Autor { get; set; }
        public int Añopublicacion { get; set; }
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;
        public int Categoria { get; set; }
        [Column("precio", TypeName = "money")]
        public decimal Precio { get; set; }
        [Column("editorial")]
        public int Editorial { get; set; }
        [Column("imagen")]
        [Unicode(false)]
        public string Imagen { get; set; } = null!;

        [ForeignKey("Autor")]
        [InverseProperty("Libros")]
        public virtual Autore AutorNavigation { get; set; } = null!;
        [ForeignKey("Categoria")]
        [InverseProperty("Libros")]
        public virtual Categoria CategoriaNavigation { get; set; } = null!;
        [ForeignKey("Editorial")]
        [InverseProperty("Libros")]
        public virtual Editoriale EditorialNavigation { get; set; } = null!;
        [InverseProperty("IdLibroNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdlibrosNavigation")]
        public virtual ICollection<Ordendetalle> Ordendetalles { get; set; }
    }
}
