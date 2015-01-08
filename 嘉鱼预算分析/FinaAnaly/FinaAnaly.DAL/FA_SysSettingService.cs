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
	public static partial class FA_SysSettingService
	{
        public static FA_SysSetting AddFA_SysSetting(FA_SysSetting fA_SysSetting)
		{
            string sql =
				"INSERT FA_SysSetting (UnitName, UnitCode, SSYear, StaffNum)" +
				"VALUES (@UnitName, @UnitCode, @SSYear, @StaffNum)";
				
			sql += " ; SELECT @@IDENTITY";

            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UnitName", fA_SysSetting.UnitName),
					new SqlParameter("@UnitCode", fA_SysSetting.UnitCode),
					new SqlParameter("@SSYear", fA_SysSetting.SSYear),
					new SqlParameter("@StaffNum", fA_SysSetting.StaffNum)
				};
			
                string IdStr = DBUnity.ExecuteScalar(CommandType.Text, sql, para);
                int newId = Convert.ToInt32(IdStr);
                return GetFA_SysSettingBySSID(newId);

            }
            catch (Exception e)
            {
				Console.WriteLine(e.Message);
                throw e;
            }
		}
		
        public static bool DeleteFA_SysSetting(FA_SysSetting fA_SysSetting)
		{
			return DeleteFA_SysSettingBySSID( fA_SysSetting.SSID );
		}

        public static bool DeleteFA_SysSettingBySSID(int sSID)
		{
            string sql = "DELETE FA_SysSetting WHERE SSID = @SSID";

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
					


        public static bool ModifyFA_SysSetting(FA_SysSetting fA_SysSetting)
        {
            string sql =
                "UPDATE FA_SysSetting " +
                "SET " +
	                "UnitName = @UnitName, " +
	                "UnitCode = @UnitCode, " +
	                "SSYear = @SSYear, " +
	                "StaffNum = @StaffNum " +
                "WHERE SSID = @SSID";


            try
            {
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@SSID", fA_SysSetting.SSID),
					new SqlParameter("@UnitName", fA_SysSetting.UnitName),
					new SqlParameter("@UnitCode", fA_SysSetting.UnitCode),
					new SqlParameter("@SSYear", fA_SysSetting.SSYear),
					new SqlParameter("@StaffNum", fA_SysSetting.StaffNum)
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


        public static DataTable GetAllFA_SysSetting()
        {
            string sqlAll = "SELECT * FROM FA_SysSetting";
			return GetFA_SysSettingBySql( sqlAll );
        }
		

        public static FA_SysSetting GetFA_SysSettingBySSID(int sSID)
        {
            string sql = "SELECT * FROM FA_SysSetting WHERE SSID = @SSID";

            try
            {
                SqlParameter para = new SqlParameter("@SSID", sSID);
                DataTable dt = DBUnity.AdapterToTab(sql, para);
                
                if(dt.Rows.Count > 0)
                {
                    FA_SysSetting fA_SysSetting = new FA_SysSetting();

                    fA_SysSetting.SSID = dt.Rows[0]["SSID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["SSID"];
                    fA_SysSetting.UnitName = dt.Rows[0]["UnitName"] == DBNull.Value ? "" : (string)dt.Rows[0]["UnitName"];
                    fA_SysSetting.UnitCode = dt.Rows[0]["UnitCode"] == DBNull.Value ? "" : (string)dt.Rows[0]["UnitCode"];
                    fA_SysSetting.SSYear = dt.Rows[0]["SSYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["SSYear"];
                    fA_SysSetting.StaffNum = dt.Rows[0]["StaffNum"] == DBNull.Value ? 0 : (int)dt.Rows[0]["StaffNum"];
                    
                    return fA_SysSetting;
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
	

      

        private static DataTable GetFA_SysSettingBySql(string safeSql)
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
		
        private static DataTable GetFA_SysSettingBySql(string sql, params SqlParameter[] values)
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
