SET IDENTITY_INSERT dbo.Persons ON;
GO

IF NOT EXISTS(SELECT * FROM dbo.Persons)
BEGIN
	INSERT INTO dbo.Persons(PersonId, FirstName, BirthDate, Gender)
	VALUES
		(1, N'Антон', '1992-02-25', 1),
		(2, N'Надя', '1989-01-27', 0),
		(3, N'Яромир', '2016-08-12', 1);
END
GO

SET IDENTITY_INSERT dbo.Persons OFF;
GO


SET IDENTITY_INSERT dbo.Symptoms ON;
GO

IF NOT EXISTS(SELECT * FROM dbo.Symptoms)
BEGIN
	INSERT INTO dbo.Symptoms(SymptomId, [Name])
	VALUES
		(1, N'Кашель'),
		(2, N'Температура'),
		(3, N'Болит горло');
END
GO

SET IDENTITY_INSERT dbo.Symptoms OFF;
GO