/****** Object:  StoredProcedure [dbo].[BREB_Finance_Dashboard]    Script Date: 31-Jan-21 5:48:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BREB_Finance_Dashboard]
AS
BEGIN
SET NOCOUNT ON;
	Declare @strSQL VarChar (MAX)
	SET @strSQL = 
	' Select [Organization Name],[Expense],[Revenue],[Order] from [PowerBIDB].[dbo].[BREB_Finance_Expense_vs_Revenue_OfficeWise]'+
	' Select * from [PowerBIDB].[dbo].[BREB_Finance_Net_Profit_Gross_Revenue_and_EBIT_OfficeWise]'+
	' Select * from [PowerBIDB].[dbo].[BREB_Finance_Account_Receivable_Vs_Cashflow_OfficeWise]'	+
	' Select * from [PowerBIDB].[dbo].[BREB_Finance_Capital_Expenditure_Vs_Operational_Expenses_OfficeWise]'+
	' Select [Accounts Payable],[Order],[Office Name] from [PowerBIDB].[dbo].[BREB_Finance_Office_Wise_Accounts_payable]'+	
	' Select * from [PowerBIDB].[dbo].[BREB_Finance_Office_wise_ROI]'+
	' SELECT [Accounts Payable],[Order],[Office Name]	FROM [PowerBIDB].[dbo].[BREB_Finance_OfficeWise_Turnover_Last_Year] '
	EXEC(@strSQL)
END;
--[BREB_Finance_Dashboard]

