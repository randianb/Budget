using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;

namespace BudgetWeb.DAL
{
      public class VMonPayPlanIncomeService
      {
          #region 通过月份查询经济科目
          /// <summary>
          /// 通过月份查询经济科目
        /// </summary>
        /// <param name="maMonth">月份</param>
        /// <returns>DataTable</returns>
          public static DataTable GetvMonPayPlanIncomeByMAMonth(int maMonth)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from vMonPayPlanIncome where  MAMonth ={0} ";
                sqlStr = string.Format(sqlStr, maMonth );
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "VMonPayPlanIncomeService--GetvMonPayPlanIncomeByMAMonth");
            }
            return dt;
        }
          #endregion

          #region 通过月份(状态)查询经济科目
          /// <summary>
          /// 通过月份(状态)查询经济科目
          /// </summary>
          /// <param name="maMonth">月份</param>
          /// <param name="sta">状态</param>
          /// <returns>DataTable</returns>
          public static DataTable GetvMonPayPlanIncomeBySta(int maMonth, string sta)
          {
              DataTable dt = new DataTable();
              try
              {
                  string sqlStr = "select * from vMonPayPlanIncome where  MAMonth ={0} and  MASta='{1}'";
                  sqlStr = string.Format(sqlStr, maMonth, sta);
                  dt = DBUnity.AdapterToTab(sqlStr);
              }
              catch (Exception ex)
              {
                  Log.WriteLog(ex.Message, "VMonPayPlanIncomeService--GetvMonPayPlanIncomeByMAMonth");
              }
              return dt;
          }
          #endregion
          
      }
}
