CREATE TABLE [TipoPermiso] (
    [Id] int NOT NULL IDENTITY,
    [Descripcion] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_TipoPermiso] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Permiso] (
    [Id] int NOT NULL IDENTITY,
    [NombreEmpleado] nvarchar(50) NOT NULL,
    [ApellidosEmpleado] nvarchar(50) NOT NULL,
    [TipoPermisoId] int NOT NULL,
    [Fecha] datetime2 NOT NULL,
    CONSTRAINT [PK_Permiso] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Permiso_TipoPermiso_TipoPermisoId] FOREIGN KEY ([TipoPermisoId]) REFERENCES [TipoPermiso] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Permiso_TipoPermisoId] ON [Permiso] ([TipoPermisoId]);

GO
