/****** Object:  StoredProcedure [dbo].[BREB_FAM_Dashboard]    Script Date: 31-Jan-21 5:47:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[BREB_FAM_Dashboard]
--ALTER PROCEDURE [dbo].[BREB_FA_Dashboard]
AS
BEGIN
SET NOCOUNT ON;
	Declare @strSQL VarChar (MAX)
	SET @strSQL = 
	' SELECT *	FROM [PowerBIDB].[dbo].[BREB_FAM_Insured_Vs_Non_Insured_Details] '+
	' Select * from [PowerBIDB].[dbo].[BREB_FAM_OfficeWise_Equipment_beyond_Service_Life_Analysis]'+
	' Select * from [PowerBIDB].[dbo].[BREB_FAM_OfficeWise_Operational_vs_Non_Operational_Transformer]'+
	' Select * from [PowerBIDB].[dbo].[BREB_FAM_Land_Usages_by_Offices]'+
	' Select * from [PowerBIDB].[dbo].[BREB_FA_Transformer_Operational_Analysis_by_Offices]'+
	' Select * from [PowerBIDB].[dbo].[BREB_FA_Transformer_Operational_Analysis_by_Month]'+
	' Select * from [PowerBIDB].[dbo].[BREB_FAM_Land_Area_by_Offices]'+
	' Select * from [PowerBIDB].[dbo].[BREB_FAM_Land_Encroachment_Ratio]'+
	' Select * from [PowerBIDB].[dbo].[BREB_FAM_Sub_Stations_by_Office]'
	EXEC(@strSQL)
END;
--[BREB_FAM_Dashboard]