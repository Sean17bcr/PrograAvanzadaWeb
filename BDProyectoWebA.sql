USE [master]
GO
/****** Object:  Database [ProyectoPrograAvanzadaWebF]    Script Date: 14/12/2023 11:51:51 ******/
CREATE DATABASE [ProyectoPrograAvanzadaWebF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProyectoPrograAvanzadaWebF', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ProyectoPrograAvanzadaWebF.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProyectoPrograAvanzadaWebF_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ProyectoPrograAvanzadaWebF_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyectoPrograAvanzadaWebF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET  MULTI_USER 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProyectoPrograAvanzadaWebF]
GO
/****** Object:  Table [dbo].[Comentarios]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentarios](
	[IdComentarios] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [bigint] NOT NULL,
	[comentario] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdComentarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Errores]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Errores](
	[IdError] [bigint] NOT NULL,
	[FechaError] [datetime] NULL,
	[Metodo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdError] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservas](
	[IdReservas] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [bigint] NOT NULL,
	[fecha_reserva] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdReservas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TCarrito]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TCarrito](
	[IdCarrito] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_TCarrito] PRIMARY KEY CLUSTERED 
(
	[IdCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TDetalle]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TDetalle](
	[IdDetalle] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFactura] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Impuesto] [decimal](18, 2) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TDetalle] PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TEncabezado]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TEncabezado](
	[IdFactura] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [bigint] NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[TotalPago] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TEncabezado] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TProducto]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TProducto](
	[IdProducto] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Imagen] [varchar](500) NOT NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [PK_TProducto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRol]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRol](
	[ConRol] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TRol] PRIMARY KEY CLUSTERED 
(
	[ConRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [bigint] IDENTITY(1,1) NOT NULL,
	[identificacion] [varchar](20) NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[usuario] [varchar](25) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[contrasenna] [varchar](25) NOT NULL,
	[ConRol] [bigint] NOT NULL,
	[estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD  CONSTRAINT [FK_Comentarios_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Comentarios] CHECK CONSTRAINT [FK_Comentarios_Usuario]
GO
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Usuario]
GO
ALTER TABLE [dbo].[TCarrito]  WITH CHECK ADD  CONSTRAINT [FK_TCarrito_TProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[TProducto] ([IdProducto])
GO
ALTER TABLE [dbo].[TCarrito] CHECK CONSTRAINT [FK_TCarrito_TProducto]
GO
ALTER TABLE [dbo].[TCarrito]  WITH CHECK ADD  CONSTRAINT [FK_TCarrito_Usuario1] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TCarrito] CHECK CONSTRAINT [FK_TCarrito_Usuario1]
GO
ALTER TABLE [dbo].[TDetalle]  WITH CHECK ADD  CONSTRAINT [FK_TDetalle_TDetalle] FOREIGN KEY([IdFactura])
REFERENCES [dbo].[TEncabezado] ([IdFactura])
GO
ALTER TABLE [dbo].[TDetalle] CHECK CONSTRAINT [FK_TDetalle_TDetalle]
GO
ALTER TABLE [dbo].[TDetalle]  WITH CHECK ADD  CONSTRAINT [FK_TDetalle_TProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[TProducto] ([IdProducto])
GO
ALTER TABLE [dbo].[TDetalle] CHECK CONSTRAINT [FK_TDetalle_TProducto]
GO
ALTER TABLE [dbo].[TEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_TEncabezado_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TEncabezado] CHECK CONSTRAINT [FK_TEncabezado_Usuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TRol] FOREIGN KEY([ConRol])
REFERENCES [dbo].[TRol] ([ConRol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TRol]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarReserva]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarReserva]
	@IdReservas bigint,
	@IdUsuario bigint,
	@fecha_reserva datetime
AS
BEGIN
	UPDATE dbo.Reservas
	SET IdUsuario = @IdUsuario,
		fecha_reserva = @fecha_reserva
	WHERE IdReservas = @IdReservas;
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarUsuario]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarUsuario]
	@IdUsuario bigint,
	@nombre varchar(200),
	@usuario varchar(25),
	@ConRol bigint,
	@estado bit
AS
BEGIN
	UPDATE dbo.Usuario
	SET nombre = @nombre,
		usuario = @usuario,
		ConRol = @ConRol,
		estado = @estado
	WHERE IdUsuario = @IdUsuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCarrito]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConsultarCarrito]
	@IdUsuario	bigint
AS
BEGIN

	SELECT	IdCarrito,
			IdUsuario,
			C.IdProducto,
			C.Cantidad,
			Fecha,
			P.Precio,
			P.Precio * C.Cantidad 'SubTotal',
			(P.Precio * C.Cantidad) * 0.13 'Impuesto',
			P.Precio * C.Cantidad + (P.Precio * C.Cantidad) * 0.13 'Total',
			P.Nombre
	FROM	dbo.TCarrito C
	INNER JOIN dbo.TProducto P ON C.IdProducto = P.IdProducto
	WHERE	IdUsuario = @IdUsuario

END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarDetalleFactura]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[ConsultarDetalleFactura]
	@IdFactura	bigint
AS
BEGIN

	SELECT	D.IdFactura,
			D.Cantidad,
			D.Precio,
			D.Impuesto,
			D.Precio * D.Cantidad	'SubTotal',
			(D.Impuesto * D.Cantidad) 'ImpuestoTotal',
			(D.Precio * D.Cantidad) + (D.Impuesto * D.Cantidad) 'Total',
			P.Nombre
	FROM	dbo.TDetalle D
	INNER JOIN dbo.TProducto P ON D.IdProducto = P.IdProducto
	WHERE	IdFactura = @IdFactura

END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarFacturas]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[ConsultarFacturas]
	@IdUsuario	bigint
AS
BEGIN

	SELECT	IdFactura,
			FechaPago,
			TotalPago
	FROM	dbo.TEncabezado
	WHERE	IdUsuario = @IdUsuario

END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarProductos]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarProductos]
AS
BEGIN
    
    SELECT * FROM dbo.TProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarProducto]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarProducto]
    @idProducto bigint,
    @nombre varchar(200),
    @descripcion varchar(500),
    @precio decimal(10, 2),
    @imagen varchar(500)
AS
BEGIN
    UPDATE dbo.TProducto
    SET nombre = @nombre,
        descripcion = @descripcion,
        precio = @precio,
        Imagen = @imagen
    WHERE IdProducto = @idProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarComentarioPorId]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[EliminarComentarioPorId]
    @idComentario bigint
AS
BEGIN
    
    DELETE FROM dbo.Comentarios
    WHERE IdComentarios = @idComentario;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarProductoCarrito]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[EliminarProductoCarrito]
	@IdCarrito AS BIGINT
AS
BEGIN
	
	DELETE FROM TCarrito
	WHERE IdCarrito = @IdCarrito

END
GO
/****** Object:  StoredProcedure [dbo].[EliminarProductoPorId]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarProductoPorId]
    @idProducto bigint
AS
BEGIN
    
    DELETE FROM dbo.TProducto
    WHERE IdProducto = @idProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarReservaPorId]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarReservaPorId]
	@IdReservas bigint
AS
BEGIN
	DELETE FROM dbo.Reservas
	WHERE IdReservas = @IdReservas;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuarioPorId]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarUsuarioPorId]
	@IdUsuario bigint
AS
BEGIN
	 -- Eliminar reservas asociadas al usuario
    DELETE FROM dbo.Reservas
    WHERE IdUsuario = @IdUsuario;

    -- Eliminar el usuario
    DELETE FROM dbo.Usuario
    WHERE IdUsuario = @IdUsuario;
END;

GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IniciarSesion]
	@usuario		VARCHAR(25),
	@contrasenna	VARCHAR(25)
AS
BEGIN

	SELECT	IdUsuario, nombre, identificacion, correo, usuario, estado, ConRol
	FROM	Usuario
	WHERE	(usuario = @usuario OR correo = @usuario)
		AND contrasenna = @contrasenna
		AND estado		= 1

END
GO
/****** Object:  StoredProcedure [dbo].[InsertarReserva]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertarReserva]
	@IdUsuario bigint,
	@fecha_reserva datetime
AS
BEGIN
	INSERT INTO dbo.Reservas (IdUsuario, fecha_reserva)
	VALUES (@IdUsuario, @fecha_reserva);
END;

GO
/****** Object:  StoredProcedure [dbo].[ObtenerReservaPorId]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerReservaPorId]
	@IdReservas bigint
AS
BEGIN
	SELECT IdReservas, IdUsuario, fecha_reserva
	FROM dbo.Reservas
	WHERE IdReservas = @IdReservas;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerReservasdeUser]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerReservasdeUser]
	@IdUsuario bigint
AS
BEGIN
	SELECT IdReservas, fecha_reserva
	FROM dbo.Reservas
	WHERE IdUsuario = @IdUsuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerTodasLasReservas]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ObtenerTodasLasReservas]
AS
BEGIN
    SELECT r.IdReservas, r.IdUsuario, r.fecha_reserva, u.nombre AS NombreUsuario
    FROM dbo.Reservas r
    INNER JOIN dbo.Usuario u ON r.IdUsuario = u.IdUsuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerTodosLosUsuarios]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerTodosLosUsuarios]
AS
BEGIN
	SELECT IdUsuario, identificacion, nombre, usuario, correo, contrasenna, ConRol, estado
	FROM dbo.Usuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuarioPorId]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerUsuarioPorId]
	@IdUsuario bigint
AS
BEGIN
	SELECT IdUsuario, identificacion, nombre, usuario, correo, contrasenna, ConRol, estado
	FROM dbo.Usuario
	WHERE IdUsuario = @IdUsuario;
END;


GO
/****** Object:  StoredProcedure [dbo].[PagarCarrito]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PagarCarrito]
	@IdUsuario AS BIGINT
AS
BEGIN
	BEGIN TRY	

		BEGIN TRANSACTION

		IF(	SELECT TOP 1  C.Cantidad
			FROM TCarrito	C
			INNER	JOIN TProducto P ON C.IdProducto = P.IdProducto
			WHERE	IdUsuario = @IdUsuario ) < 0
		BEGIN

			DELETE	C
			FROM	TCarrito C
			INNER	JOIN TProducto P ON C.IdProducto = P.IdProducto
			WHERE	IdUsuario = @IdUsuario

			
		END
		ELSE
		BEGIN

			DECLARE @TotalPago DECIMAL(18,2)
			DECLARE @CodigoFactura BIGINT

			SELECT	@TotalPago = SUM(P.Precio * C.Cantidad) + (SUM(P.Precio * C.Cantidad) * 0.13)
			FROM	TCarrito	C
			INNER	JOIN TProducto P ON C.IdProducto = P.IdProducto
			WHERE	IdUsuario = @IdUsuario

			INSERT	INTO dbo.TEncabezado(IdUsuario,FechaPago,TotalPago)
			VALUES	(@IdUsuario,GETDATE(),@TotalPago)

			SET @CodigoFactura = @@IDENTITY

			INSERT	INTO dbo.TDetalle(IdFactura,IdProducto,Cantidad,Impuesto,Precio)
			SELECT	@CodigoFactura, C.IdProducto, C.Cantidad, (P.Precio * 0.13), P.Precio 
			FROM	TCarrito	C
			INNER	JOIN TProducto P ON C.IdProducto = P.IdProducto
			WHERE	IdUsuario = @IdUsuario


			DELETE FROM TCarrito
			WHERE IdUsuario = @IdUsuario

		END
		COMMIT TRANSACTION
		END TRY
	BEGIN CATCH
		
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarCarrito]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarCarrito]
	@IdUsuario	bigint,
    @IdProducto	bigint,
    @Cantidad	int
AS
BEGIN
	
	IF EXISTS(SELECT 1 FROM TCarrito WHERE IdUsuario = @IdUsuario AND IdProducto = @IdProducto )
	BEGIN
		
		UPDATE dbo.TCarrito
		   SET Cantidad = @Cantidad
		 WHERE IdUsuario = @IdUsuario AND IdProducto = @IdProducto

	END
	ELSE
	BEGIN

		INSERT INTO dbo.TCarrito(IdUsuario,IdProducto,Cantidad,Fecha)
		VALUES (@IdUsuario,@IdProducto,@Cantidad,GETDATE())

	END
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarComentario]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarComentario]
	@IdUsuario bigint,
	@comentario varchar(500)
AS
BEGIN
	INSERT INTO dbo.Comentarios (IdUsuario,comentario)
	VALUES (@IdUsuario,@comentario);
END;
GO
/****** Object:  StoredProcedure [dbo].[RegistrarProducto]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarProducto]
	@nombre varchar(200),
	@descripcion varchar(500),
	@precio decimal(10, 2),
	@imagen varchar(500)
AS
BEGIN
  
	INSERT INTO dbo.TProducto (nombre, descripcion, precio, Imagen)
	VALUES (@nombre, @descripcion, @precio, @imagen);

END;
GO
/****** Object:  StoredProcedure [dbo].[RegistrarUsuario]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarUsuario]
	@identificacion varchar(20),
	@nombre varchar(200),
	@usuario varchar(25),
	@correo varchar(50),
	@contrasenna varchar(25)
AS
BEGIN

	INSERT INTO dbo.Usuario (identificacion, nombre, usuario, correo, contrasenna, ConRol, estado)
	VALUES (@identificacion, @nombre, @usuario, @correo, @contrasenna, 3, 1);

END;
GO
/****** Object:  StoredProcedure [dbo].[VerComentarios]    Script Date: 14/12/2023 11:51:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerComentarios]
	
AS
BEGIN
	SELECT *
	FROM dbo.Comentarios
END;
GO
USE [master]
GO
ALTER DATABASE [ProyectoPrograAvanzadaWebF] SET  READ_WRITE 
GO
