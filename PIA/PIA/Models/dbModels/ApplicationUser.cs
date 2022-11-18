using Microsoft.EntityFrameworkCore;
using PIA.Models.dbModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;



public class ApplicationUser : IdentityUser<int>
{
    public ApplicationUser()
    {
        Carritos = new HashSet<Carrito>();
        Ordens = new HashSet<Orden>();
    }

    [Column("nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;
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

