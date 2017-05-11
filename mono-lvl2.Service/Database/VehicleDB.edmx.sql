
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/11/2017 13:35:21
-- Generated from EDMX file: C:\Users\Kruno\Documents\Visual Studio 2015\Projects\mono-lvl2.Service\mono-lvl2.Service\Database\VehicleDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'VehicleMakeSet'
CREATE TABLE [dbo].[VehicleMakeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Abrv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'VehicleModelSet'
CREATE TABLE [dbo].[VehicleModelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Abrv] nvarchar(max)  NOT NULL,
    [MakeId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'VehicleMakeSet'
ALTER TABLE [dbo].[VehicleMakeSet]
ADD CONSTRAINT [PK_VehicleMakeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VehicleModelSet'
ALTER TABLE [dbo].[VehicleModelSet]
ADD CONSTRAINT [PK_VehicleModelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MakeId] in table 'VehicleModelSet'
ALTER TABLE [dbo].[VehicleModelSet]
ADD CONSTRAINT [FK_VehicleMakeVehicleModel]
    FOREIGN KEY ([MakeId])
    REFERENCES [dbo].[VehicleMakeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleMakeVehicleModel'
CREATE INDEX [IX_FK_VehicleMakeVehicleModel]
ON [dbo].[VehicleModelSet]
    ([MakeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------