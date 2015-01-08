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
	public static partial class BG_EcoIncomeService
	{
        public static BG_EcoIncome AddBG_EcoIncome(BG_EcoIncome bG_EcoIncome)
		{
            string sql =
				"INSERT BG_EcoIncome (EICoding, EILev, EIParID, EIName)" +
				"VALUES (@EICoding, @EILev, @EIParID, @EIName)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@EICoding", bG_EcoIncome.EICoding),
					new SqlParameter("@EILev", bG_EcoIncome.EILev),
					new SqlParameter("@EIParID", bG_EcoIncome.EIParID),
					new SqlParameter("@EIName", bG_EcoIncome.EIName)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_EcoIncomeByEIID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_EcoIncome(BG_EcoIncome bG_EcoIncome)
		{
			return DeleteBG_EcoIncomeByEIID( bG_EcoIncome.EIID );
		}

        public static bool DeleteBG_EcoIncomeByEIID(int eIID)
		{
            string sql = "DELETE BG_EcoIncome WHERE EIID = @EIID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@EIID", eIID)
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
					


        public static bool ModifyBG_EcoIncome(BG_EcoIncome bG_EcoIncome)
        {
            string sql =
                "UPDATE BG_EcoIncome " +
                "SET " +
	                "EICoding = @EICoding, " +
	                "EILev = @EILev, " +
	                "EIParID = @EIParID, " +
	                "EIName = @EIName " +
                "WHERE EIID = @EIID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@EIID", bG_EcoIncome.EIID),
					new SqlParameter("@EICoding", bG_EcoIncome.EICoding),
					new SqlParameter("@EILev", bG_EcoIncome.EILev),
					new SqlParameter("@EIParID", bG_EcoIncome.EIParID),
					new SqlParameter("@EIName", bG_EcoIncome.EIName)
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


        public static DataTable GetAllBG_EcoIncome()
        {
            string sqlAll = "SELECT * FROM BG_EcoIncome";
			return GetBG_EcoIncomeBySql( sqlAll );
        }
		

        public static BG_EcoIncome GetBG_EcoIncomeByEIID(int eIID)
        {
            string sql = "SELECT * FROM BG_EcoIncome WHERE EIID = @EIID";

            try
            {
                SqlParameter para = new SqlParameter("@EIID", eIID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_EcoIncome bG_EcoIncome = new BG_EcoIncome();

                    bG_EcoIncome.EIID = dt.Rows[0]["EIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["EIID"];
                    bG_EcoIncome.EICoding = dt.Rows[0]["EICoding"] == DBNull.Value ? "" : (string)dt.Rows[0]["EICoding"];
                    bG_EcoIncome.EILev = dt.Rows[0]["EILev"] == DBNull.Value ? "" : (string)dt.Rows[0]["EILev"];
                    bG_EcoIncome.EIParID = dt.Rows[0]["EIParID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["EIParID"];
                    bG_EcoIncome.EIName = dt.Rows[0]["EIName"] == DBNull.Value ? "" : (string)dt.Rows[0]["EIName"];
                    
                    return bG_EcoIncome;
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
	

      

        private static DataTable GetBG_EcoIncomeBySql(string safeSql)
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
		
        private static DataTable GetBG_EcoIncomeBySql(string sql, params SqlParameter[] values)
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
