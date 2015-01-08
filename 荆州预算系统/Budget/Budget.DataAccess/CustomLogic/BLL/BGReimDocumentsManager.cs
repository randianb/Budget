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
     public  class BGReimDocumentsManager
    {
        #region 添加一条报销单据
        /// <summary>
        /// 添加一条报销单据
        /// </summary>
        /// <param name="arid">报销单据</param>
        /// <returns>bool</returns>
         public static bool AddARID(BG_ReimDocuments arid)
        {
            return BGReimDocumentsService.AddARID(arid);
           
        }

        #endregion

        #region 查询一条指定报销单据
        /// <summary>
        /// 查询一条指定报销单据
        /// </summary>
         /// <param name="arid">报销单据</param>
        /// <returns>BGUser</returns>
         public static DataTable GetReimDocuments(string  arid)
        {
            return BGReimDocumentsService.GetReimDocuments(arid);
        }
        #endregion

        #region 修改指定报销单据
        /// <summary>
        /// 修改指定报销单据
        /// </summary>
         /// <param name="arid">报销单据</param>
        /// <returns>bool</returns>
         public static bool UpdReimDocuments(BG_ReimDocuments arid)
        {
            return BGReimDocumentsService.UpdReimDocuments(arid);
        }
        #endregion

        #region 删除指定报销单据
        /// <summary>
        ///删除指定报销单据
        /// </summary>
         /// <param name="arid">报销单据</param>
        /// <returns>bool</returns>
         public static bool DelReimDocuments(int  arid)
        {
            return BGReimDocumentsService.DelReimDocuments(arid);
        }
        #endregion

         #region 查询一条指定报销单据
         /// <summary>
         /// 查询一条指定报销单据
         /// </summary>
         /// <param name="arid">报销单据ID</param>
         /// <returns>BGReimDocuments</returns>
         public static BG_ReimDocuments GetReimDocByArid(string arid)
         {
             return BGReimDocumentsService.GetReimDocByArid(arid);
         }
         #endregion
    }
}
