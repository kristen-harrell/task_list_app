﻿CREATE TABLE ToDo (
[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
[Name] NVARCHAR(30) NOT NULL, [Description] NVARCHAR(250),
[Email]NVARCHAR(100), [DueDate] DATE, [Completed] BIT)