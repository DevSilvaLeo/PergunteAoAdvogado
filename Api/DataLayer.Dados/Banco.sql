USE [master]
GO
/****** Object:  User [##MS_PolicyEventProcessingLogin##]    Script Date: 01/05/2021 14:05:57 ******/
CREATE USER [##MS_PolicyEventProcessingLogin##] FOR LOGIN [##MS_PolicyEventProcessingLogin##] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [##MS_AgentSigningCertificate##]    Script Date: 01/05/2021 14:05:57 ******/
CREATE USER [##MS_AgentSigningCertificate##] FOR LOGIN [##MS_AgentSigningCertificate##]
GO
/****** Object:  Table [dbo].[Advogado]    Script Date: 01/05/2021 14:05:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advogado](
	[IdAdvogado] [int] NOT NULL,
	[Nome] [nvarchar](150) NOT NULL,
	[InscricaoOAB] [nvarchar](12) NOT NULL,
	[CodSegurancaOAB] [nvarchar](20) NOT NULL,
	[ExpedicaoOAB] [nvarchar](12) NOT NULL,
	[Foto] [nvarchar](255) NOT NULL,
	[DataCadastro] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 01/05/2021 14:05:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] NOT NULL,
	[Nome] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Telefone] [nvarchar](16) NOT NULL,
	[DataCadastro] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Demanda]    Script Date: 01/05/2021 14:05:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demanda](
	[IdDemanda] [int] NOT NULL,
	[Titulo] [nvarchar](100) NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[Anexo] [nvarchar](150) NOT NULL,
	[DataCadastro] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 01/05/2021 14:05:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[IdPerfil] [int] NOT NULL,
	[Biografia] [nvarchar](500) NOT NULL,
	[Especializacao] [nvarchar](150) NOT NULL,
	[CriadoEm] [date] NOT NULL,
	[ModificadoEm] [date] NULL
) ON [PRIMARY]
GO
