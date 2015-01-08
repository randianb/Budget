//============================================================
// Coded by: bh  At: 2013/10/31 17:14
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
     public  class BGReimAppendixManager
    {
        #region 添加一条附件信息
        /// <summary>
        /// 添加一条附件信息
        /// </summary>
        /// <param name="radid">附件</param>
        /// <returns>bool</returns>
         public static bool AddAccessories(BG_ReimAppendix radid)
         {
             return BGReimAppendixService.AddAccessories(radid);
         } 

        #endregion

         #region 查询一条附件信息
         /// <summary>
         /// 查询一条附件信息
         /// </summary>
         /// <param name="radid">附件信息</param>
         /// <returns>BGUser</returns>
         public static DataTable GetAccessories(string radid)
         {
             return BGReimAppendixService.GetAccessories(radid);
         }
         #endregion

         #region 修改指定报销附件信息
         /// <summary>
         /// 修改指定报销附件信息
         /// </summary>
         /// <param name="radid">附件信息</param>
         /// <returns>bool</returns>
         public static bool UpdAccessories(BG_ReimAppendix radid)
         {
             return BGReimAppendixService.UpdAccessories(radid);
         }
         #endregion
         #region 删除指定报销附件信息
         /// <summary>
         ///删除指定报销附件信息
         /// </summary>
         /// <param name="radid">附件信息</param>
         /// <returns>bool</returns>
         public static bool DelAccessories(int  radid)
         {
             return BGReimAppendixService.DelAccessories(radid);
         }
         #endregion
    
    
        /// <summary>
        /// 查询一条指定附件信息
        /// </summary>
        /// <param name="arid">附件信息ID</param>
        /// <returns>BG_ReimAppendix</returns>
         public static BG_ReimAppendix GetAcc(string arid)
         {
             return BGReimAppendixService.GetAcc(arid);
         }
     
     }
}
