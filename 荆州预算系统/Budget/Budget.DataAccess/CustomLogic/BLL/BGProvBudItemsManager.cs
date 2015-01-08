using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using Common;
using BudgetWeb.DAL;

namespace BudgetWeb.BLL
{
     public  class BGProvBudItemsManager
    {
        #region 查询省级下发预算项目
        /// <summary>
        /// 查询省级下发预算项目
        /// </summary>
        /// <param name="depid">预算项目</param>
        /// <returns>BGProvBudItems</returns>
        public static DataTable GetBGProvBudItems(int  depid)
        {
            return BGProvBudItemsService.GetBGProvBudItems(depid);
        }
        #endregion
    }
}
