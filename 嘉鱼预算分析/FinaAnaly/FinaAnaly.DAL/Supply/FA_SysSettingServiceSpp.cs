using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FinaAnaly.Model;
using System.Data.SqlClient;
using Common;

namespace FinaAnaly.DAL
{
    public static partial class FA_SysSettingService
    {
        /// <summary>
        /// 根据年度获取对应记录数
        /// </summary>
        /// <param name="ssyear">年度</param>
        /// <returns>int</returns>
        public static int GetSysSettingCountByYear(int ssyear)
        {
            int tmp = 0;
            try
            {
                string sqlStr = "select count(*) from FA_SysSetting where SSYear={0}";
                sqlStr = string.Format(sqlStr, ssyear);
                tmp = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_SysSettingService.GetFA_SysSetting");
            }
            return tmp;
        }


        /// <summary>
        /// 根据年度查询到一条记录
        /// </summary>
        /// <param name="ssyear">年度</param>
        /// <returns>FA_SysSetting</returns>
        public static FA_SysSetting GetSysSettingByYear(int ssyear)
        {
            try
            {
                string sqlStr = "select * from FA_SysSetting where SSYear=@SSYear";
                SqlParameter para = new SqlParameter("@SSYear", ssyear);
                DataTable dt = DBUnity.AdapterToTab(sqlStr, para);
                if (dt.Rows.Count > 0)
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

        /// <summary>
        /// 获取最后一条对应记录
        /// </summary>
        /// <returns>FA_SysSetting</returns>
        public static FA_SysSetting GetSysSettingByMaxYear()
        {
            try
            {
                string sqlStr = "select Top 1 * from FA_SysSetting order by SSID desc";
                DataTable dt = DBUnity.AdapterToTab(sqlStr);
                if (dt.Rows.Count > 0)
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

        


    }
}
