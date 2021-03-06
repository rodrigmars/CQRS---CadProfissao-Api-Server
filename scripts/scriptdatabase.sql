USE [Labdesenv]
GO
ALTER TABLE [dbo].[Profissional] DROP CONSTRAINT [FK_Profissional_TipoProfissao_TipoProfissaoId]
GO
/****** Object:  Table [dbo].[TipoProfissao]    Script Date: 8/8/2018 1:43:24 AM ******/
DROP TABLE [dbo].[TipoProfissao]
GO
/****** Object:  Table [dbo].[Profissional]    Script Date: 8/8/2018 1:43:24 AM ******/
DROP TABLE [dbo].[Profissional]
GO
/****** Object:  Table [dbo].[Profissional]    Script Date: 8/8/2018 1:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profissional](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](150) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Idade] [int] NOT NULL,
	[Desempregado] [bit] NOT NULL,
	[TipoProfissaoId] [int] NOT NULL,
 CONSTRAINT [PK_Profissional_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProfissao]    Script Date: 8/8/2018 1:43:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProfissao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](150) NOT NULL,
 CONSTRAINT [PK_TipoProfissao_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Profissional] ([Id], [Nome], [Email], [Idade], [Desempregado], [TipoProfissaoId]) VALUES (N'f3b3784e-1b97-4cfd-b755-2a3acf011eb7', N'Eduardo Lorenzo Calebe da Cunha', N'eeduardolorenzocalebedacunha@cotamtambores.com.br', 20, 1, 5)
INSERT [dbo].[Profissional] ([Id], [Nome], [Email], [Idade], [Desempregado], [TipoProfissaoId]) VALUES (N'98aa2712-cc0c-4b59-adda-38ab70df0fa9', N'Yuri Ricardo Bruno dos Santos', N'yuriricardobrunodossantos.yuriricardobrunodossantos@nhrtaxiaereo.com', 25, 1, 2)
INSERT [dbo].[Profissional] ([Id], [Nome], [Email], [Idade], [Desempregado], [TipoProfissaoId]) VALUES (N'5d411751-4f47-415d-9ce6-4650f65ea91b', N'Sophia Stefany Porto', N'sophiastefanyporto-90@ovale.com.br', 34, 0, 4)
INSERT [dbo].[Profissional] ([Id], [Nome], [Email], [Idade], [Desempregado], [TipoProfissaoId]) VALUES (N'1a0bde05-dbfe-4590-9c2a-76ffeb3b1d17', N'Melissa Yasmin Juliana Corte Real', N'melissayasminjulianacortereal_@milimoveis.com.br', 28, 0, 7)
INSERT [dbo].[Profissional] ([Id], [Nome], [Email], [Idade], [Desempregado], [TipoProfissaoId]) VALUES (N'776c94a0-3a46-41d1-a210-8e8dc55223dc', N'Kevin Edson Bernardes', N'kkevinedsonbernardes@yahoo.com', 25, 0, 4)
INSERT [dbo].[Profissional] ([Id], [Nome], [Email], [Idade], [Desempregado], [TipoProfissaoId]) VALUES (N'6e6acf64-4d1c-4080-ae69-dadbd95eef58', N'Arthur Carlos Monteiro', N'arthurcarlosmonteiro.arthurcarlosmonteiro@iega.com.br', 23, 1, 2)
SET IDENTITY_INSERT [dbo].[TipoProfissao] ON 

INSERT [dbo].[TipoProfissao] ([Id], [Descricao]) VALUES (1, N'Analista de Business Intelligence')
INSERT [dbo].[TipoProfissao] ([Id], [Descricao]) VALUES (2, N'Cientista de dados')
INSERT [dbo].[TipoProfissao] ([Id], [Descricao]) VALUES (3, N'Desenvolvedor de base de dados')
INSERT [dbo].[TipoProfissao] ([Id], [Descricao]) VALUES (4, N'Engenheiro de Software')
INSERT [dbo].[TipoProfissao] ([Id], [Descricao]) VALUES (5, N'Scrum Master')
INSERT [dbo].[TipoProfissao] ([Id], [Descricao]) VALUES (6, N'Arquiteto de Soluções')
INSERT [dbo].[TipoProfissao] ([Id], [Descricao]) VALUES (7, N'Gerente de expansão de T.I')
SET IDENTITY_INSERT [dbo].[TipoProfissao] OFF
ALTER TABLE [dbo].[Profissional]  WITH CHECK ADD  CONSTRAINT [FK_Profissional_TipoProfissao_TipoProfissaoId] FOREIGN KEY([TipoProfissaoId])
REFERENCES [dbo].[TipoProfissao] ([Id])
GO
ALTER TABLE [dbo].[Profissional] CHECK CONSTRAINT [FK_Profissional_TipoProfissao_TipoProfissaoId]
GO
