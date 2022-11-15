using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIA.Models.dbModels
{
    [Table("solicitudes")]
    public partial class Solicitude
    {
        [Key]
        [Column("idSolicitud")]
        public int IdSolicitud { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Titulo { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Autor { get; set; } = null!;
        [Column("fecha", TypeName = "date")]
        public DateTime Fecha { get; set; }
    }
}
