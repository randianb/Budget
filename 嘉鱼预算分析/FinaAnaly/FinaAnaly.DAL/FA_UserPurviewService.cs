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
	public static partial class FA_UserPurviewService
	{
        public static FA_UserPurview AddFA_UserPurview(FA_UserPurview fA_UserPurview)
		{
            string sql =
				"INSERT FA_UserPurview (UPName, Remark)" +
				"VALUES (@UPName, @Remark)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UPName", fA_UserPurview.UPName),
					new SqlParameter("@Remark", fA_UserPurview.Remark)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_UserPurviewByUPID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_UserPurview(FA_UserPurview fA_UserPurview)
		{
			return DeleteFA_UserPurviewByUPID( fA_UserPurview.UPID );
		}

        public static bool DeleteFA_UserPurviewByUPID(int uPID)
		{
            string sql = "DELETE FA_UserPurview WHERE UPID = @UPID";

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
					


        public static bool ModifyFA_UserPurview(FA_UserPurview fA_UserPurview)
        {
            string sql =
                "UPDATE FA_UserPurview " +
                "SET " +
	                "UPName = @UPName, " +
	                "Remark = @Remark " +
                "WHERE UPID = @UPID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UPID", fA_UserPurview.UPID),
					new SqlParameter("@UPName", fA_UserPurview.UPName),
					new SqlParameter("@Remark", fA_UserPurview.Remark)
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


        public static DataTable GetAllFA_UserPurview()
        {
            string sqlAll = "SELECT * FROM FA_UserPurview";
			return GetFA_UserPurviewBySql( sqlAll );
        }
		

        public static FA_UserPurview GetFA_UserPurviewByUPID(int uPID)
        {
            string sql = "SELECT * FROM FA_UserPurview WHERE UPID = @UPID";

            try
            {
                SqlParameter para = new SqlParameter("@UPID", uPID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_UserPurview fA_UserPurview = new FA_UserPurview();

                    fA_UserPurview.UPID = dt.Rows[0]["UPID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["UPID"];
                    fA_UserPurview.UPName = dt.Rows[0]["UPName"] == DBNull.Value ? "" : (string)dt.Rows[0]["UPName"];
                    fA_UserPurview.Remark = dt.Rows[0]["Remark"] == DBNull.Value ? "" : (string)dt.Rows[0]["Remark"];
                    
                    return fA_UserPurview;
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
	

      

        private static DataTable GetFA_UserPurviewBySql(string safeSql)
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
		
        private static DataTable GetFA_UserPurviewBySql(string sql, params SqlParameter[] values)
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
