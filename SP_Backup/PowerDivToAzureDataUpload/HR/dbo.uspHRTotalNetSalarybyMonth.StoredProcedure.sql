DROP PROCEDURE IF EXISTS [dbo].[uspHRTotalNetSalarybyMonth]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspHRTotalNetSalarybyMonth]
@Organization varchar(20)
AS
/*Testing
exec uspHRTotalNetSalarybyMonth 'PGCB'
exec uspHRTotalNetSalarybyMonth 'BREB'
exec uspHRTotalNetSalarybyMonth 'PBS'
*/
BEGIN
CREATE TABLE #MonthList(		
	[MonthName] [nvarchar](max) NULL,
	[sequenceNo] [bigint] NULL
)

Declare @monthCount int = 0
while @monthCount <=11
begin
	INSERT INTO #MonthList([MonthName],[sequenceNo])
	Select FORMAT(CAST(DATEADD(m, -@monthCount, GetDate()) as date), 'MMMM, yyyy') as [MonthName],@monthCount
	Set @monthCount=@monthCount+1
end

	CREATE TABLE #HRF_Total_Net_Salary_by_Month(
		[Salary_Date] [nvarchar](max) NULL,
		[Sum_Total_Salary] [float] NULL,
		[sequenceNo] [bigint] NULL,
		[Organization] [varchar](20) NULL,
		[OfficeName] [varchar](300) NULL,
		[PBSName] [varchar](300) NULL
	)
	Declare @OfficeCategory  varchar(10)
		DECLARE @sqlcmd varchar(max)

		set @sqlcmd = '
					Declare  @TempTable TABLE(
						[Salary_Date] [nvarchar](max) NULL,
						[Sum_Total_Salary] [float] NULL,
						[sequenceNo] [bigint] NULL
					)
					DECLARE @count INT;
					SET @count = 0;
					WHILE @count<= 11
					BEGIN
					INSERT INTO @TempTable ([Salary_Date],[Sum_Total_Salary],[sequenceNo])
					select FORMAT(CAST(DATEADD(m, -@count, GetDate()) as date), ''MMMM, yyyy'') as [MonthName] ,ISNULL(SUM(Net_Pay),0) as total,@count
					from POWERDIVERPDB.dbo.['+@Organization+'$Report_Salary_Statement] as s
					Join POWERDIVERPDB.dbo.['+@Organization+'$Employee] as e on s.[Employee_ID]=e.[No_]
					Join [POWERDIVERPDB].[dbo].['+@Organization+'$Office_Master] as o on o.[Office_Code] = e.[Office Code]
					where s.Year=Year(CAST(DATEADD(m, -@count, GetDate()) as date))
					and s.Month=Month(CAST(DATEADD(m, -@count, GetDate()) as date))-1
					SET @count = @count + 1;
					END;
					Insert into #HRF_Total_Net_Salary_by_Month([Salary_Date],[Sum_Total_Salary],[sequenceNo],[Organization])
					Select A.[MonthName],SUM(ISNULL(R.Sum_Total_Salary,0)) as Total,AVG(A.[sequenceNo]) as [sequenceNo],'''+@Organization+'''
					From 
					#MonthList A 
					Left Join @TempTable R ON A.[MonthName] Collate SQL_Latin1_General_CP1_CI_AS =R.[Salary_Date]
					Group by A.[MonthName]
					Order BY [sequenceNo]
			';	

	exec(@sqlcmd)

		Select * from #HRF_Total_Net_Salary_by_Month
		Order By [Organization],[OfficeName],[PBSName],[sequenceNo]

END
GO
