USE [gnecco]
GO
/****** Object:  Table [dbo].[CoordenadasInventario]    Script Date: 10/02/2015 12:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CoordenadasInventario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InventarioId] [int] NOT NULL,
	[PointLeft] [decimal](18, 0) NOT NULL,
	[PointTop] [decimal](18, 0) NOT NULL,
	[PointRight] [decimal](18, 0) NOT NULL,
	[PointBottom] [decimal](18, 0) NOT NULL,
	[Orden] [int] NOT NULL,
	[EstadoAutoparte] [varchar](max) NOT NULL,
	[Comentario] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleInformeInspeccion]    Script Date: 10/02/2015 12:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetalleInformeInspeccion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InformeInspeccionId] [int] NULL,
	[GrupoInformeInspeccionId] [int] NULL,
	[Descripcion] [text] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[IndicadorEstado] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleInformeInspeccionCompleto]    Script Date: 10/02/2015 12:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetalleInformeInspeccionCompleto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InformeInspeccionCompletoId] [int] NULL,
	[DetalleInformeInspeccionId] [int] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[GrupoInformeInspeccionCompletoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GrupoInformeInspeccion]    Script Date: 10/02/2015 12:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GrupoInformeInspeccion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[InformeInspeccionId] [int] NULL,
	[IndicadorEstado] [varchar](1) NOT NULL,
	[GrupoInformeInspeccionId] [int] NULL,
	[CodigoAgrupacion] [int] NULL,
	[TipoGrupo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GrupoInformeInspeccionCompleto]    Script Date: 10/02/2015 12:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GrupoInformeInspeccionCompleto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[GrupoInformeInspeccionId] [int] NULL,
	[InformeInspeccionCompletoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InformeInspeccion]    Script Date: 10/02/2015 12:01:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InformeInspeccion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[IndicadorEstado] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InformeInspeccionCompleto]    Script Date: 10/02/2015 12:01:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InformeInspeccionCompleto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InformeInspeccionId] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IndicadorEstado] [varchar](1) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InformeInspeccionFordCompleto]    Script Date: 10/02/2015 12:01:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InformeInspeccionFordCompleto](
	[Id] [int] NOT NULL,
	[NombreCliente] [varchar](100) NOT NULL,
	[CorreoCliente] [varchar](100) NOT NULL,
	[Comentarios] [varchar](max) NOT NULL,
	[AsesorServicio] [varchar](50) NOT NULL,
	[RoTag] [varchar](50) NOT NULL,
	[MesInspeccionEstatal] [varchar](50) NOT NULL,
	[Tecnico] [varchar](50) NOT NULL,
	[Marca] [varchar](50) NOT NULL,
	[Modelo] [varchar](50) NOT NULL,
	[Anio] [int] NOT NULL,
	[Millaje] [varchar](50) NOT NULL,
	[Vin] [varchar](50) NOT NULL,
	[Placa] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InformeInspeccionNissanCompleto]    Script Date: 10/02/2015 12:01:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InformeInspeccionNissanCompleto](
	[Id] [int] NOT NULL,
	[Preventivo] [int] NOT NULL,
	[Correctivo] [int] NOT NULL,
	[Kms] [varchar](max) NOT NULL,
	[NumeroOT] [varchar](max) NOT NULL,
	[Cliente] [varchar](max) NOT NULL,
	[Tecnico] [varchar](max) NOT NULL,
	[Placa] [varchar](max) NOT NULL,
	[ResultadosMantenimiento] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InformeInspeccionVolkswagenCompleto]    Script Date: 10/02/2015 12:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InformeInspeccionVolkswagenCompleto](
	[Id] [int] NOT NULL,
	[Comentarios] [varchar](max) NULL,
	[Km] [varchar](40) NOT NULL,
	[LetraDistribucionMotor] [varchar](40) NOT NULL,
	[NombreTecnico] [varchar](max) NOT NULL,
	[Orden] [varchar](100) NOT NULL,
	[Placa] [varchar](20) NOT NULL,
	[Vin] [varchar](max) NOT NULL,
	[IntervaloKilometros] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 10/02/2015 12:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Inventario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaRecepcion] [datetime] NOT NULL,
	[HoraRecepcion] [datetime] NOT NULL,
	[Placa] [varchar](max) NOT NULL,
	[KilometrajeLlegada] [varchar](max) NOT NULL,
	[FechaPrometida] [datetime] NOT NULL,
	[HoraPrometida] [datetime] NOT NULL,
	[FacturarA] [varchar](max) NOT NULL,
	[Ruc] [varchar](max) NOT NULL,
	[Propietario] [varchar](max) NOT NULL,
	[BoletaFactura] [bit] NULL,
	[Direccion] [varchar](max) NOT NULL,
	[TelefonoMovil] [varchar](max) NOT NULL,
	[CorreoElectronico] [varchar](max) NOT NULL,
	[Dni] [varchar](8) NOT NULL,
	[ManifestoCLiente] [text] NOT NULL,
	[RutaFirma] [varchar](max) NOT NULL,
	[Cenicero] [bit] NULL,
	[Encendedor] [bit] NULL,
	[Radio] [bit] NULL,
	[MascaraRadio] [bit] NULL,
	[Antena] [bit] NULL,
	[TarjetaPropiedad] [bit] NULL,
	[Soat] [bit] NULL,
	[SeguroRueda] [bit] NULL,
	[VasosRueda] [bit] NULL,
	[LucesBajas] [bit] NULL,
	[TapaSol] [bit] NULL,
	[PlumillasDuchas] [bit] NULL,
	[Escapines] [bit] NULL,
	[EmblMascara] [bit] NULL,
	[TapaAceite] [bit] NULL,
	[TapaTanqueComb] [bit] NULL,
	[TapaRadiador] [bit] NULL,
	[TapaDepRefrg] [bit] NULL,
	[TapaDepLiqFren] [bit] NULL,
	[LlantaRepuesto] [bit] NULL,
	[LucesAltas] [bit] NULL,
	[Neblineros] [bit] NULL,
	[Claxon] [bit] NULL,
	[Espejos] [bit] NULL,
	[PisosJebeAlfombra] [bit] NULL,
	[CorteCorriente] [bit] NULL,
	[LunasElectricasDelt] [bit] NULL,
	[LunasElectricasPost] [bit] NULL,
	[SistVentilador] [bit] NULL,
	[Tacometro] [bit] NULL,
	[GataPalanca] [bit] NULL,
	[LlaveRueda] [bit] NULL,
	[EmblMaletera] [bit] NULL,
	[Herramientas] [bit] NULL,
	[CajaCd] [bit] NULL,
	[Botiquin] [bit] NULL,
	[Extintor] [bit] NULL,
	[Triangulo] [bit] NULL,
	[CableBateria] [bit] NULL,
	[CableRemolque] [bit] NULL,
	[ObjetosValor] [bit] NULL,
	[VehiculoSucioRayaduras] [bit] NULL,
	[Asesor] [varchar](max) NOT NULL,
	[Observaciones] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Opcion]    Script Date: 10/02/2015 12:01:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Opcion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DetalleInformeInspeccionId] [int] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[CodigoAgrupacion] [int] NOT NULL,
	[IndicadorEstado] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ValorOpcion]    Script Date: 10/02/2015 12:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ValorOpcion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DetalleInformeInspeccionCompletoId] [int] NOT NULL,
	[OpcionId] [int] NOT NULL,
	[Valor] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DetalleInformeInspeccion] ADD  CONSTRAINT [DEFAULT_INDICADOR_ESTADO_DETALLE_INFORME_INSPECCION]  DEFAULT ('A') FOR [IndicadorEstado]
GO
ALTER TABLE [dbo].[GrupoInformeInspeccion] ADD  CONSTRAINT [DEFAULT_INDICADOR_ESTADO_GRUPO_INFORME_INSPECCION]  DEFAULT ('A') FOR [IndicadorEstado]
GO
ALTER TABLE [dbo].[InformeInspeccion] ADD  CONSTRAINT [DEFAULT_FECHA_CREACION_INFORME_INSPECCION]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[InformeInspeccion] ADD  CONSTRAINT [DEFAULT_INDICADOR_ESTADO_INFORME_INSPECCION]  DEFAULT ('A') FOR [IndicadorEstado]
GO
ALTER TABLE [dbo].[InformeInspeccionCompleto] ADD  CONSTRAINT [DEFAULT_FECHA_INFORME_INSPECCION_COMPLETO]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[InformeInspeccionCompleto] ADD  CONSTRAINT [DEFAULT_INDICADOR_ESTADO_INFORME_INSPECCION_COMPLETO]  DEFAULT ('A') FOR [IndicadorEstado]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [BoletaFactura]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Cenicero]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Encendedor]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Radio]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [MascaraRadio]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Antena]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [TarjetaPropiedad]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Soat]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [SeguroRueda]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [VasosRueda]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [LucesBajas]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [TapaSol]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [PlumillasDuchas]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Escapines]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [EmblMascara]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [TapaAceite]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [TapaTanqueComb]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [TapaRadiador]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [TapaDepRefrg]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [TapaDepLiqFren]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [LlantaRepuesto]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [LucesAltas]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Neblineros]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Claxon]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Espejos]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [PisosJebeAlfombra]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [CorteCorriente]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [LunasElectricasDelt]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [LunasElectricasPost]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [SistVentilador]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Tacometro]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [GataPalanca]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [LlaveRueda]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [EmblMaletera]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Herramientas]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [CajaCd]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Botiquin]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Extintor]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [Triangulo]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [CableBateria]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [CableRemolque]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [ObjetosValor]
GO
ALTER TABLE [dbo].[Inventario] ADD  DEFAULT ((1)) FOR [VehiculoSucioRayaduras]
GO
ALTER TABLE [dbo].[Opcion] ADD  CONSTRAINT [DEFAULT_INDICADOR_ESTADO_OPCION]  DEFAULT ('A') FOR [IndicadorEstado]
GO
ALTER TABLE [dbo].[CoordenadasInventario]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_X_COORDENADAS_INVENTARIO] FOREIGN KEY([InventarioId])
REFERENCES [dbo].[Inventario] ([Id])
GO
ALTER TABLE [dbo].[CoordenadasInventario] CHECK CONSTRAINT [FK_INVENTARIO_X_COORDENADAS_INVENTARIO]
GO
ALTER TABLE [dbo].[DetalleInformeInspeccion]  WITH CHECK ADD  CONSTRAINT [FK_GRUPO_INFORME_X_DETALLE_INFORME_INSPECCION] FOREIGN KEY([GrupoInformeInspeccionId])
REFERENCES [dbo].[GrupoInformeInspeccion] ([Id])
GO
ALTER TABLE [dbo].[DetalleInformeInspeccion] CHECK CONSTRAINT [FK_GRUPO_INFORME_X_DETALLE_INFORME_INSPECCION]
GO
ALTER TABLE [dbo].[DetalleInformeInspeccion]  WITH CHECK ADD  CONSTRAINT [FK_INFORME_INSPECCION_X_DETALLE_INFORME_INSPECCION] FOREIGN KEY([InformeInspeccionId])
REFERENCES [dbo].[InformeInspeccion] ([Id])
GO
ALTER TABLE [dbo].[DetalleInformeInspeccion] CHECK CONSTRAINT [FK_INFORME_INSPECCION_X_DETALLE_INFORME_INSPECCION]
GO
ALTER TABLE [dbo].[DetalleInformeInspeccionCompleto]  WITH CHECK ADD  CONSTRAINT [FK_DETALLE_INFORME_INSPECCION_X_DETALLE_INFORME_INSPECCION_COMPLETO] FOREIGN KEY([DetalleInformeInspeccionId])
REFERENCES [dbo].[DetalleInformeInspeccion] ([Id])
GO
ALTER TABLE [dbo].[DetalleInformeInspeccionCompleto] CHECK CONSTRAINT [FK_DETALLE_INFORME_INSPECCION_X_DETALLE_INFORME_INSPECCION_COMPLETO]
GO
ALTER TABLE [dbo].[DetalleInformeInspeccionCompleto]  WITH CHECK ADD  CONSTRAINT [FK_GRUPO_INFORME_INSPECCION_COMPLETO_X_DETALLE_INFORME_INSPECCION_COMPLETO] FOREIGN KEY([GrupoInformeInspeccionCompletoId])
REFERENCES [dbo].[GrupoInformeInspeccionCompleto] ([Id])
GO
ALTER TABLE [dbo].[DetalleInformeInspeccionCompleto] CHECK CONSTRAINT [FK_GRUPO_INFORME_INSPECCION_COMPLETO_X_DETALLE_INFORME_INSPECCION_COMPLETO]
GO
ALTER TABLE [dbo].[DetalleInformeInspeccionCompleto]  WITH CHECK ADD  CONSTRAINT [FK_INFORME_INSPECCION_COMPLETO_X_DETALLE_INFORME_INSPECCION_COMPLETO] FOREIGN KEY([InformeInspeccionCompletoId])
REFERENCES [dbo].[InformeInspeccionCompleto] ([Id])
GO
ALTER TABLE [dbo].[DetalleInformeInspeccionCompleto] CHECK CONSTRAINT [FK_INFORME_INSPECCION_COMPLETO_X_DETALLE_INFORME_INSPECCION_COMPLETO]
GO
ALTER TABLE [dbo].[GrupoInformeInspeccion]  WITH CHECK ADD  CONSTRAINT [FK_GRUPO_INFORME_INSPECCION_X_GRUPO_INFORME_INSPECCION] FOREIGN KEY([GrupoInformeInspeccionId])
REFERENCES [dbo].[GrupoInformeInspeccion] ([Id])
GO
ALTER TABLE [dbo].[GrupoInformeInspeccion] CHECK CONSTRAINT [FK_GRUPO_INFORME_INSPECCION_X_GRUPO_INFORME_INSPECCION]
GO
ALTER TABLE [dbo].[GrupoInformeInspeccion]  WITH CHECK ADD  CONSTRAINT [FK_INFORME_INSPECCION_X_GRUPO_INFORME_INSPECCION] FOREIGN KEY([InformeInspeccionId])
REFERENCES [dbo].[InformeInspeccion] ([Id])
GO
ALTER TABLE [dbo].[GrupoInformeInspeccion] CHECK CONSTRAINT [FK_INFORME_INSPECCION_X_GRUPO_INFORME_INSPECCION]
GO
ALTER TABLE [dbo].[GrupoInformeInspeccionCompleto]  WITH CHECK ADD  CONSTRAINT [FK_GRUPO_INFORME_INSPECCION_X_GRUPO_INFORME_INSPECCION_COMPLETO] FOREIGN KEY([GrupoInformeInspeccionId])
REFERENCES [dbo].[GrupoInformeInspeccion] ([Id])
GO
ALTER TABLE [dbo].[GrupoInformeInspeccionCompleto] CHECK CONSTRAINT [FK_GRUPO_INFORME_INSPECCION_X_GRUPO_INFORME_INSPECCION_COMPLETO]
GO
ALTER TABLE [dbo].[GrupoInformeInspeccionCompleto]  WITH CHECK ADD  CONSTRAINT [FK_INFORME_INSPECCION_COMPLETO_X_GRUPO_INFORME_INSPECCION_COMPLETO] FOREIGN KEY([InformeInspeccionCompletoId])
REFERENCES [dbo].[InformeInspeccionCompleto] ([Id])
GO
ALTER TABLE [dbo].[GrupoInformeInspeccionCompleto] CHECK CONSTRAINT [FK_INFORME_INSPECCION_COMPLETO_X_GRUPO_INFORME_INSPECCION_COMPLETO]
GO
ALTER TABLE [dbo].[InformeInspeccionCompleto]  WITH CHECK ADD  CONSTRAINT [FK_INFORME_INSPECCION_X_INFORME_INSPECCION_COMPLETO] FOREIGN KEY([InformeInspeccionId])
REFERENCES [dbo].[InformeInspeccion] ([Id])
GO
ALTER TABLE [dbo].[InformeInspeccionCompleto] CHECK CONSTRAINT [FK_INFORME_INSPECCION_X_INFORME_INSPECCION_COMPLETO]
GO
ALTER TABLE [dbo].[InformeInspeccionFordCompleto]  WITH CHECK ADD  CONSTRAINT [FK_INFORME_INSPECCION_COMPLETO_X_INFORME_INSPECCION_FORD_COMPLETO] FOREIGN KEY([Id])
REFERENCES [dbo].[InformeInspeccionCompleto] ([Id])
GO
ALTER TABLE [dbo].[InformeInspeccionFordCompleto] CHECK CONSTRAINT [FK_INFORME_INSPECCION_COMPLETO_X_INFORME_INSPECCION_FORD_COMPLETO]
GO
ALTER TABLE [dbo].[InformeInspeccionNissanCompleto]  WITH CHECK ADD  CONSTRAINT [FK_INFORME_INSPECCION_COMPLETO_X_INFORME_INSPECCION_NISSAN_COMPLETO] FOREIGN KEY([Id])
REFERENCES [dbo].[InformeInspeccionCompleto] ([Id])
GO
ALTER TABLE [dbo].[InformeInspeccionNissanCompleto] CHECK CONSTRAINT [FK_INFORME_INSPECCION_COMPLETO_X_INFORME_INSPECCION_NISSAN_COMPLETO]
GO
ALTER TABLE [dbo].[InformeInspeccionVolkswagenCompleto]  WITH CHECK ADD  CONSTRAINT [FK_INFORME_INSPECCION_COMPLETO_X_INFORME_INSPECCION_VOLKSWAGEN_COMPLETO] FOREIGN KEY([Id])
REFERENCES [dbo].[InformeInspeccionCompleto] ([Id])
GO
ALTER TABLE [dbo].[InformeInspeccionVolkswagenCompleto] CHECK CONSTRAINT [FK_INFORME_INSPECCION_COMPLETO_X_INFORME_INSPECCION_VOLKSWAGEN_COMPLETO]
GO
ALTER TABLE [dbo].[Opcion]  WITH CHECK ADD  CONSTRAINT [FK_DETALLE_INFORME_INSPECCION_X_DETALLE_INFORME_INSPECCION_VOLKSWAGEN] FOREIGN KEY([DetalleInformeInspeccionId])
REFERENCES [dbo].[DetalleInformeInspeccion] ([Id])
GO
ALTER TABLE [dbo].[Opcion] CHECK CONSTRAINT [FK_DETALLE_INFORME_INSPECCION_X_DETALLE_INFORME_INSPECCION_VOLKSWAGEN]
GO
ALTER TABLE [dbo].[ValorOpcion]  WITH CHECK ADD  CONSTRAINT [FK_DETALLE_INFORME_INSPECCION_COMPLETO_X_VALOR_OPCION] FOREIGN KEY([DetalleInformeInspeccionCompletoId])
REFERENCES [dbo].[DetalleInformeInspeccionCompleto] ([Id])
GO
ALTER TABLE [dbo].[ValorOpcion] CHECK CONSTRAINT [FK_DETALLE_INFORME_INSPECCION_COMPLETO_X_VALOR_OPCION]
GO
ALTER TABLE [dbo].[ValorOpcion]  WITH CHECK ADD  CONSTRAINT [FK_OPCION_X_VALOR_OPCION] FOREIGN KEY([OpcionId])
REFERENCES [dbo].[Opcion] ([Id])
GO
ALTER TABLE [dbo].[ValorOpcion] CHECK CONSTRAINT [FK_OPCION_X_VALOR_OPCION]
GO
