CREATE DATABASE [Db_GSV]
GO
USE [Db_GSV]
GO
/****** Object:  Table [dbo].[Tb_Login]    Script Date: 07/12/2020 01:13:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Login](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](100) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Tb_Login] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
BEGIN
INSERT INTO [Tb_Login] VALUES ('admin','123')
END
GO
/****** Object:  Table [dbo].[Tb_Pedidos]    Script Date: 07/12/2020 01:13:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Pedidos](
	[PedidoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](500) NOT NULL,
	[Email] [varchar](500) NOT NULL,
	[TipoAssinatura] [varchar](50) NOT NULL,
	[dataSolicitacao] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Tb_Pedidos] PRIMARY KEY CLUSTERED 
(
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[prAtualizarPedido]    Script Date: 07/12/2020 01:13:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[prAtualizarPedido]
   @PedidoId int,
   @Nome varchar(500),    
    @Email varchar(500),    
    @TipoAssinatura varchar(50),  
    @dataSolicitacao datetime,  
    @Status bit 
	AS
	BEGIN

UPDATE [dbo].[Tb_Pedidos]
           SET [Nome] =@Nome
           ,[Email]= @Email
           ,[TipoAssinatura] = @TipoAssinatura
           ,[dataSolicitacao]= @dataSolicitacao
           ,[Status]= @Status
       where PedidoId = @PedidoId
	END


GO
/****** Object:  StoredProcedure [dbo].[prNovoPedido]    Script Date: 07/12/2020 01:13:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[prNovoPedido]
   @Nome varchar(500),    
    @Email varchar(500),    
    @TipoAssinatura varchar(50),  
    @dataSolicitacao datetime,  
    @Status bit 
	AS
	BEGIN

INSERT INTO [dbo].[Tb_Pedidos]
           ([Nome]
           ,[Email]
           ,[TipoAssinatura]
           ,[dataSolicitacao]
           ,[Status])
     VALUES
           (@Nome,@Email,@TipoAssinatura,@dataSolicitacao,@Status)

		SELECT SCOPE_IDENTITY() 
END


GO
