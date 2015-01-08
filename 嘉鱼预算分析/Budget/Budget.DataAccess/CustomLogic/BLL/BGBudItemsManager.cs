//============================================================
// Coded by: PF  At: 2013/10/31 17:09
//============================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.DAL;
using BudgetWeb.Model;
using System.Data.SqlClient;

namespace BudgetWeb.BLL
{
    public class BGBudItemsManager  
    {
        /// <summary>
        /// 获取项目自增编号
        /// </summary>
        /// <returns></returns>
        public static string GetBICode(string year)
        {
            return BGBudItemsService.GetBICode(year);
        }

        #region 添加一条预算项目信息
        /// <summary>
        /// 添加一条预算项目信息
        /// </summary>
        /// <param name="budItems">一条预算项目实例</param>
        /// <returns>bool</returns>
        public static bool AddbudItems(BG_BudItems budItems)
        {
            return BGBudItemsService.AddbudItems(budItems);
        }
        #endregion
        #region  查询一条预算项目信息
        /// <summary>
        /// 通过预算项目ID查询信息
        /// </summary>
        /// <param name="budItems">项目ID</param>
        /// <returns>BGBudItems</returns>
        public static DataTable GetBudItemsListByBudItemsID(int Budid)
        {
            return BGBudItemsService.GetBudItemsListByBudid(Budid);
        }
        #endregion
        #region  修改指定预算项目信息
        /// <summary>
        /// 修改指定预算项目信息
        /// </summary>
        /// <param name="budItems">BGBudItems</param>
        /// <returns>bool</returns>
        public static bool UpdBudItems(BG_BudItems budItems)
        {
            return BGBudItemsService.UpdBudItems(budItems);
        }
        #endregion
        #region 删除指定预算项目信息
        /// <summary>
        /// 删除指定预算项目信息
        /// </summary>
        /// <param name="budID">BudID</param>
        /// <returns>bool</returns>
        public static bool DelBud(int budID)
        {
            return BGBudItemsService.DelBud(budID);
        }
        #endregion
        #region 更改预算项目状态
        /// <summary>
        /// 更改预算项目状态
        /// </summary>
        /// <param name="budid">BudID</param>
        /// <returns>bool</returns>
        public static bool UpdBudSta(int budid, string status)
        {
            return BGBudItemsService.UpdBudSta(budid, status);
        }
        #endregion
        #region  填写审核不通过原因

        /// <summary>
        ///填写审核不通过原因
        /// </summary>
        /// <param name="budItems">BICause</param>
        /// <returns>BGBudItems</returns>
        public static bool SelBi(string bICause)
        {
            return BGBudItemsService.SelBi(bICause);
        }
        #endregion


        #region 根据部门ID查询未提交与退回的预算项目

        /// <summary>
        /// 根据部门ID查询BudItemsList
        /// </summary>
        /// <param name="Depid">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetBudItemsListByDepid(int Depid)
        {
            return BGBudItemsService.GetBudItemsListByDepid(Depid);
        }
        #endregion

        #region 根据部门ID查询BudItemsList(未提交、退回)分页
        /// <summary>
        /// 根据部门ID查询BudItemsList(未提交、退回)
        /// </summary>
        /// <param name="Depid">部门ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetBudItemsListByDepidPager(int Depid, int pageIndex, int PageSize, out int RecordCount)
        {
            return BGBudItemsService.GetBudItemsListByDepidPager(Depid, pageIndex, PageSize, out RecordCount);
        }
        #endregion

        

        #region 查询指定部门下所有报销未提交信息
        /// <summary>
        /// 查询指定部门下所有报销未提交信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburWByDepID(int DepID)
        {
            return BGBudItemsService.GetApplyReimburByDepID(DepID, "未提交");
        }
        #endregion


        #region 查询指定部门下所有报销已提交信息
        /// <summary>
        /// 查询指定部门下所有报销已提交信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburTByDepID(int DepID)
        {
            return BGBudItemsService.GetApplyReimburByDepID(DepID, "提交");
        }
        #endregion

        #region 查询指定部门下所有预算(按状态查询的)信息分页
        /// <summary>
        /// 查询指定部门下所有预算(按状态查询的)信息
        /// </summary>
        /// <param name="arid">预算信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburByDepIDPager(int DepID, string sta, int pageIndex, int PageSize, out int RecordCount, int CurrentYear)
        {
            return BGBudItemsService.GetApplyReimburByDepIDPager(DepID, sta, pageIndex, PageSize, out RecordCount, CurrentYear);
        }
        #endregion


        #region 查询指定部门下所有预算(按状态查询的)信息
        /// <summary>
        /// 查询指定部门下所有预算(按状态查询的)信息
        /// </summary>
        /// <param name="arid">预算信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburByDepID(int DepID, string sta)
        {
            return BGBudItemsService.GetApplyReimburByDepID(DepID, sta);
        }
        #endregion

        public static DataTable GetBIPagerByProtypeYear(string protype, string year, int pageIndex, int PageSize, out int RecordCount)
        {
            return BGBudItemsService.GetBIPagerByProtypeYear(protype, year, pageIndex, PageSize, out RecordCount);
        }

        #region  查询指定部门下所有已上报预算信息
        /// <summary>
        /// 查询指定部门下所有已上报预算信息
        /// </summary>
        /// <param name="arid">部门ID</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReportByDepID(int DepID)
        {
            return BGBudItemsService.GetApplyReimburByDepID(DepID, "已上报");
        }
        #endregion

        #region 查询指定部门下所有报销审核通过信息
        /// <summary>
        /// 查询指定部门下所有报销审核通过信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburSByDepID(int DepID)
        {
            return BGBudItemsService.GetApplyReimburByDepID(DepID, "审核通过");
        }
        #endregion


        /// <summary>
        /// 添加BGBudItems并返回其ID
        /// </summary>
        /// <param name="budItems"></param>
        /// <returns>int</returns>
        public static int AddBudItemsBackbuid(BG_BudItems budItems)
        {
            return BGBudItemsService.AddBudItemsBackbuid(budItems);
        }


        /// <summary>
        /// 根据Budid获取单条BGBudItems记录
        /// </summary>
        /// <param name="biid"></param>
        /// <returns></returns>
        public static BG_BudItems GetBudItemsByBudid(int Budid)
        {
            return BGBudItemsService.GetBudItemsByBudid(Budid);
        }

        #region 按项目类型汇总
        /// <summary>
        /// 按项目类型汇总
        /// </summary>
        /// <param name="arid">预算信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetSummaryBudInfo(string sta)
        {
            return BGBudItemsService.GetSummaryBudInfo(sta);
        }
        #endregion

        #region 按项目类型汇总(分页)
        /// <summary>
        /// 按项目类型汇总123
        /// </summary>
        /// <param name="arid">预算信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetSummaryBudInfoPager(string sta, int pageIndex, int pageSize, out int RecordCount, int CurrentYear)
        {
            return BGBudItemsService.GetSummaryBudInfoPager(sta, pageIndex, pageSize, out RecordCount, CurrentYear);
        }
        #endregion



        #region 查询指定部门下所有预算信息分页
        /// <summary>
        /// 查询指定部门下所有预算信息
        /// </summary>
        /// <param name="arid">预算信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburByDepIDPager(int DepID, int pageIndex, int PageSize, out int RecordCount)
        {
            return BGBudItemsService.GetApplyReimburByDepIDPager(DepID, pageIndex, PageSize, out RecordCount);
        }
        #endregion

        #region 查询指定部门下所有预算信息
        /// <summary>
        /// 查询指定部门下所有预算信息
        /// </summary>
        /// <param name="arid">预算信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburByDepID(int DepID)
        {
            return BGBudItemsService.GetApplyReimburByDepID(DepID);
        }
        #endregion
         
    }
}
