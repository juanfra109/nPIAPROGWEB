using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIA.Models.dbModels
{
    [Table("orden")]
    public partial class Orden
    {
        public Orden()
        {
            Ordendetalles = new HashSet<Ordendetalle>();
        }

        [Key]
        [Column("idorden")]
        public int Idorden { get; set; }
        [Column("idusuario")]
        public int Idusuario { get; set; }
        [Column("idmetodopag")]
        public int Idmetodopag { get; set; }
        [Column("total", TypeName = "money")]
        public decimal Total { get; set; }
        [Column("fecha", TypeName = "date")]
        public DateTime Fecha { get; set; }

        [ForeignKey("Idmetodopag")]
        [InverseProperty("Ordens")]
        public virtual Cmetodopag IdmetodopagNavigation { get; set; } = null!;
        [ForeignKey("Idusuario")]
        [InverseProperty("Ordens")]
        public virtual Usuario IdusuarioNavigation { get; set; } = null!;
        [InverseProperty("IdordenNavigation")]
        public virtual ICollection<Ordendetalle> Ordendetalles { get; set; }
    }
}
