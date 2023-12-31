USE [DBData]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 22/11/2023 12:47:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[categoria] [varchar](50) NULL,
	[nombre] [varchar](50) NOT NULL,
	[unidades] [smallint] NULL,
	[fechaingreso] [smalldatetime] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_productoconsulta]    Script Date: 22/11/2023 12:47:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_productoconsulta]
@nombre varchar(20)
as

select * from productos where nombre=@nombre
GO
/****** Object:  StoredProcedure [dbo].[sp_productoconsultaxID]    Script Date: 22/11/2023 12:47:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_productoconsultaxID]
@id varchar(20)
as

select * from productos where id=@id
GO
/****** Object:  StoredProcedure [dbo].[sp_productodelete]    Script Date: 22/11/2023 12:47:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[sp_productodelete]
    @id smallint
	as
	begin
	   delete Productos where id=@id
	end


GO
/****** Object:  StoredProcedure [dbo].[sp_productoinsert]    Script Date: 22/11/2023 12:47:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_productoinsert] 
	@categoria VARCHAR(50),
	@nombre VARCHAR(50),
	@unidades SMALLINT,
	@fechaingreso DATE
	as
	begin
	   INSERT INTO Productos(categoria,nombre,unidades,fechaingreso) values (@categoria,@nombre,@unidades,@fechaingreso)


	end

GO
/****** Object:  StoredProcedure [dbo].[sp_productoupdate]    Script Date: 22/11/2023 12:47:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE  [dbo].[sp_productoupdate]
    @id smallint,
	@categoria varchar(20),
	@nombre varchar(20),
	@fechaingreso Date
	as
	begin
	   update Productos set categoria=@categoria,nombre=@nombre,fechaingreso=@fechaingreso where id=@id
	end


GO
