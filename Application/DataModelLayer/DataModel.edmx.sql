
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2018 13:12:37
-- Generated from EDMX file: E:\system\foroosh\DataModelLayer\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [foroosh];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[forooshModelStoreContainer].[Vw_Users]', 'U') IS NOT NULL
    DROP TABLE [forooshModelStoreContainer].[Vw_Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NULL,
    [UserFamily] varchar(100)  NULL,
    [UserTel] varchar(11)  NULL,
    [UserUserName] varchar(50)  NULL,
    [UserPassword] varchar(128)  NULL,
    [UserAge] tinyint  NULL,
    [UserGender] tinyint  NULL,
    [UserActive] tinyint  NULL,
    [UserStartDate] varchar(20)  NULL
);
GO

-- Creating table 'Vw_Users'
CREATE TABLE [dbo].[Vw_Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NULL,
    [UserFamily] varchar(100)  NULL,
    [UserTel] varchar(11)  NULL,
    [UserUserName] varchar(50)  NULL,
    [UserPassword] varchar(128)  NULL,
    [UserAge] tinyint  NULL,
    [UserGender] tinyint  NULL,
    [UserActive] tinyint  NULL,
    [UserStartDate] varchar(20)  NULL,
    [UserGenderFarsi] varchar(4)  NULL,
    [UserActivefarsi] varchar(7)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [UserID] in table 'Vw_Users'
ALTER TABLE [dbo].[Vw_Users]
ADD CONSTRAINT [PK_Vw_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------