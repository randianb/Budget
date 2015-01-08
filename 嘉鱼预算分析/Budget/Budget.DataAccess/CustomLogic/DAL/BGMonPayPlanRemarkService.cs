using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;

namespace BudgetWeb.DAL
{
    public class BGMonPayPlanRemarkService
    {
        #region 更改状态
        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="arid">申请表ID</param>
        /// <param name="arliststa">申请表状态</param>
        /// <returns>bool</returns>
        public static bool UpdApplicationStatus(string status, int  idStrs)
        {
            bool flag = false;
            try
            {
                string sqlStr = "update  BG_MonPayPlanRemark set MASta='{0}' where  MAMonth =({1})";
                sqlStr = string.Format(sqlStr, status, idStrs);
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, null) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BudgetSys.DAL.BGApplyReimburService.UpdApplicationStatus");
            }

            return flag;
        }
        #endregion

        #region 查询指定记录
        /// <summary>
        /// 查询记录
        /// </summary>
        /// <param name="arid"></param>
        /// <param name="arliststa"></param>
        /// <returns>bool</returns>
        public static bool Querylog(int depid, int mayear, int month)
        {
            bool flag = false;
            try
            {
                string sqlStr = "select * from BG_MonPayPlanRemark where DeptID='{0}' and MAYear='{1}' and MAMonth='{2}' ";
                sqlStr = string.Format(sqlStr, depid, mayear,month );
                DataTable dt = DBUnity.AdapterToTab(sqlStr);
                if (dt.Rows.Count > 0)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BudgetSys.DAL.BGMonPayPlanRemarkService.Querylog");
            }

            return flag;
        }
        #endregion
    }
}
