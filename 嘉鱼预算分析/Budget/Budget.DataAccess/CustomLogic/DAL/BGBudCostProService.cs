using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
    public class BGBudCostProService
    {

        /// <summary>
        /// 添加一条【预算项目费用】记录 BG_BudCostPro
        /// </summary>
        /// <param name="bcp">BGBudCostPro</param>
        /// <returns>bool</returns>
        public static bool AddBGBudCostPro(BG_BudCostPro bcp)
        {
            bool flag = false;
            try
            {
            string sqlStr = @"insert into BG_BudCostPro(BudID,BCPCurrYear,PIID,BCPTotal,BCPSubtFinAllo,BCPSubtExp,BCInExpenses,BCOutFunding,BCPRemark)values
            (@BudID,@BCPCurrYear,@PIID,@BCPTotal,@BCPSubtFinAllo,@BCPSubtExp,@BCInExpenses,@BCOutFunding,@BCPRemark)";

                SqlParameter[] Pars = new SqlParameter[]{
                        new SqlParameter("@BudID",bcp.BudID),
                        new SqlParameter("@BCPCurrYear",bcp.BCPCurrYear),
                        new SqlParameter("@PIID",bcp.PIID),
                        new SqlParameter("@BCPTotal",bcp.BCPTotal),
                        new SqlParameter("@BCPSubtFinAllo",bcp.BCPSubtFinAllo),
                        new SqlParameter("@BCPSubtExp",bcp.BCPSubtExp),
                        new SqlParameter("@BCInExpenses",bcp.BCInExpenses),
                        new SqlParameter("@BCOutFunding",bcp.BCOutFunding),
                        new SqlParameter("@BCPRemark",bcp.BCPRemark)
                        };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGBudCostProService--AddBGBudCostPro");
            }
            return flag;
        }


        /// <summary>
        /// 通过BudID获取DT_BudCostPro
        /// </summary>
        /// <param name="Budid">BudID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDtBcpByBudid(int Budid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_BudCostPro where BudID = {0}";
                sqlStr = string.Format(sqlStr, Budid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = null;
                Log.WriteLog(ex.Message, "BGBudCostProService--GetDtBcpByBudid");
            }
            return dt;
        }


        /// <summary>
        /// 根据BudID获取BG_BudCostPro   RowCount
        /// </summary>
        /// <param name="Budid">BudID</param>
        /// <returns>int</returns>
        public static int GetBudCostProCountByBudid(int Budid)
        {
            int count = 0;
            try
            {
                string sqlStr = "select count(*) from BG_BudCostPro where BudID = {0}";
                sqlStr = string.Format(sqlStr, Budid);
                count = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null));
            }
            catch (Exception ex)
            {
                count = 0;
                Log.WriteLog(ex.Message, "BGBudCostProService--GetBudCostProCountByBudid");
            }
            return count;
        }

        /// <summary>
        /// 通过ID删除多条BG_BudCostPro记录
        /// </summary>
        /// <param name="idStrs"></param>
        /// <returns></returns>
        public static bool DelBCPByIdStrs(string idStrs)
        {
            bool flag = false;
            try
            {
                string sqlStr = @"delete from BG_BudCostPro where CostID in ({0})";
                sqlStr = string.Format(sqlStr, idStrs);
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, null) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGBudCostProService--DelBCPByIdStrs");
            }
            return flag;
        }
    }
}
