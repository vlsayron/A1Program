IF NOT EXISTS (SELECT * 
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'CreditCards')
BEGIN
CREATE TABLE dbo.CreditCards
(
	Id int not null IDENTITY(1,1),
    Number NVARCHAR(20) NOT NULL,
	ExpirationDate DATETIME NOT NULL,
	CardHolder NVARCHAR(50) NOT NULL,
	EmployeeId int not null,
	constraint FK_Employee foreign key (EmployeeId) references Employees(EmployeeID),
	constraint PK_CreditCard primary key Nonclustered (Id)
)
END