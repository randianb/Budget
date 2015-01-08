using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{
    public class BGBudgetConCellManager
    {

        /// <summary>
        ///查询指定预算项目下的所有控制单元
        /// </summary>
        /// <param name="bcc">一个实例BGBudgetConCell</param>
        ///<returns>True/False</returns>
        public static DataTable GetBudgetConCellListByPIID(string piid)
        {
            return BGBudgetConCellService.GetBudgetConCellListByPIID(piid);

        }

        /// <summary>
        ///  批量添加
        /// </summary>
        /// <param name="list">List</param>
        /// <returns></returns>
        public static bool AddBudgetConCell(List<BG_BudgetConCell> list)
        {
            return BGBudgetConCellService.AddBudgetConCell(list);
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="piid">PIID</param>
        /// <returns></returns>
        public static bool UpdateBantch(List<BG_BudgetConCell> list, string piid)
        {
            return BGBudgetConCellService.UpdateBantch(list, piid);
        }
        /// <summary>
        /// 单项添加
        /// </summary>
        /// <param name="cell">Cell</param>
        /// <returns></returns>
        public static bool AddSingleBudgetConCell(BG_BudgetConCell cell)
        {
            return BGBudgetConCellService.AddSingleBudgetConCell(cell);
        }

        /// <summary>
        /// 删除指定PIID的所有控制单元
        /// </summary>
        /// <param name="piid"></param>
        /// <returns></returns>
        public static bool DelAppPIIDConCell(string piid)
        {
            return BGBudgetConCellService.DelAppPIIDConCell(piid);
        }
    }
}
