using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using FinaAnaly.Model;
using System.Data.SqlClient;

namespace FinaAnaly.DAL
{
   public static partial  class FA_DepartmentService
    {
       /// <summary>
       /// 获取部门分页
       /// </summary>
       /// <param name="pageSize"></param>
       /// <param name="pageIndex"></param>
       /// <param name="RecordCount"></param>
        /// <returns>DataTable</returns>
       public static DataTable GetDepartPager(int pageSize, int pageIndex, out int RecordCount)
       {
           DataTable dt = null;
           RecordCount = 0;
           string sqlStr = "select * from FA_Department";
           try
           {
               string sql_bc = "select count(*) from FA_Department";
               string CountStr = DBUnity.ExecuteScalar(CommandType.Text, sql_bc, null);
               RecordCount = common.IntSafeConvert(CountStr);
               dt = DBUnity.GetAspNetPager(sqlStr, pageIndex, pageSize);
           }
           catch (Exception e)
           {
               Log.WriteLog(e.Message, "FA_DepartmentService--GetDepartPager");
           }
           return dt;
       }



       public static FA_Department GetXPayIncomeByDepName(string depname)
       {
           string sql = "SELECT * FROM FA_Department WHERE DepName = @DepName";

           try
           {
               SqlParameter para = new SqlParameter("@DepName", depname);
               DataTable dt = DBUnity.AdapterToTab(sql, para);

               if (dt.Rows.Count > 0)
               {
                   FA_Department fA_Department = new FA_Department();

                   fA_Department.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                   fA_Department.DepLev = dt.Rows[0]["DepLev"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepLev"];
                   fA_Department.FaDepID = dt.Rows[0]["FaDepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["FaDepID"];
                   fA_Department.DepCode = dt.Rows[0]["DepCode"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepCode"];
                   fA_Department.DepName = dt.Rows[0]["DepName"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepName"];
                   fA_Department.DepQua = dt.Rows[0]["DepQua"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepQua"];
                   fA_Department.DepSta = dt.Rows[0]["DepSta"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepSta"];
                   fA_Department.DepRem = dt.Rows[0]["DepRem"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepRem"];

                   return fA_Department;
               }
               else
               {
                   return null;
               }
           }
           catch (Exception e)
           {
               Console.WriteLine(e.Message);
               throw e;
           }
       }
    }
}
