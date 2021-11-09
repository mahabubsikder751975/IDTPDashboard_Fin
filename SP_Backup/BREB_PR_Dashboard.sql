/****** Object:  StoredProcedure [dbo].[BREB_PR_Dashboard]    Script Date: 31-Jan-21 5:47:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BREB_PR_Dashboard]
AS
BEGIN
SET NOCOUNT ON;
	Declare @strSQL VarChar (MAX)
	SET @strSQL = 
	' SELECT *	FROM [PowerBIDB].[dbo].[BREB_PR_Yearly_Procurement_Trend_Analysis] '+
	' Select * from [PowerBIDB].[dbo].[BREB_PR_Top_Procured_Items_in_Offices]'+
	' Select * from [PowerBIDB].[dbo].[BREB_PR_Procurement_value_by_Offices]'+
	' Select * from [PowerBIDB].[dbo].[BREB_PR_ProcurementType_Office_Wise]'+
	' Select * from [PowerBIDB].[dbo].[BREB_PR_Procurement_Status_Analysis]'+
	' Select * from [PowerBIDB].[dbo].[BREB_PR_APP_Utilization]'+
	' Select * from [PowerBIDB].[dbo].[BREB_PR_Requisition_Status]'	
	EXEC(@strSQL)
END;
--[BREB_PR_Dashboard]

