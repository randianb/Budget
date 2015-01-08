//============================================================
// Coded by: HG  At: 2013/10/31 15:35
//============================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using BudgetWeb.DAL;
using Common;

namespace BudgetWeb.BLL
{
    public class BGDepartmentManager
    {
        #region 添加一条部门记录
        /// <summary>
        /// 添加一条部门记录
        /// </summary>
        /// <param name="dep">一个部门实例</param>
        /// <returns>bool</returns>
        public static bool AddDep(BG_Department dep)
        {
            return BGDepartmentService.AddDep(dep);
        }
        #endregion

        #region 删除一条部门表记录
        /// <summary>
        /// 删除一条部门表记录
        /// </summary>
        /// <param name="depid">DepID</param>
        /// <returns>bool</returns>
        public static bool DelDep(int depid)
        {
            return BGDepartmentService.DelDep(depid);
        }
        #endregion

        #region 根据部门ID查询一条记录
        /// <summary>
        /// 根据部门ID查询一条记录
        /// </summary>
        /// <param name="depid">部门ID</param>
        /// <returns>BGDepartment</returns>
        public static BG_Department GetDepBydepid(string depid)
        {
            return BGDepartmentService.GetDepBydepid(depid);
        }
        #endregion

        #region 修改一条部门记录
        /// <summary>
        /// 修改一条部门记录
        /// </summary>
        /// <param name="dep">部门ID</param>
        /// <returns>bool</returns>
        public static bool UpdDpe(BG_Department dep)
        {
            return BGDepartmentService.UpdDpe(dep);
        }
        #endregion

        #region 更改部门状态(正常/禁用)
        /// <summary>
        /// 更改部门状态(正常/禁用)
        /// </summary>
        /// <param name="depid">DepID</param>
        /// <returns>bool</returns>
        public static bool UpdDepSta(BG_Department depid)
        {
            return BG_DepartmentService.ModifyBG_Department(depid);
        }
        #endregion

        #region 判断指定部门对应的人员表中是否有记录存在
        /// <summary>
        /// 判断指定部门对应的人员表中是否有记录存在
        /// </summary>
        /// <param name="depid">部门ID</param>
        /// <returns>bool</returns>
        public static bool GetUseByDepID(int depid)
        {
            return BGDepartmentService.GetUseByDepID(depid);
        }
        #endregion

        /// <summary>
        /// 查询指定部门级别下的所有部门
        /// </summary>
        /// <param name="depLev">depLev</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDepBydepID(int depID)
        {
            return BGDepartmentService.GetDepBydepID(depID);
            
        }

        /// <summary>
        /// 查询指定部门级别下的所有部门
        /// </summary>
        /// <param name="depLev">depLev</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDepBydepLev(int depLev)
        {
            return BGDepartmentService.GetDepBydepID(depLev);

        }




        #region 获取所有部门信息
        /// <summary>
        /// 获取所有部门信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllDepInfo()
        {
            return BGDepartmentService.GetAllDepInfo();
        }
        #endregion

        /// <summary>
        /// 根据FaDepID查询BG_Department表
        /// </summary>
        /// <param name="fadepid">FaDepID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDepByfadepid(int fadepid)
        {
            return BGDepartmentService.GetDepByfadepid(fadepid);
        }

    
        /// <summary>
        /// 根据DepID查询BG_Department表(自身与子部门)
        /// </summary>
        /// <param name="fadepid">DepID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDepByDepid(int Depid)
        {
            return BGDepartmentService.GetDepByDepid(Depid);
        }
        /// <summary>
        /// 查询所有的部门名称
        /// </summary>
        /// <param name="depname">depname</param>
        /// <returns>DataTable</returns>
        public static DataTable GetAllDepName(string depname)
        {
            return BGDepartmentService.GetAllDepName(depname);
        }



        public static string GetDepNameBydepid(int depid)
        {
            return BGDepartmentService.GetDepNameBydepid(depid);
        }
    }
}
