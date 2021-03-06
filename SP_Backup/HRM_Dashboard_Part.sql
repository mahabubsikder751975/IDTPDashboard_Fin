USE [PowerBIDB]
GO
/****** Object:  StoredProcedure [dbo].[HRM_Dashboard_Part1]    Script Date: 06-11-2021 11:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[HRM_Dashboard_Part1]
	@Organization nvarchar(20)
	
AS
BEGIN
SET NOCOUNT ON;
	Declare @strSQL VarChar (MAX)
	Declare @WhereCondition VarChar (100);

	SET @WhereCondition=' Where [Organization]='''+@Organization+''' '

	IF (@Organization='IDTP') BEGIN
		SET @strSQL = 
		' SELECT [Post Type],Sum([Present]) as [Present],Sum([Absent]) as [Absent],avg([SequenceNo]) as [SequenceNo], '''+@Organization+''' as [Organization],'' '' as [OfficeName],'' '' as [PBSName] FROM [PowerBIDB].[dbo].[HRM_OfficersStaff_Wise_Employee_Attendance] Group By [Post Type]'+
		' Select Sum([OfficersOnLeave]) as [OfficersOnLeave],Sum([StaffOnLeave]) as [StaffOnLeave],avg([SequenceNo]) as [SequenceNo], '''+@Organization+''' as [Organization],[Organization] as [OfficeName],'' '' as [PBSName] from [PowerBIDB].[dbo].[HRM_OfficersStaff_Wise_Employee_On_Leave_Today] Group By [Organization] '+
		' Select [Post Type],Sum([Sanction Posts]) as [Sanction Posts],Sum([Filled Posts]) as [Filled Posts],Sum([Vacant Posts]) as [Vacant Posts], '''+@Organization+''' as [Organization],'' '' as [OfficeName],'' '' as [PBSName] from [PowerBIDB].[dbo].[HRM_OfficersStaff_Wise_FIll_Vs_Vacant_Post] Group By [Post Type]'+
		' Select Sum([Count_]) as [Count_],avg([SequenceNo]) as [SequenceNo],[MonthName], '''+@Organization+''' as [Organization],'' '' as [OfficeName],'' '' as [PBSName]  from [PowerBIDB].[dbo].[HRM_Upcoming_Retirement] Group By [MonthName] Order By [SequenceNo]'+
		' Select [Score Range],Sum([No. of Officers]) as [No. of Officers],avg([SequenceNo]) as [SequenceNo], '''+@Organization+''' as [Organization],'' '' as [OfficeName],'' '' as [PBSName] from [PowerBIDB].[dbo].[HRM_Catg_Officers_Employee_Performance] Group By [Score Range]'+
		' Select Top(7) [Employee_Job_Status_Code],SUM([Sum_Total_Employee]) as [Sum_Total_Employee], '''+@Organization+''' as [Organization] from [PowerBIDB].[dbo].[HRM_Employee_Job_Status] Group By [Employee_Job_Status_Code]'+
		' Select [Qualification],Sum([Total]) as [Total], '''+@Organization+''' as [Organization] from [PowerBIDB].[dbo].[HRM_Officers_Wise_Employee_Qualifications] Group By [Qualification]'+
		' Select [Organization],Sum([retirement]) as [retirement],Sum([newemployee]) as [newemployee],'' '' as [OfficeName],'' '' as [PBSName] from [PowerBIDB].[dbo].[HRM_Retirement_vs_NewEmployee] Group By [Organization]'+
		' Select Sum([Count_]) as [Count_], [Organization] from [PowerBIDB].[dbo].[HRM_Upcoming_Retirement] Group By [Organization]'+
		' Select Sum([TotalTour]) as [TotalTour], [Organization] from [PowerBIDB].[dbo].[HRM_ForeignTour_Organization_Wise] Group By [Organization]'+
		' Select Sum([Sanction Posts]) as [Sanction Posts],Sum([Filled Posts]) as [Filled Posts],Sum([Vacant Posts]) as [Vacant Posts], [Organization] from [PowerBIDB].[dbo].[HRM_OfficersStaff_Wise_FIll_Vs_Vacant_Post] Group By [Organization]'+
		' Select Sum([totalemployee]) as [totalemployee]  from [PowerBIDB].[dbo].[HRM_Total_Employee]'+
		' Select Sum([TotalTour]) as [TotalTour],[TourCategory] from [PowerBIDB].[dbo].[HRM_ForeignTour_Category_Wise] Group By [TourCategory]'+
		' Select Sum([TotalTour]) as [TotalTour],[TourPurpose],avg([Order]) as [Order] from [PowerBIDB].[dbo].[HRM_ForeignTour_Purpose_Wise_Official] Group By [TourPurpose] Order by [Order]'+
		' Select Sum([TotalTour]) as [TotalTour],[TourPurpose],avg([Order]) as [Order] from [PowerBIDB].[dbo].[HRM_ForeignTour_Purpose_Wise_Personal] Group By [TourPurpose]  Order by [Order]'+
		' Select Sum([totalemployee]) as [totalemployee], [Organization] from [PowerBIDB].[dbo].[HRM_Total_Employee] Group By [Organization]'+
		' Select Sum([TotalSalary]) as [TotalSalary], [Organization] from [PowerBIDB].[dbo].[HRM_Utility_wise_Last_Fiscal_Year_Salary] Where [Organization]!=''PBS''  Group By [Organization]'+
		' Select Sum([EmpQuantity]) as [EmpQuantity],[PostType] from [PowerBIDB].[dbo].[HRM_Officer_Staff_Wise_Upcoming_EmpQuantity] Group By [PostType]'
		
		

	END
	ELSE BEGIN
		SET @strSQL = 
		' SELECT * FROM [PowerBIDB].[dbo].[HRM_OfficersStaff_Wise_Employee_Attendance] '+@WhereCondition+
		' Select * from [PowerBIDB].[dbo].[HRM_OfficersStaff_Wise_Employee_On_Leave_Today]'+@WhereCondition+
		' Select * from [PowerBIDB].[dbo].[HRM_OfficersStaff_Wise_FIll_Vs_Vacant_Post]'+@WhereCondition+
		' Select * from [PowerBIDB].[dbo].[HRM_Upcoming_Retirement]'+@WhereCondition+
		' Select * from [PowerBIDB].[dbo].[HRM_Catg_Officers_Employee_Performance]'+@WhereCondition+
		' Select [Employee_Job_Status_Code],SUM([Sum_Total_Employee]) as [Sum_Total_Employee] from [PowerBIDB].[dbo].[HRM_Employee_Job_Status]'+@WhereCondition+' Group By [Employee_Job_Status_Code]'+
		' Select [Qualification],Sum([Total]) as [Total] from [PowerBIDB].[dbo].[HRM_Officers_Wise_Employee_Qualifications]'+@WhereCondition+' Group By [Qualification]'+

		'DROP TABLE IF EXISTS   #REvsNE
			CREATE TABLE #REvsNE(
				[Type] [varchar](300) NULL,
				[TotalNumberOfUsers] [bigint] NULL
			)
		insert into #REvsNE([Type],[TotalNumberOfUsers])
			Select ''Retirement'',retirement
			from [PowerBIDB].[dbo].[HRM_Retirement_vs_NewEmployee]  Where [Organization]= '''+@Organization+'''
		insert into #REvsNE([Type],[TotalNumberOfUsers])
			Select ''New Employee'',newemployee
			from [PowerBIDB].[dbo].[HRM_Retirement_vs_NewEmployee]  Where [Organization]= '''+@Organization+'''  
		Select [Type] as [Organization],[TotalNumberOfUsers] as [newemployee],0 as [retirement],'' '' as [OfficeName],'' '' as [PBSName] From #REvsNE  '+

		' Select Sum([Count_]) as [Count_], [Organization] from [PowerBIDB].[dbo].[HRM_Upcoming_Retirement] Group By [Organization]'+
		' Select Sum([TotalTour]) as [TotalTour], [Organization] from [PowerBIDB].[dbo].[HRM_ForeignTour_Organization_Wise] Group By [Organization]'+
		' Select Sum([Sanction Posts]) as [Sanction Posts],Sum([Filled Posts]) as [Filled Posts],Sum([Vacant Posts]) as [Vacant Posts], [Organization] from [PowerBIDB].[dbo].[HRM_OfficersStaff_Wise_FIll_Vs_Vacant_Post] Group By [Organization]'+
		' Select Sum([totalemployee]) as [totalemployee] from [PowerBIDB].[dbo].[HRM_Total_Employee]'+@WhereCondition+
		' Select [TotalTour],[TourCategory] from [PowerBIDB].[dbo].[HRM_ForeignTour_Category_Wise]'+@WhereCondition+
		' Select [TotalTour],[TourPurpose],[Order] from [PowerBIDB].[dbo].[HRM_ForeignTour_Purpose_Wise_Official]'+@WhereCondition+
		' Select [TotalTour],[TourPurpose],[Order] from [PowerBIDB].[dbo].[HRM_ForeignTour_Purpose_Wise_Personal]'+@WhereCondition+
		' Select Sum([totalemployee]) as [totalemployee], [Organization] from [PowerBIDB].[dbo].[HRM_Total_Employee] Group By [Organization]'+
		' Select Sum([TotalSalary]) as [TotalSalary], [Organization] from [PowerBIDB].[dbo].[HRM_Utility_wise_Last_Fiscal_Year_Salary] Group By [Organization]'+
		' Select Sum([EmpQuantity]) as [EmpQuantity],[PostType] from [PowerBIDB].[dbo].[HRM_Officer_Staff_Wise_Upcoming_EmpQuantity]'+@WhereCondition+'  Group By [PostType]'
		
		
	END
	EXEC(@strSQL)
END;

--[HRM_Dashboard_Part1] 'APSCL'
--[HRM_Dashboard_Part1] 'BPDB'
/*
[HRM_Dashboard_Part1] 'IDTP'
*/
