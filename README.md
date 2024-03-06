Database : 
GO

/****** Object:  Table [dbo].[Employees]    Script Date: 3/6/2024 10:59:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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
GO

------------------------------------- 
GO
/****** Object:  StoredProcedure [dbo].[usp_AddCompany]    Script Date: 3/6/2024 11:00:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_AddCompany](
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

------------------ 
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteEmployees]    Script Date: 3/6/2024 11:00:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_DeleteEmployees](
@Id INT
)

AS 

DELETE FROM Employees 
WHERE Id= @Id

-------------------------- 
GO
/****** Object:  StoredProcedure [dbo].[usp_GetEmployeeById]    Script Date: 3/6/2024 11:00:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_GetEmployeeById](
@EmployeeId INT 
)

AS 

SELECT * FROM Employees WHERE Id = @EmployeeId
----------------------------------------------------

GO
/****** Object:  StoredProcedure [dbo].[usp_GetEmployees]    Script Date: 3/6/2024 11:01:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_GetEmployees]

AS 

SELECT * FROM Employees

----------------------- 

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateCompany]    Script Date: 3/6/2024 11:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_UpdateCompany](
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
