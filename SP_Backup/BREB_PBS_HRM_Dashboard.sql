/****** Object:  StoredProcedure [dbo].[BREB_PBS_HRM_Dashboard]    Script Date: 31-Jan-21 5:46:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BREB_PBS_HRM_Dashboard]
	@CompanyName nvarchar(20),
	@OfficeName nvarchar(200) =''
AS
BEGIN
SET NOCOUNT ON;
	Declare @strSQL VarChar (MAX)
	Declare @WhereCondition VarChar (100);
	IF (@OfficeName='')
		SET @WhereCondition=' Where CompanyName='''+@CompanyName+''' '
	ELSE
		SET @WhereCondition=' Where CompanyName='''+@CompanyName+''' and Trim(OfficeName)=Trim('''+@OfficeName+''')'
	
	SET @strSQL = 
	' SELECT *	FROM [PowerBIDB].[dbo].[BREB_HRM_OfficersStaff_Wise_Employee_Attendance] '+@WhereCondition+
	' Select * from [PowerBIDB].[dbo].[BREB_HRM_OfficersStaff_Wise_Employee_On_Leave_Today]'+@WhereCondition+
	' Select * from [PowerBIDB].[dbo].[BREB_HRM_OfficersStaff_Wise_FIll_Vs_Vacant_Post]'+@WhereCondition+
	' Select * from [PowerBIDB].[dbo].[BREB_HRM_Upcoming_Retirement]'+@WhereCondition+
	' Select * from [PowerBIDB].[dbo].[BREB_HRM_Catg_Officers_Employee_Performance]'+@WhereCondition+
	' Select * from [PowerBIDB].[dbo].[BREB_HRM_Employee_Job_Status]'+@WhereCondition+
	' Select * from [PowerBIDB].[dbo].[BREB_HRM_Officers_Wise_Employee_Qualifications]'+@WhereCondition
	EXEC(@strSQL)
END;

--[BREB_PBS_HRM_Dashboard] 'PBS','Dhaka-1'