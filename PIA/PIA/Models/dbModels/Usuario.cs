using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIA.Models.dbModels
{
    [Table("usuarios")]
    public partial class Usuario
    {
        public Usuario()
        {
            Carritos = new HashSet<Carrito>();
            Ordens = new HashSet<Orden>();
        }

        [Key]
        [Column("idusuario")]
        public int Idusuario { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        [Unicode(false)]
        public string Nombre { get; set; } = null!;
        [Column("email")]
        [StringLength(50)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        [Column("contraseña")]
        [StringLength(50)]
        [Unicode(false)]
        public string Contraseña { get; set; } = null!;
        [Column("idRol")]
        public int IdRol { get; set; }
        [Column("calle")]
        [StringLength(50)]
        [Unicode(false)]
        public string Calle { get; set; } = null!;
        [Column("estado")]
        [StringLength(50)]
        [Unicode(false)]
        public string Estado { get; set; } = null!;
        [Column("ciudad")]
        [StringLength(50)]
        [Unicode(false)]
        public string Ciudad { get; set; } = null!;
        [Column("numeroExt")]
        [StringLength(50)]
        [Unicode(false)]
        public string NumeroExt { get; set; } = null!;
        [Column("pais")]
        [StringLength(50)]
        [Unicode(false)]
        public string Pais { get; set; } = null!;
        [Column("codpos")]
        [StringLength(50)]
        [Unicode(false)]
        public string Codpos { get; set; } = null!;

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; }
        [InverseProperty("IdusuarioNavigation")]
        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
