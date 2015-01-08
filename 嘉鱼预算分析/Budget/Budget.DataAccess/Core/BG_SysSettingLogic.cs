using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using BudgetWeb.DAL;

namespace BudgetWeb.BLL
{
    public class BG_SysSettingLogic
    {
        public static string GetPerByYear(int year)
        {
            string pnuStr = "";
            try
            {
                string sqlStr = "SELECT  PepNum FROM BG_SysSetting Where DefaultYear={0}";
                sqlStr = string.Format(sqlStr, year);
                pnuStr = DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "BG_SysSettingLogic");
            }
            return pnuStr;
        }

        /// <summary>
        /// 获取最后的年度
        /// </summary>
        /// <returns></returns>
        public static string GetLastYear()
        {
            string pnuStr = "";
            try
            {
                string sqlStr = "SELECT  DefaultYear FROM BG_SysSetting order by SSID desc";
               
                pnuStr = DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "BG_SysSettingLogic");
            }
            return pnuStr;
        }
    }
}
