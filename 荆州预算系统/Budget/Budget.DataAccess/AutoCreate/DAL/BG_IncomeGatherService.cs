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
	public static partial class BG_IncomeGatherService
	{
        public static BG_IncomeGather AddBG_IncomeGather(BG_IncomeGather bG_IncomeGather)
		{
            string sql =
				"INSERT BG_IncomeGather (DepID, IcoMon, IcoType, IcoYear)" +
				"VALUES (@DepID, @IcoMon, @IcoType, @IcoYear)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DepID", bG_IncomeGather.DepID),
					new SqlParameter("@IcoMon", bG_IncomeGather.IcoMon),
					new SqlParameter("@IcoType", bG_IncomeGather.IcoType),
					new SqlParameter("@IcoYear", bG_IncomeGather.IcoYear)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_IncomeGatherByIGID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_IncomeGather(BG_IncomeGather bG_IncomeGather)
		{
			return DeleteBG_IncomeGatherByIGID( bG_IncomeGather.IGID );
		}

        public static bool DeleteBG_IncomeGatherByIGID(int iGID)
		{
            string sql = "DELETE BG_IncomeGather WHERE IGID = @IGID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@IGID", iGID)
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
					


        public static bool ModifyBG_IncomeGather(BG_IncomeGather bG_IncomeGather)
        {
            string sql =
                "UPDATE BG_IncomeGather " +
                "SET " +
	                "DepID = @DepID, " +
	                "IcoMon = @IcoMon, " +
	                "IcoType = @IcoType, " +
	                "IcoYear = @IcoYear " +
                "WHERE IGID = @IGID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@IGID", bG_IncomeGather.IGID),
					new SqlParameter("@DepID", bG_IncomeGather.DepID),
					new SqlParameter("@IcoMon", bG_IncomeGather.IcoMon),
					new SqlParameter("@IcoType", bG_IncomeGather.IcoType),
					new SqlParameter("@IcoYear", bG_IncomeGather.IcoYear)
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


        public static DataTable GetAllBG_IncomeGather()
        {
            string sqlAll = "SELECT * FROM BG_IncomeGather";
			return GetBG_IncomeGatherBySql( sqlAll );
        }
		

        public static BG_IncomeGather GetBG_IncomeGatherByIGID(int iGID)
        {
            string sql = "SELECT * FROM BG_IncomeGather WHERE IGID = @IGID";

            try
            {
                SqlParameter para = new SqlParameter("@IGID", iGID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_IncomeGather bG_IncomeGather = new BG_IncomeGather();

                    bG_IncomeGather.IGID = dt.Rows[0]["IGID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IGID"];
                    bG_IncomeGather.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    bG_IncomeGather.IcoMon = dt.Rows[0]["IcoMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IcoMon"];
                    bG_IncomeGather.IcoType = dt.Rows[0]["IcoType"] == DBNull.Value ? "" : (string)dt.Rows[0]["IcoType"];
                    bG_IncomeGather.IcoYear = dt.Rows[0]["IcoYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IcoYear"];
                    
                    return bG_IncomeGather;
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
	

      

        private static DataTable GetBG_IncomeGatherBySql(string safeSql)
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
		
        private static DataTable GetBG_IncomeGatherBySql(string sql, params SqlParameter[] values)
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
