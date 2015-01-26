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
    public class BGApplyReimburManager
    {
        #region 添加一条报销申请信息
        /// <summary>
        /// 添加一条报销申请信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>bool</returns>
        public static int AddApplyReimbur(BG_ApplyReimbur ar)
        {
            return BGApplyReimburService.AddApplyReimbur(ar);

        }

        #endregion
        #region 查询指定一条报销申请信息
        /// <summary>
        /// 查询指定一条报销申请信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimbur(string arid)
        {
            return BGApplyReimburService.GetApplyReimbur(arid);
        }
        #endregion

        #region 查询指定部门下所有报销未提交信息
        /// <summary>
        /// 查询指定部门下所有报销未提交信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetByDepID(int DepID, string yearmon)
        {
            return BGApplyReimburService.GetByDepID(DepID, yearmon);
        }
        #endregion

        #region 查询查询报销单据状态
        /// <summary>
        /// 查询查询报销单据状态
        /// </summary>
        /// <param name="arid">报销申请状态</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyStateByDepID(int DepID, string yearmonth)
        {
            return BGApplyReimburService.GetApplyStateByDepID(DepID, yearmonth);
        }
        #endregion
 public static DataTable GetApplyStateByDepIDExport(int DepID, string yearmonth)
        {
            return BGApplyReimburService.GetApplyStateByDepIDExport(DepID, yearmonth);
        }
        #region 查询指定部门下所有报销已提交信息
        /// <summary>
        /// 查询指定部门下所有报销已提交信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburTByDepID(int DepID, string yearmonth)
        {
            return BGApplyReimburService.GetApplyReimburByDepID(DepID, yearmonth, "提交");
        }
        #endregion

        #region 查询指定部门下所有报销审核通过信息
        /// <summary>
        /// 查询指定部门下所有报销审核通过信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburSByDepID(int DepID, string yearmon)
        {
            return BGApplyReimburService.GetApplyReimburByDepID(DepID, yearmon, "审核通过");
        }
        #endregion
        public static DataTable GetApplyReimburSByDepIDExport(int DepID, string yearmon)
        {
            return BGApplyReimburService.GetApplyReimburByDepIDExport(DepID, yearmon, "审核通过");
        }
        #region 查询所有部门下所有报销(按状态查询的)信息
        /// <summary>
        /// 查询所有部门下所有报销(按状态查询的)信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburAll(string yearmon)
        {
            return BGApplyReimburService.GetApplyReimburAll(yearmon, "审核通过");
        }
        #endregion
public static DataTable GetApplyReimburAllExport(string yearmon)
        {
            return BGApplyReimburService.GetApplyReimburAllExport(yearmon, "审核通过");
        }
        #region 修改指定报销申请信息
        /// <summary>
        /// 修改指定报销申请信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>bool</returns>
        public static bool UpdApplyReimbur(BG_ApplyReimbur ar)
        {
            return BGApplyReimburService.UpdApplyReimbur(ar);
        }
        #endregion

        #region 删除指定报销申请信息
        /// <summary>
        ///删除指定报销申请信息
        /// </summary>
        /// <param name="arreisinnum">报销申请信息</param>
        /// <returns>bool</returns>
        public static bool DelApplyReimbur(string  arreisinnum)
        {
            return BGApplyReimburService.DelApplyReimbur(arreisinnum);

        }
        #endregion

        #region 查询指定部门下的所有申请表
        /// <summary>
        /// 查询指定部门下的所有申请表
        /// </summary>
        /// <param name="arrepdep">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable SelApplyReimbur(string arrepdep)
        {
            return BGApplyReimburService.SelApplyReimbur(arrepdep);
        }
        #endregion

        #region 更改申请表状态
        /// <summary>
        /// 更改申请表状态
        /// </summary>
        /// <param name="arid">申请表ID</param>
        /// <param name="arliststa">申请表状态</param>
        /// <returns>bool</returns>
        public static bool UpdApplicationStatus(string  status, string idStrs)
        {
            return BGApplyReimburService.UpdApplicationStatus(status, idStrs);
        }
        #endregion

        #region 更改申请表状态
        /// <summary>
        /// 更改申请表状态
        /// </summary>
        /// <param name="arid">申请表ID</param>
        /// <param name="arliststa">申请表状态</param>
        /// <returns>bool</returns>
        public static bool UpdApplicationStatus1(int PIID,string status, string arexptype, string idStrs,string pro)
        {
            return BGApplyReimburService.UpdApplicationStatus1(PIID, status, arexptype, idStrs, pro);
        }
        #endregion

        #region 更改申请表状态
        /// <summary>
        /// 显示退回原因
        /// </summary>
        /// <param name="arid">申请表ID</param>
        /// <param name="arliststa">申请表状态</param>
        /// <returns>bool</returns>
        public static bool UpdApplication(string status,string txt,string idStrs)
        {
            return BGApplyReimburService.UpdApplication(status,txt,idStrs);
        }
        #endregion

        #region 查询所有部门下所有报销(按状态查询的)信息
        /// <summary>
        /// 查询所有部门下所有报销(按状态查询的)信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetByAll(int year)
        {
            return BGApplyReimburService.GetByAll(year);
        }
        #endregion

        #region 查询指定部门下所有报销(按状态查询的)信息
        /// <summary>
        /// 查询指定部门下所有报销(按状态查询的)信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburByAll(string yearmonth)
        {
            return BGApplyReimburService.GetApplyReimburByAll(yearmonth, "提交");
        }
        #endregion
    }
}
