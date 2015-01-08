//============================================================
// Coded by: PF  At: 2013/10/31 16:45
//============================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{
  public   class BGBudAppendixManager
  {
      #region 添加预算项目附件信息
        /// <summary>
        /// 添加预算项目附件信息
        /// </summary>
        /// <param name="BudAppendix">BGBudAppendix</param>
        /// <returns>True/False</returns>
      public static bool AddBudAppendix(BG_BudAppendix BudAppendix)
        {
            return BGBudAppendixService.AddBudAppendix(BudAppendix);
        }
        #endregion

      #region 修改指定预算项目附件信息
        /// <summary>
        /// 修改指定预算项目附件信息
        /// </summary>
        /// <param name="BudAppendix">BGBudAppendix</param>
        /// <returns>bool</returns>
      public static bool UpdBudAppendix(BG_BudAppendix BudAppendix)
      {
          return BGBudAppendixService.UpdBudAppendix(BudAppendix);
      }
      #endregion

      #region 查询指定一条预算项目附件信息
      /// <summary>
      /// 查询指定一条预算项目附件信息
      /// </summary>
      /// <param name="apid">预算项目附件ID</param>
      /// <returns>BGDepartment</returns>
      public static BG_BudAppendix GetBudAppendixByapid(int apid)
      {
          return BGBudAppendixService.GetBudAppendixByapid(apid);
      }
      #endregion

      #region 删除指定预算项目附件信息
      /// <summary>
      /// 删除指定预算项目附件信息
      /// </summary>
      /// <param name="aid">APID</param>
      /// <returns>bool</returns>
      public static bool DelBudAppendix(int aid)
      {
          return BGBudAppendixService.DelBudAppendix(aid);
      }
      #endregion

      #region 查询指定项目下的所有附件信息列表
      /// <summary>
      /// 查询指定项目下的所有附件信息列表
      /// </summary>
      /// <param name="apid">附件ID</param>
      /// <returns>DataTable</returns>
      public static DataTable GetBudAppendixListByApid(int apid)
      {
          return BGBudAppendixService.GetBudAppendixListByApid(apid);
      }
      #endregion


      public static DataTable GetBudAppListByBudid(int budid)
      {
          return BGBudAppendixService.GetBudAppListByBudid(budid);
      }
  }
}


