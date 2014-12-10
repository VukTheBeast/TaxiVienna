
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/10/2014 16:24:20
-- Generated from EDMX file: C:\Users\Gavra\Documents\GitHub\TaxiVienna\TaxiWebSite\Models\taxiVienna.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_9B8AB0_taxi];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Oblasti_Gradovi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Oblasti] DROP CONSTRAINT [FK_Oblasti_Gradovi];
GO
IF OBJECT_ID(N'[dbo].[FK_Ulice_Oblasti]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ulice] DROP CONSTRAINT [FK_Ulice_Oblasti];
GO
IF OBJECT_ID(N'[dbo].[FK_UliceKorisnici]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Korisnici] DROP CONSTRAINT [FK_UliceKorisnici];
GO
IF OBJECT_ID(N'[dbo].[FK_KorisniciRezervacije]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rezervacije] DROP CONSTRAINT [FK_KorisniciRezervacije];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Gradovi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gradovi];
GO
IF OBJECT_ID(N'[dbo].[Oblasti]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Oblasti];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Ulice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ulice];
GO
IF OBJECT_ID(N'[dbo].[Korisnici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Korisnici];
GO
IF OBJECT_ID(N'[dbo].[Rezervacije]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rezervacije];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Gradovi'
CREATE TABLE [dbo].[Gradovi] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Oblasti'
CREATE TABLE [dbo].[Oblasti] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Id_Grada] int  NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Zona1] nvarchar(3)  NULL,
    [Zona2] nvarchar(3)  NULL,
    [Zona3] nvarchar(3)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Ulice'
CREATE TABLE [dbo].[Ulice] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Id_Oblasti] int  NOT NULL,
    [Name] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Korisnici'
CREATE TABLE [dbo].[Korisnici] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ID_Grada] int  NOT NULL,
    [UliceId] int  NOT NULL,
    [Telefon] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [UkupnoVoznje] int  NOT NULL,
    [BrojVoznje] int  NOT NULL
);
GO

-- Creating table 'Rezervacije'
CREATE TABLE [dbo].[Rezervacije] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [KorisniciID] int  NOT NULL,
    [DatumVreme] datetime  NOT NULL,
    [IsConfirmed] bit  NULL,
    [ConfrimDateTime] datetime  NULL,
    [FromToAirport] nvarchar(max)  NOT NULL,
    [CarType] nvarchar(max)  NULL,
    [Suitcases] int  NULL,
    [Payment] nvarchar(max)  NOT NULL,
    [Price] float  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Gradovi'
ALTER TABLE [dbo].[Gradovi]
ADD CONSTRAINT [PK_Gradovi]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Oblasti'
ALTER TABLE [dbo].[Oblasti]
ADD CONSTRAINT [PK_Oblasti]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'Ulice'
ALTER TABLE [dbo].[Ulice]
ADD CONSTRAINT [PK_Ulice]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'Korisnici'
ALTER TABLE [dbo].[Korisnici]
ADD CONSTRAINT [PK_Korisnici]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Rezervacije'
ALTER TABLE [dbo].[Rezervacije]
ADD CONSTRAINT [PK_Rezervacije]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Id_Grada] in table 'Oblasti'
ALTER TABLE [dbo].[Oblasti]
ADD CONSTRAINT [FK_Oblasti_Gradovi]
    FOREIGN KEY ([Id_Grada])
    REFERENCES [dbo].[Gradovi]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Oblasti_Gradovi'
CREATE INDEX [IX_FK_Oblasti_Gradovi]
ON [dbo].[Oblasti]
    ([Id_Grada]);
GO

-- Creating foreign key on [Id_Oblasti] in table 'Ulice'
ALTER TABLE [dbo].[Ulice]
ADD CONSTRAINT [FK_Ulice_Oblasti]
    FOREIGN KEY ([Id_Oblasti])
    REFERENCES [dbo].[Oblasti]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Ulice_Oblasti'
CREATE INDEX [IX_FK_Ulice_Oblasti]
ON [dbo].[Ulice]
    ([Id_Oblasti]);
GO

-- Creating foreign key on [UliceId] in table 'Korisnici'
ALTER TABLE [dbo].[Korisnici]
ADD CONSTRAINT [FK_UliceKorisnici]
    FOREIGN KEY ([UliceId])
    REFERENCES [dbo].[Ulice]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UliceKorisnici'
CREATE INDEX [IX_FK_UliceKorisnici]
ON [dbo].[Korisnici]
    ([UliceId]);
GO

-- Creating foreign key on [KorisniciID] in table 'Rezervacije'
ALTER TABLE [dbo].[Rezervacije]
ADD CONSTRAINT [FK_KorisniciRezervacije]
    FOREIGN KEY ([KorisniciID])
    REFERENCES [dbo].[Korisnici]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KorisniciRezervacije'
CREATE INDEX [IX_FK_KorisniciRezervacije]
ON [dbo].[Rezervacije]
    ([KorisniciID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------