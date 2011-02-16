
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/16/2011 16:40:04
-- Generated from EDMX file: D:\Docs\Poli\2011\LabSoft\erp-clinica-medica-medico\ERP.Medico\ERP.Medico.Model\ERPMedicoModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [erp-medico-debug];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AnamnesePaciente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Anamneses] DROP CONSTRAINT [FK_AnamnesePaciente];
GO
IF OBJECT_ID(N'[dbo].[FK_AnamneseTipoSangue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Anamneses] DROP CONSTRAINT [FK_AnamneseTipoSangue];
GO
IF OBJECT_ID(N'[dbo].[FK_AtendimentoTipoAtendimento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Atendimentos] DROP CONSTRAINT [FK_AtendimentoTipoAtendimento];
GO
IF OBJECT_ID(N'[dbo].[FK_AtendimentoDiagnostico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Diagnosticos] DROP CONSTRAINT [FK_AtendimentoDiagnostico];
GO
IF OBJECT_ID(N'[dbo].[FK_AtendimentoTratamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tratamentos] DROP CONSTRAINT [FK_AtendimentoTratamento];
GO
IF OBJECT_ID(N'[dbo].[FK_AtendimentoPaciente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Atendimentos] DROP CONSTRAINT [FK_AtendimentoPaciente];
GO
IF OBJECT_ID(N'[dbo].[FK_AtendimentoMedico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Atendimentos] DROP CONSTRAINT [FK_AtendimentoMedico];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Pacientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pacientes];
GO
IF OBJECT_ID(N'[dbo].[Medicos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Medicos];
GO
IF OBJECT_ID(N'[dbo].[Anamneses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Anamneses];
GO
IF OBJECT_ID(N'[dbo].[Atendimentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Atendimentos];
GO
IF OBJECT_ID(N'[dbo].[Tratamentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tratamentos];
GO
IF OBJECT_ID(N'[dbo].[Diagnosticos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Diagnosticos];
GO
IF OBJECT_ID(N'[dbo].[TiposSangue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TiposSangue];
GO
IF OBJECT_ID(N'[dbo].[TiposAtendimento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TiposAtendimento];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Pacientes'
CREATE TABLE [dbo].[Pacientes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Altura] real  NOT NULL,
    [Peso] real  NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Medicos'
CREATE TABLE [dbo].[Medicos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Anamneses'
CREATE TABLE [dbo].[Anamneses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DescricaoDoencaAtual] nvarchar(max)  NOT NULL,
    [DescricaoMedicaPregressa] nvarchar(max)  NOT NULL,
    [HistoricoFamiliar] nvarchar(max)  NOT NULL,
    [HistoricoPessoalSocial] nvarchar(max)  NOT NULL,
    [Observacoes] nvarchar(max)  NOT NULL,
    [QueixaPrincipal] nvarchar(max)  NOT NULL,
    [Paciente_Id] int  NOT NULL,
    [TipoSangue_Id] int  NOT NULL
);
GO

-- Creating table 'Atendimentos'
CREATE TABLE [dbo].[Atendimentos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [Emergencia] bit  NOT NULL,
    [Horario] datetime  NOT NULL,
    [TipoAtendimento_Id] int  NOT NULL,
    [Paciente_Id] int  NOT NULL,
    [Medico_Id] int  NOT NULL
);
GO

-- Creating table 'Tratamentos'
CREATE TABLE [dbo].[Tratamentos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [Observacoes] nvarchar(max)  NOT NULL,
    [AtendimentoId] int  NOT NULL
);
GO

-- Creating table 'Diagnosticos'
CREATE TABLE [dbo].[Diagnosticos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [Observacoes] nvarchar(max)  NOT NULL,
    [AtendimentoId] int  NOT NULL
);
GO

-- Creating table 'TiposSangue'
CREATE TABLE [dbo].[TiposSangue] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TiposAtendimento'
CREATE TABLE [dbo].[TiposAtendimento] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Pacientes'
ALTER TABLE [dbo].[Pacientes]
ADD CONSTRAINT [PK_Pacientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Medicos'
ALTER TABLE [dbo].[Medicos]
ADD CONSTRAINT [PK_Medicos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Anamneses'
ALTER TABLE [dbo].[Anamneses]
ADD CONSTRAINT [PK_Anamneses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Atendimentos'
ALTER TABLE [dbo].[Atendimentos]
ADD CONSTRAINT [PK_Atendimentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tratamentos'
ALTER TABLE [dbo].[Tratamentos]
ADD CONSTRAINT [PK_Tratamentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Diagnosticos'
ALTER TABLE [dbo].[Diagnosticos]
ADD CONSTRAINT [PK_Diagnosticos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TiposSangue'
ALTER TABLE [dbo].[TiposSangue]
ADD CONSTRAINT [PK_TiposSangue]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TiposAtendimento'
ALTER TABLE [dbo].[TiposAtendimento]
ADD CONSTRAINT [PK_TiposAtendimento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Paciente_Id] in table 'Anamneses'
ALTER TABLE [dbo].[Anamneses]
ADD CONSTRAINT [FK_AnamnesePaciente]
    FOREIGN KEY ([Paciente_Id])
    REFERENCES [dbo].[Pacientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AnamnesePaciente'
CREATE INDEX [IX_FK_AnamnesePaciente]
ON [dbo].[Anamneses]
    ([Paciente_Id]);
GO

-- Creating foreign key on [TipoSangue_Id] in table 'Anamneses'
ALTER TABLE [dbo].[Anamneses]
ADD CONSTRAINT [FK_AnamneseTipoSangue]
    FOREIGN KEY ([TipoSangue_Id])
    REFERENCES [dbo].[TiposSangue]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AnamneseTipoSangue'
CREATE INDEX [IX_FK_AnamneseTipoSangue]
ON [dbo].[Anamneses]
    ([TipoSangue_Id]);
GO

-- Creating foreign key on [TipoAtendimento_Id] in table 'Atendimentos'
ALTER TABLE [dbo].[Atendimentos]
ADD CONSTRAINT [FK_AtendimentoTipoAtendimento]
    FOREIGN KEY ([TipoAtendimento_Id])
    REFERENCES [dbo].[TiposAtendimento]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AtendimentoTipoAtendimento'
CREATE INDEX [IX_FK_AtendimentoTipoAtendimento]
ON [dbo].[Atendimentos]
    ([TipoAtendimento_Id]);
GO

-- Creating foreign key on [AtendimentoId] in table 'Diagnosticos'
ALTER TABLE [dbo].[Diagnosticos]
ADD CONSTRAINT [FK_AtendimentoDiagnostico]
    FOREIGN KEY ([AtendimentoId])
    REFERENCES [dbo].[Atendimentos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AtendimentoDiagnostico'
CREATE INDEX [IX_FK_AtendimentoDiagnostico]
ON [dbo].[Diagnosticos]
    ([AtendimentoId]);
GO

-- Creating foreign key on [AtendimentoId] in table 'Tratamentos'
ALTER TABLE [dbo].[Tratamentos]
ADD CONSTRAINT [FK_AtendimentoTratamento]
    FOREIGN KEY ([AtendimentoId])
    REFERENCES [dbo].[Atendimentos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AtendimentoTratamento'
CREATE INDEX [IX_FK_AtendimentoTratamento]
ON [dbo].[Tratamentos]
    ([AtendimentoId]);
GO

-- Creating foreign key on [Paciente_Id] in table 'Atendimentos'
ALTER TABLE [dbo].[Atendimentos]
ADD CONSTRAINT [FK_AtendimentoPaciente]
    FOREIGN KEY ([Paciente_Id])
    REFERENCES [dbo].[Pacientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AtendimentoPaciente'
CREATE INDEX [IX_FK_AtendimentoPaciente]
ON [dbo].[Atendimentos]
    ([Paciente_Id]);
GO

-- Creating foreign key on [Medico_Id] in table 'Atendimentos'
ALTER TABLE [dbo].[Atendimentos]
ADD CONSTRAINT [FK_AtendimentoMedico]
    FOREIGN KEY ([Medico_Id])
    REFERENCES [dbo].[Medicos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AtendimentoMedico'
CREATE INDEX [IX_FK_AtendimentoMedico]
ON [dbo].[Atendimentos]
    ([Medico_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------