using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using Common;
using System.Data;

namespace BudgetWeb.DAL
{
     public  class BGProvBudItemsService
     {
         #region 查询省级下发预算项目
         /// <summary>
         /// 查询省级下发预算项目
        /// </summary>
         /// <param name="depid">预算项目</param>
         /// <returns>BGProvBudItems</returns>
         public static DataTable GetBGProvBudItems(int  depid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_ProvBudItems where DepID={0}";
                sqlStr = string.Format(sqlStr, depid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BudgetSys.DAL.BGProvBudItemsService.GetBGProvBudItems");
            }
            return dt;
        }
        #endregion
    }
}
