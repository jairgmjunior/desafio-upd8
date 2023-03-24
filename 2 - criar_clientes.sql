USE [DB_Upt8]
GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 24/03/2023 09:12:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[CPF] [nvarchar](11) NOT NULL,
	[DataNascimento] [datetime2](7) NOT NULL,
	[Sexo] [nvarchar](1) NOT NULL,
	[DataCriacao] [datetime2](7) NOT NULL,
	[DataAtualizacao] [datetime2](7) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


