Use [ERP_ProcedureDB]

DROP PROCEDURE IF EXISTS [dbo].[uspHRMPostWiseRetirementvsNewEmployee]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspHRMPostWiseRetirementvsNewEmployee]
@Organization varchar(20)
AS
/*Testing
exec uspHRMPostWiseRetirementvsNewEmployee 'APSCL'
exec uspHRMPostWiseRetirementvsNewEmployee 'BREB'
exec uspHRMPostWiseRetirementvsNewEmployee 'PBS'

*/
BEGIN
	CREATE TABLE #HRM_Post_Wise_Retirement_vs_NewEmployee(
		[Retirement] [bigint] NULL,
		[Newemployee] [bigint] NULL,
		[Organization] [varchar](20) NULL,
		[PostType] [varchar](100) NULL,
		[Designation] [varchar](300) NULL,
		[DesignationCode] [varchar](300) NULL,
		[DesignationOrder] [varchar](300) NULL
	)

	DECLARE @sqlcmd varchar(max)

			set @sqlcmd = '
					insert into #HRM_Post_Wise_Retirement_vs_NewEmployee([Newemployee],[Organization],[PostType],[Designation],[DesignationCode],[DesignationOrder])
					select Count([No_]) as [newemployee],'''+@Organization+''',case d.Post_Type when 0 then ''Officer'' when 1 then ''Staff'' end as ''PostType'',d.[Description],d.[Designation Code],d.[Order number]
					from POWERDIVERPDB.dbo.['+@Organization+'$Employee] e
					JOIN [POWERDIVERPDB].[dbo].['+@Organization+'$Designation] as d ON e.[Designation Code]=d.[Designation Code]
					where Year([Employment Date]) = Year(GetDate())-1
					GROUP BY d.[Description],d.[Designation Code],d.[Order number],d.Post_Type

					insert into #HRM_Post_Wise_Retirement_vs_NewEmployee([Retirement],[Organization],[PostType],[Designation],[DesignationCode],[DesignationOrder])
					select Count([No_]) as [retirement],'''+@Organization+''',case d.Post_Type when 0 then ''Officer'' when 1 then ''Staff'' end as ''PostType'',d.[Description],d.[Designation Code],d.[Order number]
					from POWERDIVERPDB.dbo.['+@Organization+'$Employee] as e
					join POWERDIVERPDB.dbo.['+@Organization+'$Employee Retirement] as r on r.[Employee No_] = e.[No_]
					JOIN [POWERDIVERPDB].[dbo].['+@Organization+'$Designation] as d ON e.[Designation Code]=d.[Designation Code]
					where r.[Approval Status]=2 AND Year(r.[Retirement Date]) = Year(GetDate())-1
					GROUP BY d.[Description],d.[Designation Code],d.[Order number],d.Post_Type
			';


	exec(@sqlcmd)

	SELECT Sum(ISNULL([Retirement],0)) as [Retirement],Sum(ISNULL([Newemployee],0)) as [Newemployee],[Organization],[PostType],[Designation],[DesignationCode],[DesignationOrder]
	  FROM #HRM_Post_Wise_Retirement_vs_NewEmployee
	  Group by [Organization],[PostType],[Designation],[DesignationCode],[DesignationOrder]

END
GO