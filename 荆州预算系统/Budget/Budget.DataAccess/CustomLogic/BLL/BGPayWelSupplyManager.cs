using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;
using System.Data;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{
    public class BGPayWelSupplyManager
    {
           /// <summary>
        /// 对个人和家庭的补助支出表
        /// </summary>
        /// <param name="depid">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetBGPayWelSupplyByDepID(int depid)
        {
            return BGPayWelSupplyService.GetBGPayWelSupplyByDepID(depid);
        }

            /// <summary>
        /// 通过gseid删除BG_PayWelExpen
        /// </summary>
        /// <param name="dpbid">GSEID</param>
        /// <returns>bool</returns>
        public static bool DelPayWelSupplyByPweid(int gseid)
        {
            return BGPayWelSupplyService.DelPayWelSupplyByPweid(gseid);
        }

        /// <summary>
        /// 添加一条【对个人和家庭的补助支出】记录 BG_PayWelSupply
        /// </summary>
        /// <param name="dpb">BGPayWelSupply</param>
        /// <returns>bool</returns>
        public static bool AddPWS(BG_PayWelSupply pws)
        {
            return BGPayWelSupplyService.AddPWS(pws);
        }
    }
}
