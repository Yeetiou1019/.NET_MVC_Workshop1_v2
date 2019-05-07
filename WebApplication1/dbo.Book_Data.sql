CREATE TABLE [dbo].[Book_Data] (
    [Book_Id]          INT             NOT NULL,
    [Book_Name]        NVARCHAR (400)  NOT NULL,
    [Book_Class_Id]    NVARCHAR (8)    NOT NULL,
    [Book_Author]      NCHAR (60)      NULL,
    [Book_Bought_Date] DATETIME        NULL,
    [Book_Publisher]   NVARCHAR (40)   NULL,
    [Book_Note]        NVARCHAR (2400) NULL,
    [Book_Status]      CHAR (1)        NOT NULL,
    [Book_Keeper]      NVARCHAR (24)   NULL,
    [Create_Date]      DATETIME        NULL,
    [Create_User]      NVARCHAR (24)   NULL,
    [Modify_Date]      DATETIME        NULL,
    [Modify_User]      NVARCHAR (24)   NULL,
    [User_Id] NVARCHAR(24) NOT NULL, 
    [Code_Id] NVARCHAR(100) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Book_Id] ASC)
);

