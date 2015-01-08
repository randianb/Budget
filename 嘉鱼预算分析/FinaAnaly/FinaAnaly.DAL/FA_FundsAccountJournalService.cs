//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-08-22 10:36:36
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FinaAnaly.Model;

namespace FinaAnaly.DAL
{
	public static partial class FA_FundsAccountJournalService
	{
        public static FA_FundsAccountJournal AddFA_FundsAccountJournal(FA_FundsAccountJournal fA_FundsAccountJournal)
		{
            string sql =
				"INSERT FA_FundsAccountJournal (BXRQ, BM, ZFLX, ZY, JE, FJZS, BZ)" +
				"VALUES (@BXRQ, @BM, @ZFLX, @ZY, @JE, @FJZS, @BZ)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BXRQ", fA_FundsAccountJournal.BXRQ),
					new SqlParameter("@BM", fA_FundsAccountJournal.BM),
					new SqlParameter("@ZFLX", fA_FundsAccountJournal.ZFLX),
					new SqlParameter("@ZY", fA_FundsAccountJournal.ZY),
					new SqlParameter("@JE", fA_FundsAccountJournal.JE),
					new SqlParameter("@FJZS", fA_FundsAccountJournal.FJZS),
					new SqlParameter("@BZ", fA_FundsAccountJournal.BZ)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_FundsAccountJournalByFAUDID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_FundsAccountJournal(FA_FundsAccountJournal fA_FundsAccountJournal)
		{
			return DeleteFA_FundsAccountJournalByFAUDID( fA_FundsAccountJournal.FAUDID );
		}

        public static bool DeleteFA_FundsAccountJournalByFAUDID(int fAUDID)
		{
            string sql = "DELETE FA_FundsAccountJournal WHERE FAUDID = @FAUDID";

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
					


        public static bool ModifyFA_FundsAccountJournal(FA_FundsAccountJournal fA_FundsAccountJournal)
        {
            string sql =
                "UPDATE FA_FundsAccountJournal " +
                "SET " +
	                "BXRQ = @BXRQ, " +
	                "BM = @BM, " +
	                "ZFLX = @ZFLX, " +
	                "ZY = @ZY, " +
	                "JE = @JE, " +
	                "FJZS = @FJZS, " +
	                "BZ = @BZ " +
                "WHERE FAUDID = @FAUDID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@FAUDID", fA_FundsAccountJournal.FAUDID),
					new SqlParameter("@BXRQ", fA_FundsAccountJournal.BXRQ),
					new SqlParameter("@BM", fA_FundsAccountJournal.BM),
					new SqlParameter("@ZFLX", fA_FundsAccountJournal.ZFLX),
					new SqlParameter("@ZY", fA_FundsAccountJournal.ZY),
					new SqlParameter("@JE", fA_FundsAccountJournal.JE),
					new SqlParameter("@FJZS", fA_FundsAccountJournal.FJZS),
					new SqlParameter("@BZ", fA_FundsAccountJournal.BZ)
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


        public static DataTable GetAllFA_FundsAccountJournal()
        {
            string sqlAll = "SELECT * FROM FA_FundsAccountJournal";
			return GetFA_FundsAccountJournalBySql( sqlAll );
        }
		

        public static FA_FundsAccountJournal GetFA_FundsAccountJournalByFAUDID(int fAUDID)
        {
            string sql = "SELECT * FROM FA_FundsAccountJournal WHERE FAUDID = @FAUDID";

            try
            {
                SqlParameter para = new SqlParameter("@FAUDID", fAUDID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_FundsAccountJournal fA_FundsAccountJournal = new FA_FundsAccountJournal();

                    fA_FundsAccountJournal.FAUDID = dt.Rows[0]["FAUDID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["FAUDID"];
                    fA_FundsAccountJournal.BXRQ = dt.Rows[0]["BXRQ"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["BXRQ"];
                    fA_FundsAccountJournal.BM = dt.Rows[0]["BM"] == DBNull.Value ? "" : (string)dt.Rows[0]["BM"];
                    fA_FundsAccountJournal.ZFLX = dt.Rows[0]["ZFLX"] == DBNull.Value ? "" : (string)dt.Rows[0]["ZFLX"];
                    fA_FundsAccountJournal.ZY = dt.Rows[0]["ZY"] == DBNull.Value ? "" : (string)dt.Rows[0]["ZY"];
                    fA_FundsAccountJournal.JE = dt.Rows[0]["JE"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["JE"];
                    fA_FundsAccountJournal.FJZS = dt.Rows[0]["FJZS"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["FJZS"];
                    fA_FundsAccountJournal.BZ = dt.Rows[0]["BZ"] == DBNull.Value ? "" : (string)dt.Rows[0]["BZ"];
                    
                    return fA_FundsAccountJournal;
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
	

      

        private static DataTable GetFA_FundsAccountJournalBySql(string safeSql)
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
		
        private static DataTable GetFA_FundsAccountJournalBySql(string sql, params SqlParameter[] values)
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
