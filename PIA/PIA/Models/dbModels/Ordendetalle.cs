using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIA.Models.dbModels
{
    [Table("ordendetalle")]
    public partial class Ordendetalle
    {
        [Key]
        [Column("idorden")]
        public int Idorden { get; set; }
        [Key]
        [Column("idlibros")]
        public int Idlibros { get; set; }
        [Column("cantidad")]
        public int Cantidad { get; set; }
        [Column("precio", TypeName = "money")]
        public decimal Precio { get; set; }

        [ForeignKey("Idlibros")]
        [InverseProperty("Ordendetalles")]
        public virtual Libro IdlibrosNavigation { get; set; } = null!;
        [ForeignKey("Idorden")]
        [InverseProperty("Ordendetalles")]
        public virtual Orden IdordenNavigation { get; set; } = null!;
    }
}
