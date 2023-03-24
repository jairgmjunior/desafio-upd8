USE [DB_Upt8]
GO

/****** Object:  Table [dbo].[Enderecos]    Script Date: 24/03/2023 09:13:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Enderecos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Complemento] [nvarchar](200) NOT NULL,
	[CidadeId] [int] NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_Enderecos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Enderecos]  WITH CHECK ADD  CONSTRAINT [FK_Enderecos_Cidades_CidadeId] FOREIGN KEY([CidadeId])
REFERENCES [dbo].[Cidades] ([Id])
GO

ALTER TABLE [dbo].[Enderecos] CHECK CONSTRAINT [FK_Enderecos_Cidades_CidadeId]
GO

ALTER TABLE [dbo].[Enderecos]  WITH CHECK ADD  CONSTRAINT [FK_Enderecos_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Enderecos] CHECK CONSTRAINT [FK_Enderecos_Clientes_ClienteId]
GO


