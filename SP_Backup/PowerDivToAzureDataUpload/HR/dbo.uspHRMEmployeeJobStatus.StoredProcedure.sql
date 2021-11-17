Use [ERP_ProcedureDB]
DROP PROCEDURE IF EXISTS [dbo].[uspHRMTransactionsSettledUnsettled]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspHRMTransactionsSettledUnsettled]
@Organization varchar(20)
AS
/*Testing
exec uspHRMTransactionsSettledUnsettled 'CPGCBL'
exec uspHRMTransactionsSettledUnsettled 'BREB'
exec uspHRMTransactionsSettledUnsettled 'BPDB'
*/
BEGIN
	CREATE TABLE #HRM_Employee_Job_Status(
		[Employee_Job_Status_Code] [nvarchar](max) NULL,
		[Sum_Total_Employee] [bigint] NULL,
		[Organization] [varchar](20) NULL,
		[Designation] [varchar](300) NULL,
		[DesignationOrder] [int]  NULL
	)



	DECLARE @sqlcmd varchar(max)

		set @sqlcmd = '
		


			INSERT INTO #HRM_Employee_Job_Status([Employee_Job_Status_Code],[Sum_Total_Employee] ,[Designation],[Organization],[DesignationOrder])
			
					select case [Type]
					when ''0'' then ''Permanent''
					when ''1'' then ''Contractual''
					when ''2'' then ''Temporary''
					end as [Type],count(E.[No_]) as total,D.[Description],'''+@Organization+''',D.[Order number]
					From [POWERDIVERPDB].[dbo].['+@Organization+'$Employee Job Type] s 
			join POWERDIVERPDB.dbo.['+@Organization+'$Employee] E on s.[Job Type Code] = E.[Employee Job Status Code] 
			join POWERDIVERPDB.dbo.['+@Organization+'$Designation] D on D.[Designation Code] = E.[Designation Code] 
			Where E.Status=0
			Group by s.[Type],D.[Description],D.[Order number]
			Order by D.[Order number]
		';

	exec(@sqlcmd)
	--Print(@sqlcmd)
	SELECT [Employee_Job_Status_Code],SUM(ISNULL([Sum_Total_Employee],0)) as [Sum_Total_Employee],[Organization],[Designation],[DesignationOrder]
	  FROM #HRM_Employee_Job_Status 
	  --where OfficeName='Bagerhat'
	  Group BY [Organization],[Designation],[DesignationOrder],[Employee_Job_Status_Code] Order by [Sum_Total_Employee]  DESC
END
GO
