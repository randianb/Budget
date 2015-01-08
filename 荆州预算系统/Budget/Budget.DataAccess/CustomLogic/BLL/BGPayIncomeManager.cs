using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;
using BudgetWeb.Model;
using System.Data;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{
    public class BGPayIncomeManager
    {
        /// <summary>
        /// 查询一条收入科目信息
        /// </summary>
        /// <param name="ei">一个实例BGPayIncome</param>
        /// <returns>True/False</returns>
        public static DataTable GetPayIncomeListByPIID(string piid)
       {
           return BGPayIncomeService.GetPayIncomeListByPIID(piid);
        }
       /// <summary>
       /// 查询指定父级经济科目下的所有子级经济科目
       /// </summary>
       /// <param name="pi">一个实例BGEcoIncome</param>
       /// <returns>True/False</returns>
        public static DataTable  SearchEcoIncome(int pilev)
       {
           return BGPayIncomeService.GetProBySublev(pilev);
       }

       public static DataTable GetDtAllPayIncome()
       {
           return BGPayIncomeService.GetDtAllPayIncome();
       }

       #region 通过支出项目ID查询经济科目

       /// <summary>
       /// 通过支出项目ID查询经济科目
       /// </summary>
       /// <param name="PPID">通过支出项目ID查询经济科目</param>
       /// <returns>DataTable</returns>
       public static DataTable GetPayIncomeByPPID(int PPID)
       {
         return  BGPayIncomeService.GetPayIncomeByPPID(PPID);
       }
       #endregion

       public static List<BG_PayIncome> GetPIList()
       {
           return BGPayIncomeService.GetPIList();
       }


       #region 通过支出项目ID查询经济科目类

       /// <summary>
       /// 通过支出项目ID查询经济科目类
       /// </summary>
       /// <param name="PPID">通过支出项目ID查询经济科目类</param>
       /// <returns>DataTable</returns>
       public static DataTable GetPayIncome()
       {
           return BGPayIncomeService.GetPayIncome();
       }
       #endregion
    }
}
