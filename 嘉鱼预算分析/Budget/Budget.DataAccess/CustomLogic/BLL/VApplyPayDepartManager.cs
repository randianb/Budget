using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using BudgetWeb.DAL;
using BudgetWeb.Model;

namespace BudgetWeb.BLL
{
    public  class VApplyPayDepartManager
    {
         #region 根据视图查询信息
        /// <summary>
        /// 根据视图查询信息
        /// </summary>
        /// <param name="depname">部门名称</param>
        /// <returns>DataTable</returns>
        public static DataTable GetVApplyPayDepartByDepName(string  depname)
        {
            return VApplyPayDepartService.GetVApplyPayDepartByDepName(depname);
        }
        #endregion

        #region 根据视图查询信息
        /// <summary>
        /// 根据视图查询信息
        /// </summary>
        /// <param name="depname">部门名称</param>
        /// <returns>DataTable</returns>
        public static DataTable SelVApplyPayDepartByDepName(string depname)
        {
            return VApplyPayDepartService.SelVApplyPayDepartByDepName(depname);
        }
        #endregion
    }
}
