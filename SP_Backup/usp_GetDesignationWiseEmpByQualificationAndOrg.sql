USE [PowerBIDB]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetDesignationWiseEmpByQualificationAndOrg]    Script Date: 06-11-2021 12:39:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create or ALTER PROCEDURE [dbo].[usp_GetDesignationWiseEmpByQualificationAndOrg]
@org varchar(20),
@qualification varchar(100)

AS
BEGIN
SET NOCOUNT ON;
	Declare @strSQL VarChar (MAX)


	SET @strSQL = 'Select Sum([Total]) as [Total],[Designation],[DesignationOrder] from [PowerBIDB].[dbo].[HRM_Officers_Wise_Employee_Qualifications] Where Qualification ='''+@qualification+''''+' and [Organization]='''+@org+''''+' Group By [Designation],[DesignationOrder] Order By [DesignationOrder]'
	exec(@strSQL)
END;

--[usp_GetDesignationWiseEmpByQualificationAndOrg] 'APSCL','Master`s'
