using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIA.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    calle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ciudad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    numeroExt = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    pais = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    codpos = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    idAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.idAutor);
                });

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripción = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "cmetodopag",
                columns: table => new
                {
                    idmetpag = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cmetodopag", x => x.idmetpag);
                });

            migrationBuilder.CreateTable(
                name: "editoriales",
                columns: table => new
                {
                    ideditorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_editoriales", x => x.ideditorial);
                });

            migrationBuilder.CreateTable(
                name: "solicitudes",
                columns: table => new
                {
                    idSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Autor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solicitudes", x => x.idSolicitud);
                });

            migrationBuilder.CreateTable(
                name: "sugerencias",
                columns: table => new
                {
                    idsugerencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sugerencias", x => x.idsugerencia);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orden",
                columns: table => new
                {
                    idorden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idusuario = table.Column<int>(type: "int", nullable: false),
                    idmetodopag = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "money", nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden", x => x.idorden);
                    table.ForeignKey(
                        name: "FK_orden_cmetodopag",
                        column: x => x.idmetodopag,
                        principalTable: "cmetodopag",
                        principalColumn: "idmetpag");
                    table.ForeignKey(
                        name: "FK_orden_usuarios",
                        column: x => x.idusuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "libro",
                columns: table => new
                {
                    idLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Autor = table.Column<int>(type: "int", nullable: false),
                    Añopublicacion = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "money", nullable: false),
                    editorial = table.Column<int>(type: "int", nullable: false),
                    imagen = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libro", x => x.idLibro);
                    table.ForeignKey(
                        name: "FK_libro_Autores",
                        column: x => x.Autor,
                        principalTable: "Autores",
                        principalColumn: "idAutor");
                    table.ForeignKey(
                        name: "FK_libro_categorias",
                        column: x => x.Categoria,
                        principalTable: "categorias",
                        principalColumn: "idCategoria");
                    table.ForeignKey(
                        name: "FK_libro_editoriales",
                        column: x => x.editorial,
                        principalTable: "editoriales",
                        principalColumn: "ideditorial");
                });

            migrationBuilder.CreateTable(
                name: "carrito",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    IdLibro = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrito", x => new { x.idUsuario, x.IdLibro });
                    table.ForeignKey(
                        name: "FK_carrito_libro",
                        column: x => x.IdLibro,
                        principalTable: "libro",
                        principalColumn: "idLibro");
                    table.ForeignKey(
                        name: "FK_carrito_usuarios",
                        column: x => x.idUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ordendetalle",
                columns: table => new
                {
                    idorden = table.Column<int>(type: "int", nullable: false),
                    idlibros = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordendetalle_1", x => new { x.idorden, x.idlibros });
                    table.ForeignKey(
                        name: "FK_ordendetalle_libro",
                        column: x => x.idlibros,
                        principalTable: "libro",
                        principalColumn: "idLibro");
                    table.ForeignKey(
                        name: "FK_ordendetalle_orden",
                        column: x => x.idorden,
                        principalTable: "orden",
                        principalColumn: "idorden");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_carrito_IdLibro",
                table: "carrito",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_libro_Autor",
                table: "libro",
                column: "Autor");

            migrationBuilder.CreateIndex(
                name: "IX_libro_Categoria",
                table: "libro",
                column: "Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_libro_editorial",
                table: "libro",
                column: "editorial");

            migrationBuilder.CreateIndex(
                name: "IX_orden_idmetodopag",
                table: "orden",
                column: "idmetodopag");

            migrationBuilder.CreateIndex(
                name: "IX_orden_idusuario",
                table: "orden",
                column: "idusuario");

            migrationBuilder.CreateIndex(
                name: "IX_ordendetalle_idlibros",
                table: "ordendetalle",
                column: "idlibros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "carrito");

            migrationBuilder.DropTable(
                name: "ordendetalle");

            migrationBuilder.DropTable(
                name: "solicitudes");

            migrationBuilder.DropTable(
                name: "sugerencias");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "libro");

            migrationBuilder.DropTable(
                name: "orden");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "editoriales");

            migrationBuilder.DropTable(
                name: "cmetodopag");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
