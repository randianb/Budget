using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
    public class BGPayProjectService
    {
        /// <summary>
        /// 获取全部支出项目表记录
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetAllPayProject()
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_PayProject";
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = null;
                Log.WriteLog(ex.Message, "BGPayProjectService--GetAllPayProject");
            }

            return dt;
        }

        /// <summary>
        /// 获取全部支出项目表记录
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetAllPayProjectPPID(int PPID)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = string.Format("select * from BG_PayProject where ppid={0}",PPID);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = null;
                Log.WriteLog(ex.Message, "BGPayProjectService--GetAllPayProject");
            }

            return dt;
        }
    }
}
