using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
    public class BGBudItemsLibrariesService
    {
        /// <summary>
        /// 根据项目编号查询
        /// </summary>
        /// <param name="depid"></param>
        /// <returns></returns>
        public static DataTable GetBGBudItemsLibrariesbudID(int budid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select a.*,b.* from BG_BudItemsLibraries  as a left join BG_Department as b  on a.DepID=b.DepID where a.BudItID={0}";
                sqlStr = string.Format(sqlStr, budid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BG_BudItemsLibrariesService--GetBGBudItemsLibraries");
            }
            return dt;
        }
        /// <summary>
        /// 根据部门查询
        /// </summary>
        /// <param name="depid"></param>
        /// <returns></returns>
        public static DataTable GetBGBudItemsLibraries(int depid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select a.*,b.* from BG_BudItemsLibraries  as a left join BG_Department as b on a.DepID=b.DepID where a.DepID={0}";
                sqlStr = string.Format(sqlStr, depid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BG_BudItemsLibrariesService--GetBGBudItemsLibraries");
            }
            return dt;
        }

        /// <summary>
        /// 根据项目查询
        /// </summary>
        /// <param name="depid"></param>
        /// <returns></returns>
        public static DataTable GetBGBudItemsLibrariesProject(int pPID)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select a.*,b.* from BG_BudItemsLibraries  as a left join BG_Department as b on a.DepID=b.DepID where a.PPID={0}";
                sqlStr = string.Format(sqlStr, pPID);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BG_BudItemsLibrariesService--GetBGBudItemsLibrariesProject");
            }
            return dt;
        }

        /// <summary>
        /// 根据项目名称查询
        /// </summary>
        /// <param name="depid"></param>
        /// <returns></returns>
        public static DataTable GetBGBudItemsLibrariesProjectName(string bILProName)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select a.*,b.* from BG_BudItemsLibraries  as a left join BG_Department as b on a.DepID=b.DepID where a.BILProName like '%{0}%'";
                sqlStr = string.Format(sqlStr, bILProName);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BG_BudItemsLibrariesService--GetBGBudItemsLibrariesProject");
            }
            return dt;
        }

        /// <summary>
        /// 根据经济科目查询
        /// </summary>
        /// <param name="depid"></param>
        /// <returns></returns>
        public static DataTable GetBGBudItemsLibrariesPayIncome(int pIID)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select a.*,b.* from BG_BudItemsLibraries  as a left join BG_Department as b on a.DepID=b.DepID where a.PIID={0}";
                sqlStr = string.Format(sqlStr, pIID);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BG_BudItemsLibrariesService--GetBGBudItemsLibrariesPayIncome");
            }
            return dt;
        }


        public static DataTable GetAllBG_BudItemsLibrariesDept()
        {
            string sqlAll = " select a.*,b.* from  dbo.BG_BudItemsLibraries   as a left join dbo.BG_Department as b on a.DepID=b.DepID ";
            return GetBG_BudItemsLibrariesBySql(sqlAll);
        }
        private static DataTable GetBG_BudItemsLibrariesBySql(string safeSql)
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

        internal static DataTable GetExamineBG_BudItemsLibrariesByDept(int depid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_BudItems where DepID={0} and BudSta='审核通过' ";
                sqlStr = string.Format(sqlStr, depid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BG_BudItemsLibrariesService--GetBGBudItemsLibraries");
            }
            return dt;
        }
    }
}
