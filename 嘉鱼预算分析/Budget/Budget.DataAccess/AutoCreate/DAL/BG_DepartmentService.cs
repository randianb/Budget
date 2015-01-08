//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:02
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_DepartmentService
	{
        public static BG_Department AddBG_Department(BG_Department bG_Department)
		{
            string sql =
				"INSERT BG_Department (DepLev, FaDepID, DepCode, DepName, DepQua, DepSta, DepRem)" +
				"VALUES (@DepLev, @FaDepID, @DepCode, @DepName, @DepQua, @DepSta, @DepRem)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepLev", bG_Department.DepLev),
					new SqlParameter("@FaDepID", bG_Department.FaDepID),
					new SqlParameter("@DepCode", bG_Department.DepCode),
					new SqlParameter("@DepName", bG_Department.DepName),
					new SqlParameter("@DepQua", bG_Department.DepQua),
					new SqlParameter("@DepSta", bG_Department.DepSta),
					new SqlParameter("@DepRem", bG_Department.DepRem)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_DepartmentByDepID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_Department(BG_Department bG_Department)
		{
			return DeleteBG_DepartmentByDepID( bG_Department.DepID );
		}

        public static bool DeleteBG_DepartmentByDepID(int depID)
		{
            string sql = "DELETE BG_Department WHERE DepID = @DepID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", depID)
				};
			
                int t = DBUnity.ExecuteNonQuery(CommandType.Text, sql, para);
                
                if(t>0)
                {
                    return true;
                }
                else
                {
                    return false;    
                }
            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
				throw e;
            }
		}
					


        public static bool ModifyBG_Department(BG_Department bG_Department)
        {
            string sql =
                "UPDATE BG_Department " +
                "SET " +
	                "DepLev = @DepLev, " +
	                "FaDepID = @FaDepID, " +
	                "DepCode = @DepCode, " +
	                "DepName = @DepName, " +
	                "DepQua = @DepQua, " +
	                "DepSta = @DepSta, " +
	                "DepRem = @DepRem " +
                "WHERE DepID = @DepID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", bG_Department.DepID),
					new SqlParameter("@DepLev", bG_Department.DepLev),
					new SqlParameter("@FaDepID", bG_Department.FaDepID),
					new SqlParameter("@DepCode", bG_Department.DepCode),
					new SqlParameter("@DepName", bG_Department.DepName),
					new SqlParameter("@DepQua", bG_Department.DepQua),
					new SqlParameter("@DepSta", bG_Department.DepSta),
					new SqlParameter("@DepRem", bG_Department.DepRem)
				};

                int t = DBUnity.ExecuteNonQuery(CommandType.Text, sql, para);
                if(t>0)
                {
                    return true;
                }
                else
                {
                    return false;    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
				throw e;
            }

        }		


        public static DataTable GetAllBG_Department()
        {
            string sqlAll = "SELECT * FROM BG_Department";
			return GetBG_DepartmentBySql( sqlAll );
        }
		

        public static BG_Department GetBG_DepartmentByDepID(int depID)
        {
            string sql = "SELECT * FROM BG_Department WHERE DepID = @DepID";

            try
            {
                SqlParameter para = new SqlParameter("@DepID", depID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_Department bG_Department = new BG_Department();

                    bG_Department.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_Department.DepLev = dt.Rows[0]["DepLev"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepLev"];
                    bG_Department.FaDepID = dt.Rows[0]["FaDepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["FaDepID"];
                    bG_Department.DepCode = dt.Rows[0]["DepCode"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepCode"];
                    bG_Department.DepName = dt.Rows[0]["DepName"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepName"];
                    bG_Department.DepQua = dt.Rows[0]["DepQua"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepQua"];
                    bG_Department.DepSta = dt.Rows[0]["DepSta"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepSta"];
                    bG_Department.DepRem = dt.Rows[0]["DepRem"] == DBNull.Value ? "" : (string)dt.Rows[0]["DepRem"];
                    
                    return bG_Department;
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
	

      

        private static DataTable GetBG_DepartmentBySql(string safeSql)
        {

			try
			{
				DataTable dt = DBUnity.AdapterToTab(safeSql);
                return dt;
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }
		
        private static DataTable GetBG_DepartmentBySql(string sql, params SqlParameter[] values)
        {

			try
			{
				DataTable dt = DBUnity.AdapterToTab(sql, values);
                return dt;
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
			
        }
		
	}
}
