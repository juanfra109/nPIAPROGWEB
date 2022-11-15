using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIA.Models.dbModels
{
    [Table("sugerencias")]
    public partial class Sugerencia
    {
        [Key]
        [Column("idsugerencia")]
        public int Idsugerencia { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;
        [Column("fecha", TypeName = "date")]
        public DateTime Fecha { get; set; }
    }
}
