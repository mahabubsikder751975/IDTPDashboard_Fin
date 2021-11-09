USE [ERP_ProcedureDB]
DROP PROCEDURE IF EXISTS [dbo].[uspHRMForeignTourPurposeWiseOfficial]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspHRMForeignTourPurposeWiseOfficial]
@Organization varchar(20)
AS
/*Testing
exec uspHRMForeignTourPurposeWiseOfficial 'PGCB'
exec uspHRMForeignTourPurposeWiseOfficial 'BREB'
exec uspHRMForeignTourPurposeWiseOfficial 'APSCL'

*/
BEGIN
	CREATE TABLE #HRM_ForeignTour_Purpose_Wise_Official(
		[TotalTour] [bigint] NULL,
		[TourPurpose] [varchar](300) NULL,
		[Organization] [varchar](20) NULL,
		[OfficeName] [varchar](300) NULL,
		[PBSName] [varchar](300) NULL,
		[Order] [int] NULL
	)

	DECLARE @sqlcmd varchar(max)

			set @sqlcmd = '
					insert into #HRM_ForeignTour_Purpose_Wise_Official([TourPurpose],[Organization],[Order])
					VALUES (''Training'','''+@Organization+''',1),
							(''Inspection'','''+@Organization+''',2),
							(''Seminar'','''+@Organization+''',3),
							(''Meeting'','''+@Organization+''',4)
							--,(''Others'','''+@Organization+''',5)

					insert into #HRM_ForeignTour_Purpose_Wise_Official([TourPurpose],[TotalTour],[Organization])
					select case p.[Equivalent of Tour Purpose ]
					when ''4'' then ''Training''
					when ''5'' then ''Inspection''
					when ''6'' then ''Seminar''
					when ''7'' then ''Meeting''
					--when ''8'' then ''Others''
					end as [TourPurpose],
					Count(*) as [TotalTour],'''+@Organization+'''
					from POWERDIVERPDB.dbo.['+@Organization+'$Employee Foreign Tour] as e
					join POWERDIVERPDB.dbo.['+@Organization+'$Foreign Tour Purpose] as p on e.[Tour Purpose] = p.[Code]
					where p.[Tour Category] = 1
					and Year(e.[From Date]) = Year(GetDate())
					Group by p.[Equivalent of Tour Purpose ]
			';


	exec(@sqlcmd)

	SELECT Sum(ISNULL([TotalTour],0)) as [TotalTour],[TourPurpose],[Organization],[OfficeName],[PBSName],avg([Order]) as [Order]
	  FROM #HRM_ForeignTour_Purpose_Wise_Official
	  Where [TourPurpose]!=''
	  Group by [TourPurpose],[Organization],[OfficeName],[PBSName]
	  Order By [Order]
END
GO