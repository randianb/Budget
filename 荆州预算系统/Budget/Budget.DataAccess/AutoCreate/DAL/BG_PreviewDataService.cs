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
	public static partial class BG_PreviewDataService
	{
        public static BG_PreviewData AddBG_PreviewData(BG_PreviewData bG_PreviewData)
		{
            string sql =
				"INSERT BG_PreviewData (PSType1, PSType2, PSName, PDBaseData, PDBaseLYData, PDProjectData, PDProjectLYData)" +
				"VALUES (@PSType1, @PSType2, @PSName, @PDBaseData, @PDBaseLYData, @PDProjectData, @PDProjectLYData)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PSType1", bG_PreviewData.PSType1),
					new SqlParameter("@PSType2", bG_PreviewData.PSType2),
					new SqlParameter("@PSName", bG_PreviewData.PSName),
					new SqlParameter("@PDBaseData", bG_PreviewData.PDBaseData),
					new SqlParameter("@PDBaseLYData", bG_PreviewData.PDBaseLYData),
					new SqlParameter("@PDProjectData", bG_PreviewData.PDProjectData),
					new SqlParameter("@PDProjectLYData", bG_PreviewData.PDProjectLYData)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_PreviewDataByPSID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_PreviewData(BG_PreviewData bG_PreviewData)
		{
			return DeleteBG_PreviewDataByPSID( bG_PreviewData.PSID );
		}

        public static bool DeleteBG_PreviewDataByPSID(int pSID)
		{
            string sql = "DELETE BG_PreviewData WHERE PSID = @PSID";

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
					


        public static bool ModifyBG_PreviewData(BG_PreviewData bG_PreviewData)
        {
            string sql =
                "UPDATE BG_PreviewData " +
                "SET " +
	                "PSType1 = @PSType1, " +
	                "PSType2 = @PSType2, " +
	                "PSName = @PSName, " +
	                "PDBaseData = @PDBaseData, " +
	                "PDBaseLYData = @PDBaseLYData, " +
	                "PDProjectData = @PDProjectData, " +
	                "PDProjectLYData = @PDProjectLYData " +
                "WHERE PSID = @PSID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PSID", bG_PreviewData.PSID),
					new SqlParameter("@PSType1", bG_PreviewData.PSType1),
					new SqlParameter("@PSType2", bG_PreviewData.PSType2),
					new SqlParameter("@PSName", bG_PreviewData.PSName),
					new SqlParameter("@PDBaseData", bG_PreviewData.PDBaseData),
					new SqlParameter("@PDBaseLYData", bG_PreviewData.PDBaseLYData),
					new SqlParameter("@PDProjectData", bG_PreviewData.PDProjectData),
					new SqlParameter("@PDProjectLYData", bG_PreviewData.PDProjectLYData)
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


        public static DataTable GetAllBG_PreviewData()
        {
            string sqlAll = "SELECT * FROM BG_PreviewData";
			return GetBG_PreviewDataBySql( sqlAll );
        }
		

        public static BG_PreviewData GetBG_PreviewDataByPSID(int pSID)
        {
            string sql = "SELECT * FROM BG_PreviewData WHERE PSID = @PSID";

            try
            {
                SqlParameter para = new SqlParameter("@PSID", pSID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_PreviewData bG_PreviewData = new BG_PreviewData();

                    bG_PreviewData.PSID = dt.Rows[0]["PSID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PSID"];
                    bG_PreviewData.PSType1 = dt.Rows[0]["PSType1"] == DBNull.Value ? "" : (string)dt.Rows[0]["PSType1"];
                    bG_PreviewData.PSType2 = dt.Rows[0]["PSType2"] == DBNull.Value ? "" : (string)dt.Rows[0]["PSType2"];
                    bG_PreviewData.PSName = dt.Rows[0]["PSName"] == DBNull.Value ? "" : (string)dt.Rows[0]["PSName"];
                    bG_PreviewData.PDBaseData = dt.Rows[0]["PDBaseData"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PDBaseData"];
                    bG_PreviewData.PDBaseLYData = dt.Rows[0]["PDBaseLYData"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PDBaseLYData"];
                    bG_PreviewData.PDProjectData = dt.Rows[0]["PDProjectData"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PDProjectData"];
                    bG_PreviewData.PDProjectLYData = dt.Rows[0]["PDProjectLYData"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["PDProjectLYData"];
                    
                    return bG_PreviewData;
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
	

      

        private static DataTable GetBG_PreviewDataBySql(string safeSql)
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
		
        private static DataTable GetBG_PreviewDataBySql(string sql, params SqlParameter[] values)
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
