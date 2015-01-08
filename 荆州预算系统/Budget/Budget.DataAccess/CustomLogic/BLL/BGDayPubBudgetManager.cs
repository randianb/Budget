using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;
using System.Data;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{
    public class BGDayPubBudgetManager
    {
        /// <summary>
        /// 日常公用支出预算表
        /// </summary>
        /// <param name="depid">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetBGDayPubBudgetByDepID(int depid)
        {
            return BGDayPubBudgetService.GetBGDayPubBudgetByDepID(depid);
        }

        /// <summary>
        /// 通过dpbid删除BG_DayPubBudget
        /// </summary>
        /// <param name="dpbid">DPBID</param>
        /// <returns>bool</returns>
        public static bool DelDayPubBudByDpbid(int dpbid)
        {
            return BGDayPubBudgetService.DelDayPubBudByDpbid(dpbid);
        }

        /// <summary>
        /// 添加一条【日常公用支出预算】记录BG_DayPubBudget
        /// </summary>
        /// <param name="dpb">BGDayPubBudget</param>
        /// <returns>bool</returns>
        public static bool AddDPB(BG_DayPubBudget dpb)
        {
            return BGDayPubBudgetService.AddDPB(dpb);
        }
    }
}
