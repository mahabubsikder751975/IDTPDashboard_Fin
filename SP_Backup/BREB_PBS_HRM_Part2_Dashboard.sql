/****** Object:  StoredProcedure [dbo].[BREB_PBS_HRM_Part2_Dashboard]    Script Date: 31-Jan-21 5:46:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BREB_PBS_HRM_Part2_Dashboard]
	@CompanyName nvarchar(20),
	@OfficeName nvarchar(200) =''
AS
BEGIN
SET NOCOUNT ON;
	Declare @strSQL VarChar (MAX)
	Declare @WhereCondition VarChar (100) ='Where CompanyName='''+@CompanyName+''' and Trim(OfficeName)=Trim('''+@OfficeName+''')'
	SET @strSQL = 
	' SELECT *	FROM [PowerBIDB].[dbo].[BREB_PBS_HRM_SanctionPost_and_VacantPost] '+@WhereCondition+
	' Select * from [PowerBIDB].[dbo].[BREB_PBS_HRM_PBS_wise_Male_and_Female]'+@WhereCondition+
	' Select * from [PowerBIDB].[dbo].[BREB_PBS_HRM_Bacgroud_wise_Post]'+@WhereCondition+
	' Select * from [PowerBIDB].[dbo].[BREB_PBS_HRM_Zone_wise_Office]'+@WhereCondition+
	' Select * from [PowerBIDB].[dbo].[BREB_PBS_HRM_Employee_Job_Status]'+@WhereCondition
	EXEC(@strSQL)
END;

--[BREB_PBS_HRM_Part2_Dashboard] 'PBS','Dhaka-1'
