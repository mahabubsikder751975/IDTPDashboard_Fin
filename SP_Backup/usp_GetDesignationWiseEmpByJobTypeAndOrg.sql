USE [PowerBIDB]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetDesignationWiseEmpByJobTypeAndOrg]    Script Date: 06-11-2021 12:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create or Alter PROCEDURE [dbo].[usp_GetDesignationWiseEmpByJobTypeAndOrg]
@org nvarchar(20),
@jobStatus nvarchar(100)

AS
BEGIN
SET NOCOUNT ON;
	Declare @strSQL VarChar (MAX)


	SET @strSQL = 'Select Sum([Sum_Total_Employee]) as [Sum_Total_Employee],[Designation],[DesignationOrder] from [PowerBIDB].[dbo].[HRM_Employee_Job_Status] Where Employee_Job_Status_Code ='''+@jobStatus+''''+' and [Organization]='''+@org+''''+'Group By [Designation],[DesignationOrder] Order By [DesignationOrder]'
	exec(@strSQL)
END;

--[usp_GetDesignationWiseEmpByJobTypeAndOrg] 'APSCL','Permanent'
