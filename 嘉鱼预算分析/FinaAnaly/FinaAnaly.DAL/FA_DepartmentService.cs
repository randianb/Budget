//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-21 11:50:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FinaAnaly.Model;

namespace FinaAnaly.DAL
{
	public static partial class FA_DepartmentService
	{
        public static FA_Department AddFA_Department(FA_Department fA_Department)
		{
            string sql =
				"INSERT FA_Department (DepLev, FaDepID, DepCode, DepName, DepQua, DepSta, DepRem)" +
				"VALUES (@DepLev, @FaDepID, @DepCode, @DepName, @DepQua, @DepSta, @DepRem)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepLev", fA_Department.DepLev),
					new SqlParameter("@FaDepID", fA_Department.FaDepID),
					new SqlParameter("@DepCode", fA_Department.DepCode),
					new SqlParameter("@DepName", fA_Department.DepName),
					new SqlParameter("@DepQua", fA_Department.DepQua),
					new SqlParameter("@DepSta", fA_Department.DepSta),
					new SqlParameter("@DepRem", fA_Department.DepRem)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_DepartmentByDepID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_Department(FA_Department fA_Department)
		{
			return DeleteFA_DepartmentByDepID( fA_Department.DepID );
		}

        public static bool DeleteFA_DepartmentByDepID(int depID)
		{
            string sql = "DELETE FA_Department WHERE DepID = @DepID";

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
					


        public static bool ModifyFA_Department(FA_Department fA_Department)
        {
            string sql =
                "UPDATE FA_Department " +
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
					new SqlParameter("@DepID", fA_Department.DepID),
					new SqlParameter("@DepLev", fA_Department.DepLev),
					new SqlParameter("@FaDepID", fA_Department.FaDepID),
					new SqlParameter("@DepCode", fA_Department.DepCode),
					new SqlParameter("@DepName", fA_Department.DepName),
					new SqlParameter("@DepQua", fA_Department.DepQua),
					new SqlParameter("@DepSta", fA_Department.DepSta),
					new SqlParameter("@DepRem", fA_Department.DepRem)
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


        public static DataTable GetAllFA_Department()
        {
            string sqlAll = "SELECT * FROM FA_Department";
			return GetFA_DepartmentBySql( sqlAll );
        }
		

        public static FA_Department GetFA_DepartmentByDepID(int depID)
        {
            string sql = "SELECT * FROM FA_Department WHERE DepID = @DepID";

            try
            {
                SqlParameter para = new SqlParameter("@DepID", depID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
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
	

      

        private static DataTable GetFA_DepartmentBySql(string safeSql)
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
		
        private static DataTable GetFA_DepartmentBySql(string sql, params SqlParameter[] values)
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
