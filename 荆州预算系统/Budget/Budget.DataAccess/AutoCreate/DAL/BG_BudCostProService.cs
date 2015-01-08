//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014/11/9 15:51:43
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_BudCostProService
	{
        public static BG_BudCostPro AddBG_BudCostPro(BG_BudCostPro bG_BudCostPro)
		{
            string sql =
				"INSERT BG_BudCostPro (BudID, BCPCurrYear, PIID, BCPTotal, BCPSubtFinAllo, BCPSubtExp, BCInExpenses, BCOutFunding, BCPRemark)" +
				"VALUES (@BudID, @BCPCurrYear, @PIID, @BCPTotal, @BCPSubtFinAllo, @BCPSubtExp, @BCInExpenses, @BCOutFunding, @BCPRemark)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@BudID", bG_BudCostPro.BudID),
					new SqlParameter("@BCPCurrYear", bG_BudCostPro.BCPCurrYear),
					new SqlParameter("@PIID", bG_BudCostPro.PIID),
					new SqlParameter("@BCPTotal", bG_BudCostPro.BCPTotal),
					new SqlParameter("@BCPSubtFinAllo", bG_BudCostPro.BCPSubtFinAllo),
					new SqlParameter("@BCPSubtExp", bG_BudCostPro.BCPSubtExp),
					new SqlParameter("@BCInExpenses", bG_BudCostPro.BCInExpenses),
					new SqlParameter("@BCOutFunding", bG_BudCostPro.BCOutFunding),
					new SqlParameter("@BCPRemark", bG_BudCostPro.BCPRemark)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_BudCostProByCostID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_BudCostPro(BG_BudCostPro bG_BudCostPro)
		{
			return DeleteBG_BudCostProByCostID( bG_BudCostPro.CostID );
		}

        public static bool DeleteBG_BudCostProByCostID(int costID)
		{
            string sql = "DELETE BG_BudCostPro WHERE CostID = @CostID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CostID", costID)
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
					


        public static bool ModifyBG_BudCostPro(BG_BudCostPro bG_BudCostPro)
        {
            string sql =
                "UPDATE BG_BudCostPro " +
                "SET " +
	                "BudID = @BudID, " +
	                "BCPCurrYear = @BCPCurrYear, " +
	                "PIID = @PIID, " +
	                "BCPTotal = @BCPTotal, " +
	                "BCPSubtFinAllo = @BCPSubtFinAllo, " +
	                "BCPSubtExp = @BCPSubtExp, " +
	                "BCInExpenses = @BCInExpenses, " +
	                "BCOutFunding = @BCOutFunding, " +
	                "BCPRemark = @BCPRemark " +
                "WHERE CostID = @CostID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CostID", bG_BudCostPro.CostID),
					new SqlParameter("@BudID", bG_BudCostPro.BudID),
					new SqlParameter("@BCPCurrYear", bG_BudCostPro.BCPCurrYear),
					new SqlParameter("@PIID", bG_BudCostPro.PIID),
					new SqlParameter("@BCPTotal", bG_BudCostPro.BCPTotal),
					new SqlParameter("@BCPSubtFinAllo", bG_BudCostPro.BCPSubtFinAllo),
					new SqlParameter("@BCPSubtExp", bG_BudCostPro.BCPSubtExp),
					new SqlParameter("@BCInExpenses", bG_BudCostPro.BCInExpenses),
					new SqlParameter("@BCOutFunding", bG_BudCostPro.BCOutFunding),
					new SqlParameter("@BCPRemark", bG_BudCostPro.BCPRemark)
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


        public static DataTable GetAllBG_BudCostPro()
        {
            string sqlAll = "SELECT * FROM BG_BudCostPro";
			return GetBG_BudCostProBySql( sqlAll );
        }
		

        public static BG_BudCostPro GetBG_BudCostProByCostID(int costID)
        {
            string sql = "SELECT * FROM BG_BudCostPro WHERE CostID = @CostID";

            try
            {
                SqlParameter para = new SqlParameter("@CostID", costID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_BudCostPro bG_BudCostPro = new BG_BudCostPro();

                    bG_BudCostPro.CostID = dt.Rows[0]["CostID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["CostID"];
                    bG_BudCostPro.BudID = dt.Rows[0]["BudID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BudID"];
                    bG_BudCostPro.BCPCurrYear = dt.Rows[0]["BCPCurrYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["BCPCurrYear"];
                    bG_BudCostPro.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    bG_BudCostPro.BCPTotal = dt.Rows[0]["BCPTotal"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCPTotal"];
                    bG_BudCostPro.BCPSubtFinAllo = dt.Rows[0]["BCPSubtFinAllo"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCPSubtFinAllo"];
                    bG_BudCostPro.BCPSubtExp = dt.Rows[0]["BCPSubtExp"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCPSubtExp"];
                    bG_BudCostPro.BCInExpenses = dt.Rows[0]["BCInExpenses"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCInExpenses"];
                    bG_BudCostPro.BCOutFunding = dt.Rows[0]["BCOutFunding"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["BCOutFunding"];
                    bG_BudCostPro.BCPRemark = dt.Rows[0]["BCPRemark"] == DBNull.Value ? "" : (string)dt.Rows[0]["BCPRemark"];
                    
                    return bG_BudCostPro;
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
	

      

        private static DataTable GetBG_BudCostProBySql(string safeSql)
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
		
        private static DataTable GetBG_BudCostProBySql(string sql, params SqlParameter[] values)
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
