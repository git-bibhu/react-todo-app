IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Task] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(300) NOT NULL,
    [DueDate] datetime2 NOT NULL,
    [Priority] nvarchar(10) NOT NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DueDate', N'Name', N'Priority') AND [object_id] = OBJECT_ID(N'[Task]'))
    SET IDENTITY_INSERT [Task] ON;
INSERT INTO [Task] ([Id], [DueDate], [Name], [Priority])
VALUES (1, '2021-02-10T00:00:00.0000000+05:30', N'Shopping', N'Low');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DueDate', N'Name', N'Priority') AND [object_id] = OBJECT_ID(N'[Task]'))
    SET IDENTITY_INSERT [Task] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DueDate', N'Name', N'Priority') AND [object_id] = OBJECT_ID(N'[Task]'))
    SET IDENTITY_INSERT [Task] ON;
INSERT INTO [Task] ([Id], [DueDate], [Name], [Priority])
VALUES (2, '2021-02-08T00:00:00.0000000+05:30', N'Meeting', N'High');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DueDate', N'Name', N'Priority') AND [object_id] = OBJECT_ID(N'[Task]'))
    SET IDENTITY_INSERT [Task] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DueDate', N'Name', N'Priority') AND [object_id] = OBJECT_ID(N'[Task]'))
    SET IDENTITY_INSERT [Task] ON;
INSERT INTO [Task] ([Id], [DueDate], [Name], [Priority])
VALUES (3, '2021-02-09T00:00:00.0000000+05:30', N'Health Checkup', N'Medium');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DueDate', N'Name', N'Priority') AND [object_id] = OBJECT_ID(N'[Task]'))
    SET IDENTITY_INSERT [Task] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210208141352_InitialTaskDB', N'5.0.2');
GO

COMMIT;
GO