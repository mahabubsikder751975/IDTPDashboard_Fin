DROP PROCEDURE IF EXISTS [dbo].[uspHRMNetDebitCapPositionByFI]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspHRMNetDebitCapPositionByFI]
@Organization varchar(20)
AS
/*Testing
exec uspHRMNetDebitCapPositionByFI 'APSCL'
exec uspHRMNetDebitCapPositionByFI 'BREB'
exec uspHRMNetDebitCapPositionByFI 'PBS'

*/
BEGIN
	CREATE TABLE #HRM_Retirement_vs_NewEmployee(
		[retirement] [bigint] NULL,
		[newemployee] [bigint] NULL,
		[Organization] [varchar](20) NULL,
		[OfficeName] [varchar](300) NULL,
		[PBSName] [varchar](300) NULL
	)

	DECLARE @sqlcmd varchar(max)

			set @sqlcmd = '
					insert into #HRM_Retirement_vs_NewEmployee([newemployee],[Organization])
					select Count([No_]) as [newemployee],'''+@Organization+'''
					from POWERDIVERPDB.dbo.['+@Organization+'$Employee] e
					where Year([Employment Date]) = Year(GetDate())-1

					insert into #HRM_Retirement_vs_NewEmployee([retirement],[Organization])
					select Count([No_]) as [retirement],'''+@Organization+'''
					from POWERDIVERPDB.dbo.['+@Organization+'$Employee] as e
					join POWERDIVERPDB.dbo.['+@Organization+'$Employee Retirement] as r on r.[Employee No_] = e.[No_]
					where r.[Approval Status]=2 AND Year(r.[Retirement Date]) = Year(GetDate())-1
			';


	exec(@sqlcmd)

	SELECT Sum(ISNULL([retirement],0)) as [retirement],Sum(ISNULL([newemployee],0)) as [newemployee],[Organization],[OfficeName],[PBSName]
	  FROM #HRM_Retirement_vs_NewEmployee
	  Group by [Organization],[OfficeName],[PBSName]

END
GO