using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using System.Data;

namespace BudgetWeb.BLL
{
    public class BGMonPayPlanRemarkManager
    {
        #region 更新
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="arid">申请表ID</param>
        /// <returns>bool</returns>
        public static bool UpdApplicationStatus(string status, int idStrs)
        {
            return BGMonPayPlanRemarkService.UpdApplicationStatus(status, idStrs);

        }

        #endregion
        #region 查询指定记录是否存在
        /// <summary>
        /// 查询记录
        /// </summary>
        /// <param name="arid">申请表ID</param>
        /// <returns>bool</returns>
        public static bool Querylog(int depid, int mayear,int month)
        {
            return BGMonPayPlanRemarkService.Querylog(depid,mayear,month);

        }

        #endregion




    }
}
