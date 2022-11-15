IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AspNetRoles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] int NOT NULL IDENTITY,
    [idusuario] int NOT NULL,
    [nombre] varchar(50) NOT NULL,
    [email] varchar(256) NOT NULL,
    [contraseña] varchar(50) NOT NULL,
    [idRol] int NOT NULL,
    [calle] varchar(50) NOT NULL,
    [estado] varchar(50) NOT NULL,
    [ciudad] varchar(50) NOT NULL,
    [numeroExt] varchar(50) NOT NULL,
    [pais] varchar(50) NOT NULL,
    [codpos] varchar(50) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Autores] (
    [idAutor] int NOT NULL IDENTITY,
    [Nombre] varchar(50) NOT NULL,
    CONSTRAINT [PK_Autores] PRIMARY KEY ([idAutor])
);
GO

CREATE TABLE [categorias] (
    [idCategoria] int NOT NULL IDENTITY,
    [Descripción] varchar(50) NOT NULL,
    CONSTRAINT [PK_categorias] PRIMARY KEY ([idCategoria])
);
GO

CREATE TABLE [cmetodopag] (
    [idmetpag] int NOT NULL IDENTITY,
    [descripcion] varchar(50) NOT NULL,
    CONSTRAINT [PK_cmetodopag] PRIMARY KEY ([idmetpag])
);
GO

CREATE TABLE [editoriales] (
    [ideditorial] int NOT NULL IDENTITY,
    [Nombre] varchar(50) NOT NULL,
    CONSTRAINT [PK_editoriales] PRIMARY KEY ([ideditorial])
);
GO

CREATE TABLE [idRol] (
    [idRol] int NOT NULL IDENTITY,
    [Descripción] varchar(50) NOT NULL,
    CONSTRAINT [PK_idRol] PRIMARY KEY ([idRol])
);
GO

CREATE TABLE [solicitudes] (
    [idSolicitud] int NOT NULL IDENTITY,
    [Titulo] varchar(50) NOT NULL,
    [Autor] varchar(50) NOT NULL,
    [fecha] date NOT NULL,
    CONSTRAINT [PK_solicitudes] PRIMARY KEY ([idSolicitud])
);
GO

CREATE TABLE [sugerencias] (
    [idsugerencia] int NOT NULL IDENTITY,
    [Descripcion] varchar(50) NOT NULL,
    [fecha] date NOT NULL,
    CONSTRAINT [PK_sugerencias] PRIMARY KEY ([idsugerencia])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] int NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] int NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [orden] (
    [idorden] int NOT NULL IDENTITY,
    [idusuario] int NOT NULL,
    [idmetodopag] int NOT NULL,
    [total] money NOT NULL,
    [fecha] date NOT NULL,
    CONSTRAINT [PK_orden] PRIMARY KEY ([idorden]),
    CONSTRAINT [FK_orden_cmetodopag] FOREIGN KEY ([idmetodopag]) REFERENCES [cmetodopag] ([idmetpag]),
    CONSTRAINT [FK_orden_usuarios] FOREIGN KEY ([idusuario]) REFERENCES [AspNetUsers] ([Id])
);
GO

CREATE TABLE [libro] (
    [idLibro] int NOT NULL IDENTITY,
    [Nombre] varchar(50) NOT NULL,
    [Autor] int NOT NULL,
    [Añopublicacion] int NOT NULL,
    [Descripcion] varchar(max) NOT NULL,
    [Categoria] int NOT NULL,
    [precio] money NOT NULL,
    [editorial] int NOT NULL,
    [imagen] varchar(max) NOT NULL,
    CONSTRAINT [PK_libro] PRIMARY KEY ([idLibro]),
    CONSTRAINT [FK_libro_Autores] FOREIGN KEY ([Autor]) REFERENCES [Autores] ([idAutor]),
    CONSTRAINT [FK_libro_categorias] FOREIGN KEY ([Categoria]) REFERENCES [categorias] ([idCategoria]),
    CONSTRAINT [FK_libro_editoriales] FOREIGN KEY ([editorial]) REFERENCES [editoriales] ([ideditorial])
);
GO

CREATE TABLE [carrito] (
    [idUsuario] int NOT NULL,
    [IdLibro] int NOT NULL,
    [cantidad] int NOT NULL,
    [total] money NOT NULL,
    CONSTRAINT [PK_carrito] PRIMARY KEY ([idUsuario], [IdLibro]),
    CONSTRAINT [FK_carrito_libro] FOREIGN KEY ([IdLibro]) REFERENCES [libro] ([idLibro]),
    CONSTRAINT [FK_carrito_usuarios] FOREIGN KEY ([idUsuario]) REFERENCES [AspNetUsers] ([Id])
);
GO

CREATE TABLE [ordendetalle] (
    [idorden] int NOT NULL,
    [idlibros] int NOT NULL,
    [cantidad] int NOT NULL,
    [precio] money NOT NULL,
    CONSTRAINT [PK_ordendetalle_1] PRIMARY KEY ([idorden], [idlibros]),
    CONSTRAINT [FK_ordendetalle_libro] FOREIGN KEY ([idlibros]) REFERENCES [libro] ([idLibro]),
    CONSTRAINT [FK_ordendetalle_orden] FOREIGN KEY ([idorden]) REFERENCES [orden] ([idorden])
);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

CREATE INDEX [IX_carrito_IdLibro] ON [carrito] ([IdLibro]);
GO

CREATE INDEX [IX_libro_Autor] ON [libro] ([Autor]);
GO

CREATE INDEX [IX_libro_Categoria] ON [libro] ([Categoria]);
GO

CREATE INDEX [IX_libro_editorial] ON [libro] ([editorial]);
GO

CREATE INDEX [IX_orden_idmetodopag] ON [orden] ([idmetodopag]);
GO

CREATE INDEX [IX_orden_idusuario] ON [orden] ([idusuario]);
GO

CREATE INDEX [IX_ordendetalle_idlibros] ON [ordendetalle] ([idlibros]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221115062711_NLibreriaProyecto', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [idRol];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221115064517_LibreriaPIA', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221115064816_pialibreria', N'6.0.10');
GO

COMMIT;
GO

