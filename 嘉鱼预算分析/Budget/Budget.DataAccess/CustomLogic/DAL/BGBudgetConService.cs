//============================================================
// Coded by: HG  At: 2013/10/31 10:32
//============================================================
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using Common;

namespace BudgetWeb.DAL
{
    public class BGBudgetConService
    {
        #region 添加一条预算项目控制记录
        /// <summary>
        /// 添加一条预算项目控制记录
        /// </summary>
        /// <param name="bg">一条预算项目控制记录</param>
        /// <returns>bool</returns>
        public static bool AddBudgetCon(BG_BudgetCon bg)
        {
            bool falg = false;
            try
            {
                string sqlStr = "insert into BG_BudgetCon(PIID,YNUse,BCRemark) values(@PIID,@YNUse,@BCRemark)";
                SqlParameter[] pars = new SqlParameter[]{
                                new SqlParameter("@PIID",bg.PIID),
                              new SqlParameter("@YNUse",bg.YNUse),
                              new SqlParameter("@BCRemark",bg.BCRemark)
                              };
                falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, pars) > 0;
            }
            catch (Exception ex)
            {
                falg = false;
                Log.WriteLog(ex.Message, "BGBudgetConService--AddBudgetCon");
            }
            return falg;
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
            bool falg = false;
            try
            {
                string sqlStr = "update BG_BudgetCon set YNUse=@YNUse,BCRemark=@BCRemark where PIID=@PIID";
                SqlParameter[] pars = new SqlParameter[]{
                                new SqlParameter("@PIID",piid.PIID),
                                new SqlParameter("@YNUse",piid.YNUse),
                                new SqlParameter("@BCRemark",piid.BCRemark)
                                };
                falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, pars) > 0;
            }
            catch (Exception ex)
            {
                falg = false;
                Log.WriteLog(ex.Message, "BGBudgetConService--UpdBudgetCon");
            }
            return falg;
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
            bool falg = false;
            try
            {
                string sqlStr = "update BG_BudgetCon set YNUse=@YNUse where PIID=@PIID";
                SqlParameter[] pars = new SqlParameter[]{
                                new SqlParameter("@YNUse",bc.YNUse),
                                new SqlParameter("@PIID",bc.PIID)
                                };
                falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, pars) > 0;
            }
            catch (Exception ex)
            {
                falg = false;
                Log.WriteLog(ex.Message, "BGBudgetConService--UpdBudgetConSta");
            }
            return falg;
        }
        #endregion

        #region 查询所有预算项目控制信息
        /// <summary>
        /// 查询所有预算项目控制信息
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetAllBudgetCon()
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select a.PIID,a.YNUse,a.BCRemark,b.PIEcoSubName from BG_BudgetCon as a left join BG_PayIncome as b on a.PIID = b.PIID";


                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudgetConService--GetAllBudgetCon");
            }
            return dt;
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
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_BudgetCon where PIID={0}";
                sqlStr = string.Format(sqlStr, piid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudgetConService--GetBudgetConByid");
            }
            return dt;
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
            bool flag = false;
            try
            {
                string sqlStr = "delete from BG_BudgetCon where PIID=@PIID";
                SqlParameter[] Pars = new SqlParameter[]{
                    new SqlParameter ("@PIID",piid ) 

                };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;

            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGBudgetConService--DelAppPIIDConCell");

            }

            return flag;
        }
        #endregion
    }
}
