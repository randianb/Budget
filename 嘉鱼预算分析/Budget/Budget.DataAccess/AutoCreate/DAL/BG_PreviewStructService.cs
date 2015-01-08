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
	public static partial class BG_PreviewStructService
	{
        public static BG_PreviewStruct AddBG_PreviewStruct(BG_PreviewStruct bG_PreviewStruct)
		{
            string sql =
				"INSERT BG_PreviewStruct (PSType, PSType2, PSName, PDData, PDLYData)" +
				"VALUES (@PSType, @PSType2, @PSName, @PDData, @PDLYData)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PSType", bG_PreviewStruct.PSType),
					new SqlParameter("@PSType2", bG_PreviewStruct.PSType2),
					new SqlParameter("@PSName", bG_PreviewStruct.PSName),
					new SqlParameter("@PDData", bG_PreviewStruct.PDData),
					new SqlParameter("@PDLYData", bG_PreviewStruct.PDLYData)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_PreviewStructByPSID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_PreviewStruct(BG_PreviewStruct bG_PreviewStruct)
		{
			return DeleteBG_PreviewStructByPSID( bG_PreviewStruct.PSID );
		}

        public static bool DeleteBG_PreviewStructByPSID(int pSID)
		{
            string sql = "DELETE BG_PreviewStruct WHERE PSID = @PSID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PSID", pSID)
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
					


        public static bool ModifyBG_PreviewStruct(BG_PreviewStruct bG_PreviewStruct)
        {
            string sql =
                "UPDATE BG_PreviewStruct " +
                "SET " +
	                "PSType = @PSType, " +
	                "PSType2 = @PSType2, " +
	                "PSName = @PSName, " +
	                "PDData = @PDData, " +
	                "PDLYData = @PDLYData " +
                "WHERE PSID = @PSID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PSID", bG_PreviewStruct.PSID),
					new SqlParameter("@PSType", bG_PreviewStruct.PSType),
					new SqlParameter("@PSType2", bG_PreviewStruct.PSType2),
					new SqlParameter("@PSName", bG_PreviewStruct.PSName),
					new SqlParameter("@PDData", bG_PreviewStruct.PDData),
					new SqlParameter("@PDLYData", bG_PreviewStruct.PDLYData)
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


        public static DataTable GetAllBG_PreviewStruct()
        {
            string sqlAll = "SELECT * FROM BG_PreviewStruct";
			return GetBG_PreviewStructBySql( sqlAll );
        }
		

        public static BG_PreviewStruct GetBG_PreviewStructByPSID(int pSID)
        {
            string sql = "SELECT * FROM BG_PreviewStruct WHERE PSID = @PSID";

            try
            {
                SqlParameter para = new SqlParameter("@PSID", pSID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_PreviewStruct bG_PreviewStruct = new BG_PreviewStruct();

                    bG_PreviewStruct.PSID = dt.Rows[0]["PSID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PSID"];
                    bG_PreviewStruct.PSType = dt.Rows[0]["PSType"] == DBNull.Value ? "" : (string)dt.Rows[0]["PSType"];
                    bG_PreviewStruct.PSType2 = dt.Rows[0]["PSType2"] == DBNull.Value ? "" : (string)dt.Rows[0]["PSType2"];
                    bG_PreviewStruct.PSName = dt.Rows[0]["PSName"] == DBNull.Value ? "" : (string)dt.Rows[0]["PSName"];
                    bG_PreviewStruct.PDData = dt.Rows[0]["PDData"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PDData"];
                    bG_PreviewStruct.PDLYData = dt.Rows[0]["PDLYData"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PDLYData"];
                    
                    return bG_PreviewStruct;
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
	

      

        private static DataTable GetBG_PreviewStructBySql(string safeSql)
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
		
        private static DataTable GetBG_PreviewStructBySql(string sql, params SqlParameter[] values)
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
