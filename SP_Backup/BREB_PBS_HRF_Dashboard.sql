/****** Object:  StoredProcedure [dbo].[BREB_PBS_HRF_Dashboard]    Script Date: 31-Jan-21 5:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BREB_PBS_HRF_Dashboard]
	@CompanyName nvarchar(20),
	@OfficeName nvarchar(200) =''
AS
BEGIN
SET NOCOUNT ON;
	Declare @strSQL VarChar (MAX)
	Declare @WhereCondition VarChar (100)
	IF (@OfficeName='')
		SET @WhereCondition=' Where CompanyName='''+@CompanyName+''' '
	ELSE
	SET @WhereCondition=' Where CompanyName='''+@CompanyName+''' and Trim(OfficeName)=Trim('''+@OfficeName+''')'
	SET @strSQL = 
	' SELECT *	FROM [PowerBIDB].[dbo].[BREB_HRF_OfficeWise_Salary_by_Employee_Category] '+@WhereCondition+
	' SELECT *	FROM [PowerBIDB].[dbo].[BREB_HRF_Total_Net_Salary_by_Month] '+@WhereCondition+
	' SELECT *	FROM [PowerBIDB].[dbo].[BREB_HRF_OfficeWise_Allowances_Deductions_by_Month] '+@WhereCondition+
	' SELECT *	FROM [PowerBIDB].[dbo].[BREB_HRF_MonthWise_Total_Salary_by_Offices] '+@WhereCondition+
	' SELECT *	FROM [PowerBIDB].[dbo].[BREB_HRF_Gross_Salary_Expenditure] '+@WhereCondition+
	' SELECT *	FROM [PowerBIDB].[dbo].[BREB_HRF_Yearly_Festival_Bonus] '+@WhereCondition+
	' SELECT *	FROM [PowerBIDB].[dbo].[BREB_HRF_OfficeWise_Employee_GPF_Contribution] '+@WhereCondition
	EXEC(@strSQL)
END;

--[BREB_PBS_HRF_Dashboard] 'PBS','Dhaka-1'