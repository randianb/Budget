//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:44
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_PayWelSupplyService
	{
        public static BG_PayWelSupply AddBG_PayWelSupply(BG_PayWelSupply bG_PayWelSupply)
		{
            string sql =
				"INSERT BG_PayWelSupply (GSEYear, DepID, GSETotal, OffSubTot, OffPerPart, OffPubPart, EbbSubTot, EbbPerPart, EbbPubPart, GSEHouPro, GSEMedChar, LifeAllo, GSEOther)" +
				"VALUES (@GSEYear, @DepID, @GSETotal, @OffSubTot, @OffPerPart, @OffPubPart, @EbbSubTot, @EbbPerPart, @EbbPubPart, @GSEHouPro, @GSEMedChar, @LifeAllo, @GSEOther)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@GSEYear", bG_PayWelSupply.GSEYear),
					new SqlParameter("@DepID", bG_PayWelSupply.DepID),
					new SqlParameter("@GSETotal", bG_PayWelSupply.GSETotal),
					new SqlParameter("@OffSubTot", bG_PayWelSupply.OffSubTot),
					new SqlParameter("@OffPerPart", bG_PayWelSupply.OffPerPart),
					new SqlParameter("@OffPubPart", bG_PayWelSupply.OffPubPart),
					new SqlParameter("@EbbSubTot", bG_PayWelSupply.EbbSubTot),
					new SqlParameter("@EbbPerPart", bG_PayWelSupply.EbbPerPart),
					new SqlParameter("@EbbPubPart", bG_PayWelSupply.EbbPubPart),
					new SqlParameter("@GSEHouPro", bG_PayWelSupply.GSEHouPro),
					new SqlParameter("@GSEMedChar", bG_PayWelSupply.GSEMedChar),
					new SqlParameter("@LifeAllo", bG_PayWelSupply.LifeAllo),
					new SqlParameter("@GSEOther", bG_PayWelSupply.GSEOther)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_PayWelSupplyByGSEID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_PayWelSupply(BG_PayWelSupply bG_PayWelSupply)
		{
			return DeleteBG_PayWelSupplyByGSEID( bG_PayWelSupply.GSEID );
		}

        public static bool DeleteBG_PayWelSupplyByGSEID(int gSEID)
		{
            string sql = "DELETE BG_PayWelSupply WHERE GSEID = @GSEID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@GSEID", gSEID)
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
					


        public static bool ModifyBG_PayWelSupply(BG_PayWelSupply bG_PayWelSupply)
        {
            string sql =
                "UPDATE BG_PayWelSupply " +
                "SET " +
	                "GSEYear = @GSEYear, " +
	                "DepID = @DepID, " +
	                "GSETotal = @GSETotal, " +
	                "OffSubTot = @OffSubTot, " +
	                "OffPerPart = @OffPerPart, " +
	                "OffPubPart = @OffPubPart, " +
	                "EbbSubTot = @EbbSubTot, " +
	                "EbbPerPart = @EbbPerPart, " +
	                "EbbPubPart = @EbbPubPart, " +
	                "GSEHouPro = @GSEHouPro, " +
	                "GSEMedChar = @GSEMedChar, " +
	                "LifeAllo = @LifeAllo, " +
	                "GSEOther = @GSEOther " +
                "WHERE GSEID = @GSEID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@GSEID", bG_PayWelSupply.GSEID),
					new SqlParameter("@GSEYear", bG_PayWelSupply.GSEYear),
					new SqlParameter("@DepID", bG_PayWelSupply.DepID),
					new SqlParameter("@GSETotal", bG_PayWelSupply.GSETotal),
					new SqlParameter("@OffSubTot", bG_PayWelSupply.OffSubTot),
					new SqlParameter("@OffPerPart", bG_PayWelSupply.OffPerPart),
					new SqlParameter("@OffPubPart", bG_PayWelSupply.OffPubPart),
					new SqlParameter("@EbbSubTot", bG_PayWelSupply.EbbSubTot),
					new SqlParameter("@EbbPerPart", bG_PayWelSupply.EbbPerPart),
					new SqlParameter("@EbbPubPart", bG_PayWelSupply.EbbPubPart),
					new SqlParameter("@GSEHouPro", bG_PayWelSupply.GSEHouPro),
					new SqlParameter("@GSEMedChar", bG_PayWelSupply.GSEMedChar),
					new SqlParameter("@LifeAllo", bG_PayWelSupply.LifeAllo),
					new SqlParameter("@GSEOther", bG_PayWelSupply.GSEOther)
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


        public static DataTable GetAllBG_PayWelSupply()
        {
            string sqlAll = "SELECT * FROM BG_PayWelSupply";
			return GetBG_PayWelSupplyBySql( sqlAll );
        }
		

        public static BG_PayWelSupply GetBG_PayWelSupplyByGSEID(int gSEID)
        {
            string sql = "SELECT * FROM BG_PayWelSupply WHERE GSEID = @GSEID";

            try
            {
                SqlParameter para = new SqlParameter("@GSEID", gSEID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_PayWelSupply bG_PayWelSupply = new BG_PayWelSupply();

                    bG_PayWelSupply.GSEID = dt.Rows[0]["GSEID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["GSEID"];
                    bG_PayWelSupply.GSEYear = dt.Rows[0]["GSEYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["GSEYear"];
                    bG_PayWelSupply.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_PayWelSupply.GSETotal = dt.Rows[0]["GSETotal"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["GSETotal"];
                    bG_PayWelSupply.OffSubTot = dt.Rows[0]["OffSubTot"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OffSubTot"];
                    bG_PayWelSupply.OffPerPart = dt.Rows[0]["OffPerPart"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OffPerPart"];
                    bG_PayWelSupply.OffPubPart = dt.Rows[0]["OffPubPart"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["OffPubPart"];
                    bG_PayWelSupply.EbbSubTot = dt.Rows[0]["EbbSubTot"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["EbbSubTot"];
                    bG_PayWelSupply.EbbPerPart = dt.Rows[0]["EbbPerPart"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["EbbPerPart"];
                    bG_PayWelSupply.EbbPubPart = dt.Rows[0]["EbbPubPart"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["EbbPubPart"];
                    bG_PayWelSupply.GSEHouPro = dt.Rows[0]["GSEHouPro"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["GSEHouPro"];
                    bG_PayWelSupply.GSEMedChar = dt.Rows[0]["GSEMedChar"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["GSEMedChar"];
                    bG_PayWelSupply.LifeAllo = dt.Rows[0]["LifeAllo"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["LifeAllo"];
                    bG_PayWelSupply.GSEOther = dt.Rows[0]["GSEOther"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["GSEOther"];
                    
                    return bG_PayWelSupply;
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
	

      

        private static DataTable GetBG_PayWelSupplyBySql(string safeSql)
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
		
        private static DataTable GetBG_PayWelSupplyBySql(string sql, params SqlParameter[] values)
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
