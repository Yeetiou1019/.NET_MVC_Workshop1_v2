
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/08/2019 16:54:22
-- Generated from EDMX file: C:\Users\Yee\source\repos\WebApplication1\WebApplication1\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [bookdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Book_Class]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Book_Class];
GO
IF OBJECT_ID(N'[dbo].[Book_Code]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Book_Code];
GO
IF OBJECT_ID(N'[dbo].[Book_Data]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Book_Data];
GO
IF OBJECT_ID(N'[dbo].[Member]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Member];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Book_Class'
CREATE TABLE [dbo].[Book_Class] (
    [Book_Class_Id] nvarchar(8)  NOT NULL,
    [Book_Class_Name] nvarchar(120)  NOT NULL,
    [Create_Date] datetime  NULL,
    [Create_User] nvarchar(24)  NULL,
    [Modify_Date] datetime  NULL,
    [Modify_user] nvarchar(24)  NULL
);
GO

-- Creating table 'Book_Code'
CREATE TABLE [dbo].[Book_Code] (
    [Code_Type] nvarchar(100)  NOT NULL,
    [Code_Id] nvarchar(200)  NOT NULL,
    [Code_Type_Desc] nvarchar(400)  NULL,
    [Code_Name] nvarchar(400)  NULL,
    [Create_Date] datetime  NULL,
    [Create_User] nvarchar(20)  NULL,
    [Modify_Date] datetime  NULL,
    [Modify_User] nvarchar(20)  NULL
);
GO

-- Creating table 'Book_Data'
CREATE TABLE [dbo].[Book_Data] (
    [Book_Name] nvarchar(400)  NOT NULL,
    [Book_Author] nchar(60)  NULL,
    [Book_Bought_Date] datetime  NULL,
    [Book_Publisher] nvarchar(40)  NULL,
    [Book_Note] nvarchar(2400)  NULL,
    [Book_Status] char(1)  NOT NULL,
    [Book_Keeper] nvarchar(24)  NULL,
    [Create_Date] datetime  NULL,
    [Create_User] nvarchar(24)  NULL,
    [Modify_Date] datetime  NULL,
    [Modify_User] nvarchar(24)  NULL,
    [User_Id] nvarchar(24)  NOT NULL,
    [Code_Id] nvarchar(200)  NOT NULL,
    [Book_Class_Id] nvarchar(8)  NOT NULL,
    [Book_Id] int  NOT NULL
);
GO

-- Creating table 'Member'
CREATE TABLE [dbo].[Member] (
    [User_Id] nvarchar(24)  NOT NULL,
    [User_CName] nvarchar(100)  NULL,
    [User_EName] nvarchar(100)  NULL,
    [Create_Date] datetime  NULL,
    [Create_User] nvarchar(24)  NULL,
    [Modify_Date] datetime  NULL,
    [Modify_User] nvarchar(24)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Book_Class_Id] in table 'Book_Class'
ALTER TABLE [dbo].[Book_Class]
ADD CONSTRAINT [PK_Book_Class]
    PRIMARY KEY CLUSTERED ([Book_Class_Id] ASC);
GO

-- Creating primary key on [Code_Id] in table 'Book_Code'
ALTER TABLE [dbo].[Book_Code]
ADD CONSTRAINT [PK_Book_Code]
    PRIMARY KEY CLUSTERED ([Code_Id] ASC);
GO

-- Creating primary key on [User_Id], [Code_Id], [Book_Class_Id], [Book_Id] in table 'Book_Data'
ALTER TABLE [dbo].[Book_Data]
ADD CONSTRAINT [PK_Book_Data]
    PRIMARY KEY CLUSTERED ([User_Id], [Code_Id], [Book_Class_Id], [Book_Id] ASC);
GO

-- Creating primary key on [User_Id] in table 'Member'
ALTER TABLE [dbo].[Member]
ADD CONSTRAINT [PK_Member]
    PRIMARY KEY CLUSTERED ([User_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'Book_Data'
ALTER TABLE [dbo].[Book_Data]
ADD CONSTRAINT [FK_Book_DataMember]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Member]
        ([User_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Code_Id] in table 'Book_Data'
ALTER TABLE [dbo].[Book_Data]
ADD CONSTRAINT [FK_Book_DataBook_Code]
    FOREIGN KEY ([Code_Id])
    REFERENCES [dbo].[Book_Code]
        ([Code_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Book_DataBook_Code'
CREATE INDEX [IX_FK_Book_DataBook_Code]
ON [dbo].[Book_Data]
    ([Code_Id]);
GO

-- Creating foreign key on [Book_Class_Id] in table 'Book_Data'
ALTER TABLE [dbo].[Book_Data]
ADD CONSTRAINT [FK_Book_DataBook_Class]
    FOREIGN KEY ([Book_Class_Id])
    REFERENCES [dbo].[Book_Class]
        ([Book_Class_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Book_DataBook_Class'
CREATE INDEX [IX_FK_Book_DataBook_Class]
ON [dbo].[Book_Data]
    ([Book_Class_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------