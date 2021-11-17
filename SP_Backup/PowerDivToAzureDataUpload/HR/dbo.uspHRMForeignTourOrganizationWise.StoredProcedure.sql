USE [ERP_ProcedureDB]
DROP PROCEDURE IF EXISTS [dbo].[uspHRMTransactionsAmountTodayByFI]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspHRMTransactionsAmountTodayByFI]
@Organization varchar(20)
AS
/*Testing
exec uspHRMTransactionsAmountTodayByFI 'PGCB'
exec uspHRMTransactionsAmountTodayByFI 'BREB'
exec uspHRMTransactionsAmountTodayByFI 'NWPGCL'

*/
BEGIN
	CREATE TABLE #HRM_ForeignTour_Organization_Wise(
		[TotalTour] [bigint] NULL,
		[Organization] [varchar](20) NULL,
		[OfficeName] [varchar](300) NULL,
		[PBSName] [varchar](300) NULL
	)

	DECLARE @sqlcmd varchar(max)

			set @sqlcmd = '
					insert into #HRM_ForeignTour_Organization_Wise([TotalTour],[Organization])
					select Count(distinct [Employee No_]) as [newemployee],'''+@Organization+'''
					from POWERDIVERPDB.dbo.['+@Organization+'$Employee Foreign Tour] e
					where [ForeignTourCategory]=1 and Year([From Date]) = Year(GetDate())

			';


	exec(@sqlcmd)

	SELECT Sum(ISNULL([TotalTour],0)) as [TotalTour],[Organization],[OfficeName],[PBSName]
	  FROM #HRM_ForeignTour_Organization_Wise
	  Group by [Organization],[OfficeName],[PBSName]

END
GO