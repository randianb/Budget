using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;
using Common;
using System.Data;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{
   public class BGPayWelExpenManager
    {
            /// <summary>
        /// 工资福利支出表
        /// </summary>
        /// <param name="depid">部门ID</param>
        /// <returns>DataTable</returns>
       public static DataTable GetBGPayExpByDepID(int depid)
       {
           return BGPayWelExpenService.GetBGPayExpByDepID(depid);
       }


         /// <summary>
        /// 通过pweid删除BG_PayWelExpen
        /// </summary>
        /// <param name="dpbid">PWEID</param>
        /// <returns>bool</returns>
       public static bool DelPayWelExpenByPweid(int pweid)
       {
           return BGPayWelExpenService.DelPayWelExpenByPweid(pweid);
       }

         /// <summary>
        /// 添加一条【工资福利支出】记录 BG_PayWelExpen 
        /// </summary>
        /// <param name="dpb">BGPayWelExpen</param>
        /// <returns>bool</returns>
       public static bool AddPWE(BG_PayWelExpen pwe)
       {
           return BGPayWelExpenService.AddPWE(pwe);
       }
    }
}
