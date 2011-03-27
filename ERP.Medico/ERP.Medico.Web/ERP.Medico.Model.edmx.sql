
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/27/2011 08:59:13
-- Generated from EDMX file: D:\Docs\Poli\2011\LabSoft\erp-clinica-medica-medico\ERP.Medico\ERP.Medico.Web\ERP.Medico.Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [erp-medico];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Atendimento_Medico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Atendimento] DROP CONSTRAINT [FK_Atendimento_Medico];
GO
IF OBJECT_ID(N'[dbo].[FK_Atendimento_Paciente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Atendimento] DROP CONSTRAINT [FK_Atendimento_Paciente];
GO
IF OBJECT_ID(N'[dbo].[FK_Diagnostico_Atendimento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Diagnostico] DROP CONSTRAINT [FK_Diagnostico_Atendimento];
GO
IF OBJECT_ID(N'[dbo].[FK_Exame_Atendimento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exame] DROP CONSTRAINT [FK_Exame_Atendimento];
GO
IF OBJECT_ID(N'[dbo].[FK_Prescricao_Atendimento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prescricao] DROP CONSTRAINT [FK_Prescricao_Atendimento];
GO
IF OBJECT_ID(N'[dbo].[FK_Tratamento_Atendimento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tratamento] DROP CONSTRAINT [FK_Tratamento_Atendimento];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Atendimento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Atendimento];
GO
IF OBJECT_ID(N'[dbo].[Diagnostico]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Diagnostico];
GO
IF OBJECT_ID(N'[dbo].[Exame]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Exame];
GO
IF OBJECT_ID(N'[dbo].[Medico]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Medico];
GO
IF OBJECT_ID(N'[dbo].[Paciente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paciente];
GO
IF OBJECT_ID(N'[dbo].[Prescricao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prescricao];
GO
IF OBJECT_ID(N'[dbo].[Tratamento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tratamento];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Atendimento'
CREATE TABLE [dbo].[Atendimento] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PacienteId] int  NOT NULL,
    [Peso] float  NULL,
    [Altura] float  NULL,
    [Descricao] nvarchar(500)  NULL,
    [Horario] datetime  NOT NULL,
    [MedicoId] int  NULL,
    [Observacoes] nvarchar(4000)  NULL,
    [DescricaoDoencaAtual] nvarchar(500)  NULL,
    [QueixaPrincipal] nvarchar(500)  NULL
);
GO

-- Creating table 'Diagnostico'
CREATE TABLE [dbo].[Diagnostico] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(1000)  NULL,
    [Observacoes] nvarchar(4000)  NULL,
    [AtendimentoId] int  NOT NULL,
    [RealizadoNaClinica] bit  NULL,
    [Codigo] nvarchar(100)  NULL
);
GO

-- Creating table 'Exame'
CREATE TABLE [dbo].[Exame] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(1000)  NULL,
    [Observacoes] nvarchar(4000)  NULL,
    [AtendimentoId] int  NOT NULL,
    [RealizadoNaClinica] bit  NULL,
    [Codigo] nvarchar(100)  NULL
);
GO

-- Creating table 'Medico'
CREATE TABLE [dbo].[Medico] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(220)  NULL,
    [Codigo] nvarchar(100)  NULL
);
GO

-- Creating table 'Paciente'
CREATE TABLE [dbo].[Paciente] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TipoSangue] char(5)  NULL,
    [HistoricoFamiliar] nvarchar(4000)  NULL,
    [HistoricoPessoal] nvarchar(4000)  NULL,
    [Observacoes] nvarchar(4000)  NULL,
    [Codigo] nvarchar(100)  NULL,
    [Nome] nvarchar(220)  NULL
);
GO

-- Creating table 'Prescricao'
CREATE TABLE [dbo].[Prescricao] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(1000)  NULL,
    [Observacoes] nvarchar(4000)  NULL,
    [AtendimentoId] int  NOT NULL,
    [RealizadoNaClinica] bit  NULL,
    [Codigo] nvarchar(100)  NULL
);
GO

-- Creating table 'Tratamento'
CREATE TABLE [dbo].[Tratamento] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(1000)  NULL,
    [Observacoes] nvarchar(4000)  NULL,
    [AtendimentoId] int  NOT NULL,
    [RealizadoNaClinica] bit  NULL,
    [Codigo] nvarchar(100)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Atendimento'
ALTER TABLE [dbo].[Atendimento]
ADD CONSTRAINT [PK_Atendimento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Diagnostico'
ALTER TABLE [dbo].[Diagnostico]
ADD CONSTRAINT [PK_Diagnostico]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Exame'
ALTER TABLE [dbo].[Exame]
ADD CONSTRAINT [PK_Exame]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Medico'
ALTER TABLE [dbo].[Medico]
ADD CONSTRAINT [PK_Medico]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Paciente'
ALTER TABLE [dbo].[Paciente]
ADD CONSTRAINT [PK_Paciente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prescricao'
ALTER TABLE [dbo].[Prescricao]
ADD CONSTRAINT [PK_Prescricao]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tratamento'
ALTER TABLE [dbo].[Tratamento]
ADD CONSTRAINT [PK_Tratamento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MedicoId] in table 'Atendimento'
ALTER TABLE [dbo].[Atendimento]
ADD CONSTRAINT [FK_Atendimento_Medico]
    FOREIGN KEY ([MedicoId])
    REFERENCES [dbo].[Medico]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Atendimento_Medico'
CREATE INDEX [IX_FK_Atendimento_Medico]
ON [dbo].[Atendimento]
    ([MedicoId]);
GO

-- Creating foreign key on [PacienteId] in table 'Atendimento'
ALTER TABLE [dbo].[Atendimento]
ADD CONSTRAINT [FK_Atendimento_Paciente]
    FOREIGN KEY ([PacienteId])
    REFERENCES [dbo].[Paciente]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Atendimento_Paciente'
CREATE INDEX [IX_FK_Atendimento_Paciente]
ON [dbo].[Atendimento]
    ([PacienteId]);
GO

-- Creating foreign key on [AtendimentoId] in table 'Diagnostico'
ALTER TABLE [dbo].[Diagnostico]
ADD CONSTRAINT [FK_Diagnostico_Atendimento]
    FOREIGN KEY ([AtendimentoId])
    REFERENCES [dbo].[Atendimento]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Diagnostico_Atendimento'
CREATE INDEX [IX_FK_Diagnostico_Atendimento]
ON [dbo].[Diagnostico]
    ([AtendimentoId]);
GO

-- Creating foreign key on [AtendimentoId] in table 'Exame'
ALTER TABLE [dbo].[Exame]
ADD CONSTRAINT [FK_Exame_Atendimento]
    FOREIGN KEY ([AtendimentoId])
    REFERENCES [dbo].[Atendimento]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Exame_Atendimento'
CREATE INDEX [IX_FK_Exame_Atendimento]
ON [dbo].[Exame]
    ([AtendimentoId]);
GO

-- Creating foreign key on [AtendimentoId] in table 'Prescricao'
ALTER TABLE [dbo].[Prescricao]
ADD CONSTRAINT [FK_Prescricao_Atendimento]
    FOREIGN KEY ([AtendimentoId])
    REFERENCES [dbo].[Atendimento]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Prescricao_Atendimento'
CREATE INDEX [IX_FK_Prescricao_Atendimento]
ON [dbo].[Prescricao]
    ([AtendimentoId]);
GO

-- Creating foreign key on [AtendimentoId] in table 'Tratamento'
ALTER TABLE [dbo].[Tratamento]
ADD CONSTRAINT [FK_Tratamento_Atendimento]
    FOREIGN KEY ([AtendimentoId])
    REFERENCES [dbo].[Atendimento]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tratamento_Atendimento'
CREATE INDEX [IX_FK_Tratamento_Atendimento]
ON [dbo].[Tratamento]
    ([AtendimentoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------