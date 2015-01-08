//============================================================
// Coded by: HG  At: 2013/10/31 16:18
//============================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{
    public class BGBudgetConManager
    {
        #region 添加一条预算项目控制记录
        /// <summary>
        /// 添加一条预算项目控制记录
        /// </summary>
        /// <param name="piid">一条预算项目控制记录</param>
        /// <returns>bool</returns>
        public static bool AddBudgetCon(BG_BudgetCon bg)
        {
            return BGBudgetConService.AddBudgetCon(bg);
        }

        #endregion

        #region 修改预算项目控制记录
        /// <summary>
        /// 修改预算项目控制记录
        /// </summary>
        /// <param name="piid">BGBudgetCon</param>
        /// <returns>bool</returns>
        public static bool UpdBudgetCon(BG_BudgetCon piid)
        {
            return BGBudgetConService.UpdBudgetCon(piid);
        }

        #endregion

        #region 更改预算项目控制记录状态（启用/禁用）
        /// <summary>
        /// 更改预算项目控制记录状态（启用/禁用）
        /// </summary>
        /// <param name="piid">BGBudgetCon</param>
        /// <returns>bool</returns>
        public static bool UpdBudgetConSta(BG_BudgetCon bc)
        {
            return BGBudgetConService.UpdBudgetConSta(bc);
        }
        #endregion

        #region 查询所有预算项目控制信息
        /// <summary>
        /// 查询所有预算项目控制信息
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetAllBudgetCon()
        {
            return BGBudgetConService.GetAllBudgetCon();
        }
        #endregion

        #region 根据项目控制ID查询项一条项目控制信息
        /// <summary>
        /// 根据项目控制ID查询项一条项目控制信息
        /// </summary>
        /// <param name="piid">支出经济科目ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetBudgetConByid(string piid)
        {
           return  BGBudgetConService.GetBudgetConByid(piid);
        }
        #endregion

        #region 删除指定PIID的预算项目控制记录
        /// <summary>
        /// 删除指定PIID的预算项目控制记录
        /// </summary>
        /// <param name="piid"></param>
        /// <returns></returns>
        public static bool DelAppPIIDConCell(string piid)
        {
            return BGBudgetConService.DelAppPIIDConCell(piid);
        }
        #endregion
    }
}
