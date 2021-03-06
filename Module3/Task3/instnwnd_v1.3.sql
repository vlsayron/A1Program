IF EXISTS ( 
	SELECT *
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Region')
BEGIN
	EXEC sp_rename 'Region', 'Regions';
END

GO

IF NOT EXISTS ( 
	SELECT *
	FROM INFORMATION_SCHEMA.COLUMNS
	WHERE TABLE_NAME = 'Customers' AND COLUMN_NAME = 'DateOfEstablishment' 
)
BEGIN
	ALTER TABLE [dbo].[Customers]
	ADD [DateOfEstablishment] DATETIME null
END
