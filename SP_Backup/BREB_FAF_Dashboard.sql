/****** Object:  StoredProcedure [dbo].[BREB_FAF_Dashboard]    Script Date: 31-Jan-21 5:47:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BREB_FAF_Dashboard]
--ALTER PROCEDURE [dbo].[BREB_FA_Dashboard]
AS
BEGIN
SET NOCOUNT ON;
	Declare @strSQL VarChar (MAX)
	SET @strSQL = 
	' SELECT [Office Name],[Transormer],[Machinery/Euqipment],Vehicle,[Office Euqipment],Building,[Civil Works],isnull([Sequence No],0) as [Sequence No]	FROM [PowerBIDB].[dbo].[BREB_FAF_Maintenance_Cost_by_Office] '+
	' Select * from [PowerBIDB].[dbo].[BREB_FAF_Asset_Acquisition_Office_Wise]'+
	' Select * from [PowerBIDB].[dbo].[BREB_FAF_Land_Value_by_Office]'+
	' Select * from [PowerBIDB].[dbo].[BREB_FAF_Book_Value_vs_Accumulated_Price_AssetWise]'+
	' Select * from [PowerBIDB].[dbo].[BREB_FAF_Asset_Disposed_Asset_Wise]'+
	' Select * from [PowerBIDB].[dbo].[BREB_FAF_Asset_Disposed_Office_Wise]'+
	' Select Top(6) * from [PowerBIDB].[dbo].[BREB_FAF_Asset_Acquisition_Asset_Wise] Order by ([Acquisition Amount]) DESC'+
	' Select Top(6) * from [PowerBIDB].[dbo].[BREB_FAF_Maintenance_Cost_By_Month] Order by ([Sequence No.])'+
	' Select Top(6) * from [PowerBIDB].[dbo].[BREB_FAF_Book_Value_by_Asset_Type_Wise] Order by ([Book Value]) DESC'
	EXEC(@strSQL)
END;
--[BREB_FAF_Dashboard]