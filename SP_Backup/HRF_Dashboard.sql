USE [PowerBIDB]
GO
/****** Object:  StoredProcedure [dbo].[HRF_Dashboard]    Script Date: 07-11-2021 15:58:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[HRF_Dashboard]
	@Organization nvarchar(20)
AS
BEGIN
SET NOCOUNT ON;
	Declare @strSQL VarChar (MAX)
	Declare @WhereCondition VarChar (100)

	SET @WhereCondition=' Where [Organization]='''+@Organization+''' '

	IF (@Organization='IDTP') BEGIN
		SET @strSQL = 
		' SELECT Sum([ApprenticeTechnical]) as [ApprenticeTechnical],Sum([CasualDailyBasis]) as [CasualDailyBasis],Sum([Consultant]) as [Consultant],Sum([ContractualEmployees]) as [ContractualEmployees],Sum([MusterRollEmployees]) as [MusterRollEmployees],Sum([PermanentEmployees]) as [PermanentEmployees],avg([SequenceNo]) as [SequenceNo], '''+@Organization+''' as [Organization],[Organization] as [OfficeName],'' '' as [PBSName]	FROM [PowerBIDB].[dbo].[HRF_OfficeWise_Salary_by_Employee_Category] Group By [Organization]'+
		' SELECT [SalaryDate],Sum([TotalSalary]) as[TotalSalary],avg([SequenceNo]) as [SequenceNo], '''+@Organization+''' as [Organization],'' '' as [OfficeName],'' '' as [PBSName] FROM [PowerBIDB].[dbo].[HRF_Total_Net_Salary_by_Month] Group By [SalaryDate]'+'Order By [SequenceNo] DESC'+
		' SELECT Sum(isnull([HouseRentAllowance],0)) as [HouseRentAllowance],Sum(isnull([TransportAllowance],0)) as [TransportAllowance],Sum(isnull([MedicalAllowance],0)) as [MedicalAllowance],Sum(isnull([CPFContribution],0)) as [CPFContribution],Sum(isnull([TDS],0)) as [TDS],avg(isnull([SequenceNo],0)) as [SequenceNo], '''+@Organization+''' as [Organization],[Organization] as [OfficeName],'' '' as [PBSName]	FROM [PowerBIDB].[dbo].[HRF_OfficeWise_Allowances_Deductions_by_Month] Group By [Organization]'+
		' SELECT Sum(isnull([TotalSalary],0)) as [TotalSalary],avg(isnull([SequenceNo],0)) as [SequenceNo],'''+@Organization+''' as [Organization],[Organization] as [OfficeName],'' '' as [PBSName] FROM [PowerBIDB].[dbo].[HRF_MonthWise_Total_Salary_by_Offices]  where [Organization] != ''PBS'' Group By [Organization]'+
		' SELECT [ExpenditureType],Sum([Amount]) as [Amount], '''+@Organization+''' as [Organization],'' '' as [OfficeName],'' '' as [PBSName]	FROM [PowerBIDB].[dbo].[HRF_Gross_Salary_Expenditure] Group By [ExpenditureType]'+
		' SELECT [BonusName],Sum([TotalBonusAmount]) as [TotalBonusAmount],'''+@Organization+''' as [Organization],'' '' as [OfficeName],'' '' as [PBSName]	FROM [PowerBIDB].[dbo].[HRF_Yearly_Festival_Bonus] where [BonusName] != '''' Group By [BonusName]'+
		' SELECT Sum([CPFContribution]) as [CPFContribution],'''+@Organization+''' as [Organization],[Organization] as [OfficeName],'' '' as [PBSName]	FROM [PowerBIDB].[dbo].[HRF_OfficeWise_Employee_GPF_Contribution] Group By [Organization]'
	END
	ELSE BEGIN
		SET @strSQL = 
		' SELECT *	FROM [PowerBIDB].[dbo].[HRF_OfficeWise_Salary_by_Employee_Category] '+@WhereCondition+
		' SELECT *	FROM [PowerBIDB].[dbo].[HRF_Total_Net_Salary_by_Month] '+@WhereCondition+
		' SELECT isnull([HouseRentAllowance],0) as [HouseRentAllowance],isnull([TransportAllowance],0) as [TransportAllowance],isnull([MedicalAllowance],0) as [MedicalAllowance],isnull([CPFContribution],0) as [CPFContribution],isnull([TDS],0) as [TDS],isnull([SequenceNo],0) as [SequenceNo],[Organization],[OfficeName],[PBSName]	FROM [PowerBIDB].[dbo].[HRF_OfficeWise_Allowances_Deductions_by_Month] '+@WhereCondition+
		' SELECT isnull([TotalSalary],0) as [TotalSalary],isnull([SequenceNo],0) as [SequenceNo],[Organization],[OfficeName],[PBSName] FROM [PowerBIDB].[dbo].[HRF_MonthWise_Total_Salary_by_Offices] '+@WhereCondition+
		' SELECT *	FROM [PowerBIDB].[dbo].[HRF_Gross_Salary_Expenditure] '+@WhereCondition+
		' SELECT *	FROM [PowerBIDB].[dbo].[HRF_Yearly_Festival_Bonus] '+@WhereCondition+
		' SELECT *	FROM [PowerBIDB].[dbo].[HRF_OfficeWise_Employee_GPF_Contribution] '+@WhereCondition
	END
	EXEC(@strSQL)
	--print(@strSQL)
END;

--[HRF_Dashboard] 'BREB'
--[HRF_Dashboard] 'PBS'
/*
[HRF_Dashboard] 'IDTP'
*/
