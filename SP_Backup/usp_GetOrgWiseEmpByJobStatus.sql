USE [PowerBIDB]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetOrgWiseEmpByJobStatus]    Script Date: 06-11-2021 11:53:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_GetOrgWiseEmpByJobStatus]
@jobStatus nvarchar(100)

AS
BEGIN
SET NOCOUNT ON;
	Declare @strSQL VarChar (MAX)


	SET @strSQL = 'Select Sum([Sum_Total_Employee]) as [Sum_Total_Employee],[Organization] from [PowerBIDB].[dbo].[HRM_Employee_Job_Status] Where Employee_Job_Status_Code ='''+@jobStatus+''''+' Group By [Organization]'
	exec(@strSQL)
END;

--[usp_GetOrgWiseEmpByJobStatus] 'Permanent'
