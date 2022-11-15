using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIA.Models.dbModels
{
    [Table("cmetodopag")]
    public partial class Cmetodopag
    {
        public Cmetodopag()
        {
            Ordens = new HashSet<Orden>();
        }

        [Key]
        [Column("idmetpag")]
        public int Idmetpag { get; set; }
        [Column("descripcion")]
        [StringLength(50)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;

        [InverseProperty("IdmetodopagNavigation")]
        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
