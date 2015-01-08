using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
    public class VApplyPayDepartService
    {
        #region 根据视图查询信息
        /// <summary>
        /// 根据视图查询信息
        /// </summary>
        /// <param name="depname">部门名称</param>
        /// <returns>DataTable</returns>
        public static DataTable GetVApplyPayDepartByDepName(string   depname)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select Sum(ARMon) as ARMon,DepName from VApplyPayDepart group by  DepName";
                sqlStr = string.Format(sqlStr, depname);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "VApplyPayDepartService--GetVApplyPayDepartByDepName");
            }
            return dt;
        }
        #endregion

        #region 根据视图查询信息
        /// <summary>
        /// 根据视图查询信息
        /// </summary>
        /// <param name="depname">部门名称</param>
        /// <returns>DataTable</returns>
        public static DataTable SelVApplyPayDepartByDepName(string  depname)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from VApplyPayDepart where DepName='{0}'";
                sqlStr = string.Format(sqlStr, depname);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "VApplyPayDepartService--GetVApplyPayDepartByDepName");
            }
            return dt;


        }
        #endregion
    }
}