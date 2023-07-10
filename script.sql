IF db_id('ExcelTaskDB') IS NULL 
    CREATE DATABASE ExcelTaskDB
GO

USE ExcelTaskDB;
GO

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

CREATE TABLE [Allergies] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Allergies] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Diseases] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Diseases] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [NCDs] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_NCDs] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Patients] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [DiseaseId] int NOT NULL,
    [Epilepsy] int NOT NULL,
    CONSTRAINT [PK_Patients] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Patients_Diseases_DiseaseId] FOREIGN KEY ([DiseaseId]) REFERENCES [Diseases] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Allergies_Details] (
    [Id] int NOT NULL IDENTITY,
    [PatientId] int NOT NULL,
    [AllergiesId] int NOT NULL,
    CONSTRAINT [PK_Allergies_Details] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Allergies_Details_Allergies_AllergiesId] FOREIGN KEY ([AllergiesId]) REFERENCES [Allergies] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Allergies_Details_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [NCD_Details] (
    [Id] int NOT NULL IDENTITY,
    [PatientId] int NOT NULL,
    [NCDId] int NOT NULL,
    CONSTRAINT [PK_NCD_Details] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_NCD_Details_NCDs_NCDId] FOREIGN KEY ([NCDId]) REFERENCES [NCDs] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_NCD_Details_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Allergies_Details_AllergiesId] ON [Allergies_Details] ([AllergiesId]);
GO

CREATE INDEX [IX_Allergies_Details_PatientId] ON [Allergies_Details] ([PatientId]);
GO

CREATE INDEX [IX_NCD_Details_NCDId] ON [NCD_Details] ([NCDId]);
GO

CREATE INDEX [IX_NCD_Details_PatientId] ON [NCD_Details] ([PatientId]);
GO

CREATE INDEX [IX_Patients_DiseaseId] ON [Patients] ([DiseaseId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230708090441_init', N'6.0.19');
GO

COMMIT;
GO

