using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.Web.Helper
{
    public static class QueryHelper
    {
        public static string SqlSelectQuery(string[] columns,string tableName,string[] organizations)
        {
            var query = string.Empty;
            switch (tableName)
            {
                case "[PowerBIDB].[dbo].[HRM_OfficersStaff_Wise_FIll_Vs_Vacant_Post]":
                    query = QueryFillVacentPost(GetColumns(columns), string.Format("'{0}'", string.Join("','", organizations.Select(i => i.Replace("'", "''")))));
                    break;
                case "[PowerBIDB].[dbo].[Financial_Position]":
                    query = QueryFinancialPosition(string.Format("'{0}'", string.Join("','", columns.Select(i => i.Replace("'", "''")))), string.Format("'{0}'", string.Join("','", organizations.Select(i => i.Replace("'", "''")))));
                    break;

            }
            return query;
        }

        private static string QueryFillVacentPost(string columns, string organizations)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select ParticularName = B.[Key],ParticularValue = B.[Value] From  (Select ");
            sb.Append(columns);
            sb.Append(" from [PowerBIDB].[dbo].[HRM_OfficersStaff_Wise_FIll_Vs_Vacant_Post] " );
            sb.Append("WHERE Organization IN (" + organizations + ")");
            sb.Append(@") A

         Cross Apply(Select *
                From  OpenJson((Select A.* For JSON Path, Without_Array_Wrapper))
                Where[Key] not in ('ID', 'Other', 'Columns', 'ToExclude')
             ) B");

            return sb.ToString();
        }

        private static string QueryFinancialPosition(string columns, string organizations)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select AccountCategory AS ParticularName,SUM(Value) AS ParticularValue from [PowerBIDB].[dbo].[Financial_Position] WHERE AccountCategory IN ("+columns+") AND Organization IN (" + organizations + ") Group by AccountCategory");                     
            return sb.ToString();
        }

        private static string GetColumns(string[] columns)
        {
            var sb = new StringBuilder();
            foreach (string column in columns)
            {
                sb.Append("Sum([" + column + "]) as [" + column + "],");
            }

            return sb.ToString().Remove(sb.Length - 1);
        }
    }
}
