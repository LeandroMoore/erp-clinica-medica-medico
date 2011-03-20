/****** Object:  Database [erp-medico]    Script Date: 03/19/2011 16:41:10 ******/
USE [erp-medico]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 03/19/2011 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Paciente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoSangue] [char](5) NULL,
	[HistoricoFamiliar] [nvarchar](4000) NULL,
	[HistoricoPessoal] [nvarchar](4000) NULL,
	[Observacoes] [nvarchar](4000) NULL,
	[Codigo] [nvarchar](100) NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Medico]    Script Date: 03/19/2011 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medico](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](220) NULL,
	[Codigo] [nvarchar](100) NULL,
 CONSTRAINT [PK_Medico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Atendimento]    Script Date: 03/19/2011 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atendimento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PacienteId] [int] NOT NULL,
	[Peso] [float] NULL,
	[Altura] [float] NULL,
	[Descricao] [nvarchar](500) NULL,
	[Horario] [datetime] NOT NULL,
	[MedicoId] [int] NULL,
	[Observacoes] [nvarchar](4000) NULL,
	[DescricaoDoencaAtual] [nvarchar](500) NULL,
	[QueixaPrincipal] [nvarchar](500) NULL,
 CONSTRAINT [PK_Atendimento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tratamento]    Script Date: 03/19/2011 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tratamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](1000) NULL,
	[Observacoes] [nvarchar](4000) NULL,
	[AtendimentoId] [int] NOT NULL,
 CONSTRAINT [PK_Tratamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescricao]    Script Date: 03/19/2011 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescricao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](1000) NULL,
	[Observacoes] [nvarchar](4000) NULL,
	[AtendimentoId] [int] NOT NULL,
 CONSTRAINT [PK_Prescricao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exame]    Script Date: 03/19/2011 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exame](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](1000) NULL,
	[Observacoes] [nvarchar](4000) NULL,
	[AtendimentoId] [int] NOT NULL,
 CONSTRAINT [PK_Exame] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diagnostico]    Script Date: 03/19/2011 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diagnostico](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](1000) NULL,
	[Observacoes] [nvarchar](4000) NULL,
	[AtendimentoId] [int] NOT NULL,
 CONSTRAINT [PK_Diagnostico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Atendimento_Medico]    Script Date: 03/19/2011 16:41:12 ******/
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK_Atendimento_Medico] FOREIGN KEY([MedicoId])
REFERENCES [dbo].[Medico] ([Id])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK_Atendimento_Medico]
GO
/****** Object:  ForeignKey [FK_Atendimento_Paciente]    Script Date: 03/19/2011 16:41:12 ******/
ALTER TABLE [dbo].[Atendimento]  WITH CHECK ADD  CONSTRAINT [FK_Atendimento_Paciente] FOREIGN KEY([PacienteId])
REFERENCES [dbo].[Paciente] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Atendimento] CHECK CONSTRAINT [FK_Atendimento_Paciente]
GO
/****** Object:  ForeignKey [FK_Tratamento_Atendimento]    Script Date: 03/19/2011 16:41:12 ******/
ALTER TABLE [dbo].[Tratamento]  WITH CHECK ADD  CONSTRAINT [FK_Tratamento_Atendimento] FOREIGN KEY([AtendimentoId])
REFERENCES [dbo].[Atendimento] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tratamento] CHECK CONSTRAINT [FK_Tratamento_Atendimento]
GO
/****** Object:  ForeignKey [FK_Prescricao_Atendimento]    Script Date: 03/19/2011 16:41:12 ******/
ALTER TABLE [dbo].[Prescricao]  WITH CHECK ADD  CONSTRAINT [FK_Prescricao_Atendimento] FOREIGN KEY([AtendimentoId])
REFERENCES [dbo].[Atendimento] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prescricao] CHECK CONSTRAINT [FK_Prescricao_Atendimento]
GO
/****** Object:  ForeignKey [FK_Exame_Atendimento]    Script Date: 03/19/2011 16:41:12 ******/
ALTER TABLE [dbo].[Exame]  WITH CHECK ADD  CONSTRAINT [FK_Exame_Atendimento] FOREIGN KEY([AtendimentoId])
REFERENCES [dbo].[Atendimento] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Exame] CHECK CONSTRAINT [FK_Exame_Atendimento]
GO
/****** Object:  ForeignKey [FK_Diagnostico_Atendimento]    Script Date: 03/19/2011 16:41:12 ******/
ALTER TABLE [dbo].[Diagnostico]  WITH CHECK ADD  CONSTRAINT [FK_Diagnostico_Atendimento] FOREIGN KEY([AtendimentoId])
REFERENCES [dbo].[Atendimento] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Diagnostico] CHECK CONSTRAINT [FK_Diagnostico_Atendimento]
GO
