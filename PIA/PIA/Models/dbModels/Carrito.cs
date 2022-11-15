using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIA.Models.dbModels
{
    [Table("carrito")]
    public partial class Carrito
    {
        [Key]
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Key]
        public int IdLibro { get; set; }
        [Column("cantidad")]
        public int Cantidad { get; set; }
        [Column("total", TypeName = "money")]
        public decimal Total { get; set; }

        [ForeignKey("IdLibro")]
        [InverseProperty("Carritos")]
        public virtual Libro IdLibroNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("Carritos")]
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
