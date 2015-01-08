using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{
    public class BGBudCostProManager
    {
        /// <summary>
        /// 添加一条【预算项目费用】记录 BG_BudCostPro
        /// </summary>
        /// <param name="bcp">BGBudCostPro</param>
        /// <returns>bool</returns>
        public static bool AddBGBudCostPro(BG_BudCostPro bcp)
        {
            return BGBudCostProService.AddBGBudCostPro(bcp);
        }

                /// <summary>
        /// 根据BudID获取BG_BudCostPro   RowCount
        /// </summary>
        /// <param name="Budid">BudID</param>
        /// <returns>int</returns>
        public static int GetBudCostProCountByBudid(int Budid)
        {
            return BGBudCostProService.GetBudCostProCountByBudid(Budid);
        }

              /// <summary>
        /// 通过BudID获取DT_BudCostPro
        /// </summary>
        /// <param name="Budid">BudID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDtBcpByBudid(int Budid)
        {
            return BGBudCostProService.GetDtBcpByBudid(Budid);
        }

        /// <summary>
        /// 获取删除IDStrs
        /// </summary>
        /// <param name="Budid">BudID</param>
        /// <returns>string</returns>
        public static string GetDelIdsStr(int Budid)
        {
            string idStrs = string.Empty;
            DataTable dt = GetDtBcpByBudid(Budid);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string idTmp = dt.Rows[i]["CostID"].ToString()+",";
                    idStrs += idTmp;
                }
            }
            return idStrs.TrimEnd(',');
        }

           /// <summary>
        /// 通过ID删除多条BG_BudCostPro记录
        /// </summary>
        /// <param name="idStrs"></param>
        /// <returns></returns>
        public static bool DelBCPByIdStrs(string idStrs)
        {
            return BGBudCostProService.DelBCPByIdStrs(idStrs);
        }
    }
}
