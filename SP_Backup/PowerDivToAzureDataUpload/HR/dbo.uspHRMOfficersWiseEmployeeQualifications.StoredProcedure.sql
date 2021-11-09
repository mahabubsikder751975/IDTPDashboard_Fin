Use [ERP_ProcedureDB]
DROP PROCEDURE IF EXISTS [dbo].[uspHRMOfficersWiseEmployeeQualifications]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[uspHRMOfficersWiseEmployeeQualifications]
@Organization varchar(20)
AS
/*Testing
exec uspHRMOfficersWiseEmployeeQualifications 'APSCL'
exec uspHRMOfficersWiseEmployeeQualifications 'CPGCBL'
exec uspHRMOfficersWiseEmployeeQualifications 'BREB'
exec uspHRMOfficersWiseEmployeeQualifications 'PBS'
*/
BEGIN
	CREATE TABLE #HRM_Officers_Wise_Employee_Qualifications(
		[Qualification] [nvarchar](max) NULL,
		[Total] [bigint] NULL,
		[Organization] [varchar](20) NULL,
		[Designation] [varchar](300) NULL,
		[DesignationOrder] [int] NULL
	)

	DECLARE @sqlcmd varchar(max)

		set @sqlcmd = '
				Declare @QualificationList TABLE(
					[Qualification Name] [nvarchar](max) NULL,
					[Order] int NOT NULL
				)
				INSERT INTO @QualificationList([Qualification Name],[Order]) Values (''PhD & Above'',1),(''Master`s'',2),(''Graduate'',3),(''Diploma'',4),(''H.S.C'',5),(''S.S.C'',6)
				
				Declare  @TempTable TABLE(
					[Qualification Name] [nvarchar](max) NULL,
					[Total Employee] [bigint] NULL,
					[Designation] [varchar](300) NULL,
					[DesignationOrder] [int] NULL
				)

				INSERT INTO @TempTable([Qualification Name],[Total Employee],[Designation],[DesignationOrder])
				select case q.EquivalentOf
				When ''1'' then ''S.S.C''
				When ''2'' then ''H.S.C''
				When ''3'' then ''Graduate''
				When ''4'' then ''Master`s''
				When ''5'' then ''PhD & Above''
				When ''6'' then ''PhD & Above''
				When ''7'' then ''Diploma''
				end as Qualification,
				Count(*) as total,D.[Description],D.[Order number]
				from POWERDIVERPDB.dbo.['+@Organization+'$Employee] as e 
				Join POWERDIVERPDB.dbo.['+@Organization+'$Employee Qualification] as eq on e.[No_] = eq.[Employee No_] and e.[Employee Last Higher Education]=eq.[Qualification Code]
				join POWERDIVERPDB.dbo.['+@Organization+'$Qualification] as q on eq.[Qualification Code]=q.Code
				join POWERDIVERPDB.dbo.['+@Organization+'$Designation] D on D.[Designation Code] = e.[Designation Code] 
				where  e.Status=0
				and q.EquivalentOf !=0
				group by q.EquivalentOf,D.[Description],D.[Order number]

				INSERT INTO #HRM_Officers_Wise_Employee_Qualifications(
					[Qualification],
					[Total],
					[Organization],
					[Designation],
					[DesignationOrder]
				)
				Select A.[Qualification Name],SUM(ISNULL(R.[Total Employee],0)) as [Total Employee],'''+@Organization+''',R.[Designation],R.[DesignationOrder]
				from @QualificationList A Left Join @TempTable R ON A.[Qualification Name]=R.[Qualification Name]
				Group By A.[Qualification Name],A.[Order],R.[Designation],R.[DesignationOrder] order by A.[Order]	
			';

	exec(@sqlcmd)
	
	SELECT * FROM #HRM_Officers_Wise_Employee_Qualifications where [Designation]!=''
	--ORDER BY [PBSName],[Qualification]

END
GO
