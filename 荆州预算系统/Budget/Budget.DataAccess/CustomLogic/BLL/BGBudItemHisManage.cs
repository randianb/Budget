using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{
    public class BGBudItemHisManage
    {
        /// <summary>
        /// 添加一条预算项目历史实例
        /// </summary>
        /// <param name="budItems"></param>
        /// <returns></returns>
        public static bool InsertBudItemHis(BG_BudItems budItems)
        {
            return BGBudItemHisService.InsertBudItemHis(budItems);
        }

        /// <summary>
        /// 查询指定BudID的所有历史操作轨迹
        /// </summary>
        /// <param name="budid"></param>
        /// <returns></returns>
        public static DataTable GetDtBIHisByBudid(int budid, int PageSize, int pageIndex, out int RecordCount)
        {
            return BGBudItemHisService.GetDtBIHisByBudid( budid,PageSize,pageIndex,out RecordCount);
        }

        /// <summary>
        /// 查询指定BudID的退回次数
        /// </summary>
        /// <param name="budid"></param>
        /// <returns></returns>
        public static int GetBIReportNumByBudid(int budid)
        {
            return BGBudItemHisService.GetBIReportNumByBudid(budid);
        }
    }
}
