using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;
using BudgetWeb.Model;
using Common;

namespace BudgetWeb.BLL
{
    public class VMonPayPlanIncomeManager
    {
        #region 通过月份查询经济科目
        /// <summary>
        /// 通过月份查询经济科目
        /// </summary>
        /// <param name="depid">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetvMonPayPlanIncomeByMAMonth(int maMonth)
        {
            return VMonPayPlanIncomeService.GetvMonPayPlanIncomeByMAMonth(maMonth);
        }
        #endregion

        #region 通过月份(状态)查询经济科目
        /// <summary>
        /// 通过月份(状态)查询经济科目
        /// </summary>
        /// <param name="maMonth">月份</param>
        /// <param name="sta">状态</param>
        /// <returns>DataTable</returns>
        public static DataTable GetvMonPayPlanIncomeWBySta(int maMonth)
        {
            return VMonPayPlanIncomeService.GetvMonPayPlanIncomeBySta(maMonth, "未提交");
        }
        #endregion

        #region 通过月份(状态)查询经济科目
        /// <summary>
        /// 通过月份(状态)查询经济科目
        /// </summary>
        /// <param name="maMonth">月份</param>
        /// <param name="sta">状态</param>
        /// <returns>DataTable</returns>
        public static DataTable GetvMonPayPlanIncomeTBySta(int maMonth)
        {
            return VMonPayPlanIncomeService.GetvMonPayPlanIncomeBySta(maMonth, "提交");
        }
        #endregion

        #region 通过月份(状态)查询经济科目
        /// <summary>
        /// 通过月份(状态)查询经济科目
        /// </summary>
        /// <param name="maMonth">月份</param>
        /// <param name="sta">状态</param>
        /// <returns>DataTable</returns>
        public static DataTable GetvMonPayPlanIncomeSBySta(int maMonth, string sta)
        {
            return VMonPayPlanIncomeService.GetvMonPayPlanIncomeBySta(maMonth, "审核通过");

        #endregion

        }
       
    }
}
