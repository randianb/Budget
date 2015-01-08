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
	public static partial class BG_ProBasiPerPayTwoService
	{
        public static BG_ProBasiPerPayTwo AddBG_ProBasiPerPayTwo(BG_ProBasiPerPayTwo bG_ProBasiPerPayTwo)
		{
            string sql =
				"INSERT BG_ProBasiPerPayTwo (DepID, PTYear, RetiredPerP, RetiredPubP, RetirementPerP, RetirementPubP, PTHF, PTME, PTOther, PTTitol)" +
				"VALUES (@DepID, @PTYear, @RetiredPerP, @RetiredPubP, @RetirementPerP, @RetirementPubP, @PTHF, @PTME, @PTOther, @PTTitol)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", bG_ProBasiPerPayTwo.DepID),
					new SqlParameter("@PTYear", bG_ProBasiPerPayTwo.PTYear),
					new SqlParameter("@RetiredPerP", bG_ProBasiPerPayTwo.RetiredPerP),
					new SqlParameter("@RetiredPubP", bG_ProBasiPerPayTwo.RetiredPubP),
					new SqlParameter("@RetirementPerP", bG_ProBasiPerPayTwo.RetirementPerP),
					new SqlParameter("@RetirementPubP", bG_ProBasiPerPayTwo.RetirementPubP),
					new SqlParameter("@PTHF", bG_ProBasiPerPayTwo.PTHF),
					new SqlParameter("@PTME", bG_ProBasiPerPayTwo.PTME),
					new SqlParameter("@PTOther", bG_ProBasiPerPayTwo.PTOther),
					new SqlParameter("@PTTitol", bG_ProBasiPerPayTwo.PTTitol)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_ProBasiPerPayTwoByPTID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_ProBasiPerPayTwo(BG_ProBasiPerPayTwo bG_ProBasiPerPayTwo)
		{
			return DeleteBG_ProBasiPerPayTwoByPTID( bG_ProBasiPerPayTwo.PTID );
		}

        public static bool DeleteBG_ProBasiPerPayTwoByPTID(int pTID)
		{
            string sql = "DELETE BG_ProBasiPerPayTwo WHERE PTID = @PTID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PTID", pTID)
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
					


        public static bool ModifyBG_ProBasiPerPayTwo(BG_ProBasiPerPayTwo bG_ProBasiPerPayTwo)
        {
            string sql =
                "UPDATE BG_ProBasiPerPayTwo " +
                "SET " +
	                "DepID = @DepID, " +
	                "PTYear = @PTYear, " +
	                "RetiredPerP = @RetiredPerP, " +
	                "RetiredPubP = @RetiredPubP, " +
	                "RetirementPerP = @RetirementPerP, " +
	                "RetirementPubP = @RetirementPubP, " +
	                "PTHF = @PTHF, " +
	                "PTME = @PTME, " +
	                "PTOther = @PTOther, " +
	                "PTTitol = @PTTitol " +
                "WHERE PTID = @PTID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PTID", bG_ProBasiPerPayTwo.PTID),
					new SqlParameter("@DepID", bG_ProBasiPerPayTwo.DepID),
					new SqlParameter("@PTYear", bG_ProBasiPerPayTwo.PTYear),
					new SqlParameter("@RetiredPerP", bG_ProBasiPerPayTwo.RetiredPerP),
					new SqlParameter("@RetiredPubP", bG_ProBasiPerPayTwo.RetiredPubP),
					new SqlParameter("@RetirementPerP", bG_ProBasiPerPayTwo.RetirementPerP),
					new SqlParameter("@RetirementPubP", bG_ProBasiPerPayTwo.RetirementPubP),
					new SqlParameter("@PTHF", bG_ProBasiPerPayTwo.PTHF),
					new SqlParameter("@PTME", bG_ProBasiPerPayTwo.PTME),
					new SqlParameter("@PTOther", bG_ProBasiPerPayTwo.PTOther),
					new SqlParameter("@PTTitol", bG_ProBasiPerPayTwo.PTTitol)
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


        public static DataTable GetAllBG_ProBasiPerPayTwo()
        {
            string sqlAll = "SELECT * FROM BG_ProBasiPerPayTwo";
			return GetBG_ProBasiPerPayTwoBySql( sqlAll );
        }
		

        public static BG_ProBasiPerPayTwo GetBG_ProBasiPerPayTwoByPTID(int pTID)
        {
            string sql = "SELECT * FROM BG_ProBasiPerPayTwo WHERE PTID = @PTID";

            try
            {
                SqlParameter para = new SqlParameter("@PTID", pTID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_ProBasiPerPayTwo bG_ProBasiPerPayTwo = new BG_ProBasiPerPayTwo();

                    bG_ProBasiPerPayTwo.PTID = dt.Rows[0]["PTID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PTID"];
                    bG_ProBasiPerPayTwo.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_ProBasiPerPayTwo.PTYear = dt.Rows[0]["PTYear"] == DBNull.Value ? DateTime.MinValue : (DateTime)dt.Rows[0]["PTYear"];
                    bG_ProBasiPerPayTwo.RetiredPerP = dt.Rows[0]["RetiredPerP"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["RetiredPerP"];
                    bG_ProBasiPerPayTwo.RetiredPubP = dt.Rows[0]["RetiredPubP"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["RetiredPubP"];
                    bG_ProBasiPerPayTwo.RetirementPerP = dt.Rows[0]["RetirementPerP"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["RetirementPerP"];
                    bG_ProBasiPerPayTwo.RetirementPubP = dt.Rows[0]["RetirementPubP"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["RetirementPubP"];
                    bG_ProBasiPerPayTwo.PTHF = dt.Rows[0]["PTHF"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PTHF"];
                    bG_ProBasiPerPayTwo.PTME = dt.Rows[0]["PTME"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PTME"];
                    bG_ProBasiPerPayTwo.PTOther = dt.Rows[0]["PTOther"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PTOther"];
                    bG_ProBasiPerPayTwo.PTTitol = dt.Rows[0]["PTTitol"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PTTitol"];
                    
                    return bG_ProBasiPerPayTwo;
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
	

      

        private static DataTable GetBG_ProBasiPerPayTwoBySql(string safeSql)
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
		
        private static DataTable GetBG_ProBasiPerPayTwoBySql(string sql, params SqlParameter[] values)
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
