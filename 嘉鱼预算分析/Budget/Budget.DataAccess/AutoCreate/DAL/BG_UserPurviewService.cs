//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_UserPurviewService
	{
        public static BG_UserPurview AddBG_UserPurview(BG_UserPurview bG_UserPurview)
		{
            string sql =
				"INSERT BG_UserPurview (UPName, Remark)" +
				"VALUES (@UPName, @Remark)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UPName", bG_UserPurview.UPName),
					new SqlParameter("@Remark", bG_UserPurview.Remark)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_UserPurviewByUPID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_UserPurview(BG_UserPurview bG_UserPurview)
		{
			return DeleteBG_UserPurviewByUPID( bG_UserPurview.UPID );
		}

        public static bool DeleteBG_UserPurviewByUPID(int uPID)
		{
            string sql = "DELETE BG_UserPurview WHERE UPID = @UPID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UPID", uPID)
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
					


        public static bool ModifyBG_UserPurview(BG_UserPurview bG_UserPurview)
        {
            string sql =
                "UPDATE BG_UserPurview " +
                "SET " +
	                "UPName = @UPName, " +
	                "Remark = @Remark " +
                "WHERE UPID = @UPID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UPID", bG_UserPurview.UPID),
					new SqlParameter("@UPName", bG_UserPurview.UPName),
					new SqlParameter("@Remark", bG_UserPurview.Remark)
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


        public static DataTable GetAllBG_UserPurview()
        {
            string sqlAll = "SELECT * FROM BG_UserPurview";
			return GetBG_UserPurviewBySql( sqlAll );
        }
		

        public static BG_UserPurview GetBG_UserPurviewByUPID(int uPID)
        {
            string sql = "SELECT * FROM BG_UserPurview WHERE UPID = @UPID";

            try
            {
                SqlParameter para = new SqlParameter("@UPID", uPID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_UserPurview bG_UserPurview = new BG_UserPurview();

                    bG_UserPurview.UPID = dt.Rows[0]["UPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["UPID"];
                    bG_UserPurview.UPName = dt.Rows[0]["UPName"] == DBNull.Value ? "" : (string)dt.Rows[0]["UPName"];
                    bG_UserPurview.Remark = dt.Rows[0]["Remark"] == DBNull.Value ? "" : (string)dt.Rows[0]["Remark"];
                    
                    return bG_UserPurview;
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
	

      

        private static DataTable GetBG_UserPurviewBySql(string safeSql)
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
		
        private static DataTable GetBG_UserPurviewBySql(string sql, params SqlParameter[] values)
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
