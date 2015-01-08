//============================================================
// Producnt name:		Auto Generate
// Version: 			1.0
// Coded by:			Wu Di (wd_kk@qq.com)
// Auto generated at: 	2014-4-1 10:16:03
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
	public static partial class BG_SysSettingService
	{
        public static BG_SysSetting AddBG_SysSetting(BG_SysSetting bG_SysSetting)
		{
            string sql =
				"INSERT BG_SysSetting (SysName, DefaultYear, PepNum)" +
				"VALUES (@SysName, @DefaultYear, @PepNum)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@SysName", bG_SysSetting.SysName),
					new SqlParameter("@DefaultYear", bG_SysSetting.DefaultYear),
					new SqlParameter("@PepNum", bG_SysSetting.PepNum)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetBG_SysSettingBySSID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteBG_SysSetting(BG_SysSetting bG_SysSetting)
		{
			return DeleteBG_SysSettingBySSID( bG_SysSetting.SSID );
		}

        public static bool DeleteBG_SysSettingBySSID(int sSID)
		{
            string sql = "DELETE BG_SysSetting WHERE SSID = @SSID";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@SSID", sSID)
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
					


        public static bool ModifyBG_SysSetting(BG_SysSetting bG_SysSetting)
        {
            string sql =
                "UPDATE BG_SysSetting " +
                "SET " +
	                "SysName = @SysName, " +
	                "DefaultYear = @DefaultYear, " +
	                "PepNum = @PepNum " +
                "WHERE SSID = @SSID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@SSID", bG_SysSetting.SSID),
					new SqlParameter("@SysName", bG_SysSetting.SysName),
					new SqlParameter("@DefaultYear", bG_SysSetting.DefaultYear),
					new SqlParameter("@PepNum", bG_SysSetting.PepNum)
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


        public static DataTable GetAllBG_SysSetting()
        {
            string sqlAll = "SELECT * FROM BG_SysSetting";
			return GetBG_SysSettingBySql( sqlAll );
        }
		

        public static BG_SysSetting GetBG_SysSettingBySSID(int sSID)
        {
            string sql = "SELECT * FROM BG_SysSetting WHERE SSID = @SSID";

            try
            {
                SqlParameter para = new SqlParameter("@SSID", sSID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    BG_SysSetting bG_SysSetting = new BG_SysSetting();

                    bG_SysSetting.SSID = dt.Rows[0]["SSID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["SSID"];
                    bG_SysSetting.SysName = dt.Rows[0]["SysName"] == DBNull.Value ? "" : (string)dt.Rows[0]["SysName"];
                    bG_SysSetting.DefaultYear = dt.Rows[0]["DefaultYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DefaultYear"];
                    bG_SysSetting.PepNum = dt.Rows[0]["PepNum"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PepNum"];
                    
                    return bG_SysSetting;
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
	

      

        private static DataTable GetBG_SysSettingBySql(string safeSql)
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
		
        private static DataTable GetBG_SysSettingBySql(string sql, params SqlParameter[] values)
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
