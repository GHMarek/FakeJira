CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY identity
	, FirstName nvarchar(250)
	, LastName nvarchar(250)
	, EmailAddress nvarchar(250)
	, DepartmentId int
	, BusinessRoleId int
)
