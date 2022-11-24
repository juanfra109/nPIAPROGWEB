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
    public class LibroCreateDto
    {
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        public int Autor { get; set; }
        public int Añopublicacion { get; set; }
        [Unicode(false)]
        public string Descripcion { get; set; } = null!;
        public int Categoria { get; set; }
        public decimal Precio { get; set; }
        public int Editorial { get; set; }
        public string Imagen { get; set; } = null!; 
    }
}
