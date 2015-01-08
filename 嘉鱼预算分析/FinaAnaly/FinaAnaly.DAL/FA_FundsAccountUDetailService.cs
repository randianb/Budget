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
	public static partial class FA_FundsAccountUDetailService
	{
        public static FA_FundsAccountUDetail AddFA_FundsAccountUDetail(FA_FundsAccountUDetail fA_FundsAccountUDetail)
		{
            string sql =
				"INSERT FA_FundsAccountUDetail (DEPARTMENT, ED, TZ, QZXJ, XJJH, XJKYED, KYYE, ZEDB, BZ)" +
				"VALUES (@DEPARTMENT, @ED, @TZ, @QZXJ, @XJJH, @XJKYED, @KYYE, @ZEDB, @BZ)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DEPARTMENT", fA_FundsAccountUDetail.DEPARTMENT),
					new SqlParameter("@ED", fA_FundsAccountUDetail.ED),
					new SqlParameter("@TZ", fA_FundsAccountUDetail.TZ),
					new SqlParameter("@QZXJ", fA_FundsAccountUDetail.QZXJ),
					new SqlParameter("@XJJH", fA_FundsAccountUDetail.XJJH),
					new SqlParameter("@XJKYED", fA_FundsAccountUDetail.XJKYED),
					new SqlParameter("@KYYE", fA_FundsAccountUDetail.KYYE),
					new SqlParameter("@ZEDB", fA_FundsAccountUDetail.ZEDB),
					new SqlParameter("@BZ", fA_FundsAccountUDetail.BZ)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_FundsAccountUDetailByFAUDID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_FundsAccountUDetail(FA_FundsAccountUDetail fA_FundsAccountUDetail)
		{
			return DeleteFA_FundsAccountUDetailByFAUDID( fA_FundsAccountUDetail.FAUDID );
		}

        public static bool DeleteFA_FundsAccountUDetailByFAUDID(int fAUDID)
		{
            string sql = "DELETE FA_FundsAccountUDetail WHERE FAUDID = @FAUDID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@FAUDID", fAUDID)
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
					


        public static bool ModifyFA_FundsAccountUDetail(FA_FundsAccountUDetail fA_FundsAccountUDetail)
        {
            string sql =
                "UPDATE FA_FundsAccountUDetail " +
                "SET " +
	                "DEPARTMENT = @DEPARTMENT, " +
	                "ED = @ED, " +
	                "TZ = @TZ, " +
	                "QZXJ = @QZXJ, " +
	                "XJJH = @XJJH, " +
	                "XJKYED = @XJKYED, " +
	                "KYYE = @KYYE, " +
	                "ZEDB = @ZEDB, " +
	                "BZ = @BZ " +
                "WHERE FAUDID = @FAUDID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@FAUDID", fA_FundsAccountUDetail.FAUDID),
					new SqlParameter("@DEPARTMENT", fA_FundsAccountUDetail.DEPARTMENT),
					new SqlParameter("@ED", fA_FundsAccountUDetail.ED),
					new SqlParameter("@TZ", fA_FundsAccountUDetail.TZ),
					new SqlParameter("@QZXJ", fA_FundsAccountUDetail.QZXJ),
					new SqlParameter("@XJJH", fA_FundsAccountUDetail.XJJH),
					new SqlParameter("@XJKYED", fA_FundsAccountUDetail.XJKYED),
					new SqlParameter("@KYYE", fA_FundsAccountUDetail.KYYE),
					new SqlParameter("@ZEDB", fA_FundsAccountUDetail.ZEDB),
					new SqlParameter("@BZ", fA_FundsAccountUDetail.BZ)
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


        public static DataTable GetAllFA_FundsAccountUDetail()
        {
            string sqlAll = "SELECT * FROM FA_FundsAccountUDetail";
			return GetFA_FundsAccountUDetailBySql( sqlAll );
        }
		

        public static FA_FundsAccountUDetail GetFA_FundsAccountUDetailByFAUDID(int fAUDID)
        {
            string sql = "SELECT * FROM FA_FundsAccountUDetail WHERE FAUDID = @FAUDID";

            try
            {
                SqlParameter para = new SqlParameter("@FAUDID", fAUDID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_FundsAccountUDetail fA_FundsAccountUDetail = new FA_FundsAccountUDetail();

                    fA_FundsAccountUDetail.FAUDID = dt.Rows[0]["FAUDID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["FAUDID"];
                    fA_FundsAccountUDetail.DEPARTMENT = dt.Rows[0]["DEPARTMENT"] == DBNull.Value ? "" : (string)dt.Rows[0]["DEPARTMENT"];
                    fA_FundsAccountUDetail.ED = dt.Rows[0]["ED"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ED"];
                    fA_FundsAccountUDetail.TZ = dt.Rows[0]["TZ"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["TZ"];
                    fA_FundsAccountUDetail.QZXJ = dt.Rows[0]["QZXJ"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["QZXJ"];
                    fA_FundsAccountUDetail.XJJH = dt.Rows[0]["XJJH"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["XJJH"];
                    fA_FundsAccountUDetail.XJKYED = dt.Rows[0]["XJKYED"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["XJKYED"];
                    fA_FundsAccountUDetail.KYYE = dt.Rows[0]["KYYE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["KYYE"];
                    fA_FundsAccountUDetail.ZEDB = dt.Rows[0]["ZEDB"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["ZEDB"];
                    fA_FundsAccountUDetail.BZ = dt.Rows[0]["BZ"] == DBNull.Value ? "" : (string)dt.Rows[0]["BZ"];
                    
                    return fA_FundsAccountUDetail;
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
	

      

        private static DataTable GetFA_FundsAccountUDetailBySql(string safeSql)
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
		
        private static DataTable GetFA_FundsAccountUDetailBySql(string sql, params SqlParameter[] values)
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
