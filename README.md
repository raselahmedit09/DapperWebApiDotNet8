Featured:
Repository Pattern
Mapper

Database:

Create Table:
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Age] [int] NOT NULL,
	[Position] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

Procedures:

CREATE PROCEDURE [dbo].[usp_AddCompany](
@Id int OUTPUT,
@Name varchar(500),
@Age INT,
@Position varchar(500)
)

AS
BEGIN 
    INSERT INTO Employees (Name, Age,Position) 
	VALUES(@Name, @Age, @Position);
    SELECT @Id = SCOPE_IDENTITY();
END


CREATE PROCEDURE [dbo].[usp_DeleteEmployees](
@Id INT
)

AS 

DELETE FROM Employees 
WHERE Id= @Id


CREATE PROCEDURE [dbo].[usp_GetEmployeeById](
@EmployeeId INT 
)

AS 

SELECT * FROM Employees WHERE Id = @EmployeeId


CREATE PROCEDURE [dbo].[usp_GetEmployees]

AS 

SELECT * FROM Employees


CREATE PROCEDURE [dbo].[usp_UpdateCompany](
@Id int,
@Name varchar(500),
@Age INT,
@Position varchar(500)
)

AS 

UPDATE Employees  
SET 
Name = @Name, 
Age = @Age,
Position=@Position
WHERE Id=@Id;
