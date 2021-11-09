USE [PowerBIDB]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetOrgWiseEmpByQualification]    Script Date: 06-11-2021 12:39:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_GetOrgWiseEmpByQualification]
@qualification nvarchar(100)

AS
BEGIN
SET NOCOUNT ON;
	Declare @strSQL VarChar (MAX)


	SET @strSQL = 'Select Sum([Total]) as [Total],[Organization] from [PowerBIDB].[dbo].[HRM_Officers_Wise_Employee_Qualifications] Where Qualification ='''+@qualification+''''+' Group By [Organization]'
	exec(@strSQL)
END;

--[usp_GetOrgWiseEmpByQualification] 'Master`s'
