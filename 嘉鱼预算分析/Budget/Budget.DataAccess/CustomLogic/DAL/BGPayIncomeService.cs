using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using Common;
using System.Data;
using BudgetWeb.Model;

namespace BudgetWeb.DAL
{
    public class BGPayIncomeService
    {
        #region 查询一条支出经济科目信息
        /// <summary>
        /// 通过支出经济科目ID查询经济科目(测试成功！)
        /// </summary>
        /// <param name="depid">支出经济科目ID</param>
        /// <returns>DataTable</returns>
         public static DataTable GetPayIncomeListByPIID(string piid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_PayIncome where PIID={0}";
                sqlStr = string.Format(sqlStr, piid);
                dt = DBUnity.AdapterToTab(sqlStr);

            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGPayIncomeService--GetUserListByPIID");
                
               
            }
            return dt;
        }
        #endregion

        #region 查询指定父级经济科目下的所有子级经济科目

        /// <summary>
        /// 通过支出经济科目ID查询经济科目
        /// </summary>
        /// <param name="EILev">支出经济级别</param>
        /// <returns>DataTable</returns>
        public static DataTable GetProBySublev(int pilev)
        {
             DataTable dt = new DataTable();
             try
             {
                  string sqlStr = "select *  from BG_PayIncome where PIEcoSubLev ={0} ";
                  sqlStr = string.Format(sqlStr,pilev);
                  dt = DBUnity.AdapterToTab(sqlStr);
             }
             catch (Exception ex)
             {
                 dt = new DataTable();
                 Log.WriteLog(ex.Message, "BGPayIncomeService--GetProBySublev");
             }
             return dt;
        }
        #endregion

        #region 通过支出项目ID查询经济科目

        /// <summary>
        /// 通过支出项目ID查询经济科目
        /// </summary>
        /// <param name="PPID">通过支出项目ID查询经济科目</param>
        /// <returns>DataTable</returns>
        public static DataTable GetPayIncomeByPPID(int PPID)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = string.Format("select * from  dbo.BG_PayIncome where PIID ={0} ", PPID);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGPayIncomeService--GetPayIncomeByPPID");
            }
            return dt;
        }
        #endregion

        #region 通过支出项目ID查询经济科目类

        /// <summary>
        /// 通过支出项目ID查询经济科目类
        /// </summary>
        /// <param name="PPID">通过支出项目ID查询经济科目类</param>
        /// <returns>DataTable</returns>
        public static DataTable GetPayIncome()
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = string.Format(" select * from   dbo.BG_PayIncome where PIID in (select PIID from dbo.BG_PayProject group by PIID) ");
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGPayIncomeService--GetPayIncomeByPPID");
            }
            return dt;
        }
        #endregion

        public static DataTable GetDtAllPayIncome()
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_PayIncome";
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGPayIncomeService--GetDtAllPayIncome");
            }
            return dt;
        }

        public static List<BG_PayIncome> GetPIList()
        {
            List<BG_PayIncome> list = new List<BG_PayIncome>();
            DataTable dt = GetDtAllPayIncome();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["PIEcoSubCoding"] != null && dt.Rows[i]["PIEcoSubName"] != null)
                    {
                        BG_PayIncome pi = new BG_PayIncome();
                        pi.PIEcoSubCoding = dt.Rows[i]["PIEcoSubCoding"].ToString().Trim();
                        pi.PIEcoSubName = dt.Rows[i]["PIEcoSubName"].ToString();
                        list.Add(pi);
                    }
                }
            }
            return list;
        }

    }
}
