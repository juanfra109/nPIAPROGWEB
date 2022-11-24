using Microsoft.EntityFrameworkCore;
using PIA.Models.dbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PIA.Dto
{
    public class EditorialesDto
    {
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
