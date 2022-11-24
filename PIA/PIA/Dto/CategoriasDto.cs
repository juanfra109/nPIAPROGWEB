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
    public class CategoriasDto
    {
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
