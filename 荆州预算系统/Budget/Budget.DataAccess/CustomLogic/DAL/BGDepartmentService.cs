//============================================================
// Coded by: HG  At: 2013/10/30 15:44
//============================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using Common;

namespace BudgetWeb.DAL
{
    public class BGDepartmentService
    {
        #region 添加一条部门记录
        /// <summary>
        /// 添加一条部门记录
        /// </summary>
        /// <param name="dep">一个部门实例</param>
        /// <returns>bool</returns>
        public static bool AddDep(BG_Department dep)
        {
            bool falg = false;
            string sqlStr = @"insert into BG_Department(DepLev,DepCode,DepName,DepQua,DepSta,DepRem,FaDepID) values 
                (@DepLev,@DepCode,@DepName,@DepQua,@DepSta,@DepRem, @FaDepID)";
            try
            {
                SqlParameter[] pars = new SqlParameter[]{
                          new SqlParameter("@DepLev",dep.DepLev),
                          new SqlParameter("@DepCode",dep.DepCode),
                          new SqlParameter("@DepName",dep.DepName),
                          new SqlParameter("@DepQua",dep.DepQua),
                          new SqlParameter("@DepSta",dep.DepSta),
                          new SqlParameter("@DepRem",dep.DepRem),
                          new SqlParameter("@FaDepID",dep.FaDepID)
                                  };
                falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, pars) > 0;
            }
            catch (Exception ex)
            {
                falg = false;
                Log.WriteLog(ex.Message, "BGDepartmentService--AddDep");
            }
            return falg;
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
            bool falg = false;
            try
            {
                string sqlStr = "delete from BG_Department where DepID=@DepID";
                SqlParameter[] pars = new SqlParameter[]{
                          new SqlParameter("@DepID",depid)    
                                };
                falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, pars) > 0;
            }
            catch (Exception ex)
            {
                falg = false;
                Log.WriteLog(ex.Message, "BGDepartmentService--DelDep");
            }
            return falg;
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
            BG_Department dep = new BG_Department();
            try
            {
                string sqlStr = "select * from BG_Department where DepID='{0}'";
                sqlStr = string.Format(sqlStr, depid);
                DataTable dt = DBUnity.AdapterToTab(sqlStr);
                if (dt.Rows.Count > 0)
                {
                    dep.DepID = (int)dt.Rows[0]["DepID"];
                    dep.DepLev = (int)dt.Rows[0]["DepLev"];
                    dep.FaDepID = (int)dt.Rows[0]["FaDepID"];
                    dep.DepCode = dt.Rows[0]["DepCode"].ToString();
                    dep.DepName = dt.Rows[0]["DepName"].ToString();
                    dep.DepQua = dt.Rows[0]["DepQua"].ToString();
                    dep.DepSta = dt.Rows[0]["DepSta"].ToString();
                    dep.DepRem = dt.Rows[0]["DepRem"].ToString();
                }
            }
            catch (Exception ex)
            {
                dep = new BG_Department();
                Log.WriteLog(ex.Message, "BGDepartmentService--GetDepBydepid");
            }
            return dep;
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
            bool falg = false;
            try
            {
                string sqlStr = @"update BG_Department set DepLev=@DepLev,FaDepID=@FaDepID,DepCode=@DepCode,
DepName=@DepName,DepQua=@DepQua,DepSta=@DepSta,DepRem=@DepRem where DepID=@DepID";
                SqlParameter[] pars = new SqlParameter[]{
                                new SqlParameter("@DepID",dep.DepID),
                                new SqlParameter("@DepLev",dep.DepLev),
                                new SqlParameter("@FaDepID",dep.FaDepID),
                                new SqlParameter("@DepCode",dep.DepCode),
                                new SqlParameter("@DepName",dep.DepName),
                                new SqlParameter("@DepQua",dep.DepQua),
                                new SqlParameter("@DepSta",dep.DepSta),
                                new SqlParameter("@DepRem",dep.DepRem)
                                };
                falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, pars) > 0;
            }
            catch (Exception ex)
            {
                falg = false;
                Log.WriteLog(ex.Message, "BGDepartmentService--UpdDpe");
            }
            return falg;
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
            bool falg = false;
            try
            {
                string sqlStr = "update BG_Department set DepSta=@DepSta where DepID=@DepID";
                SqlParameter[] pars = new SqlParameter[]{
                                new SqlParameter("@DepID",depid.DepID),
                                new SqlParameter("@DepSta",depid.DepSta)
                                };
                falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, pars) > 0;
            }
            catch (Exception ex)
            {
                falg = false;
                Log.WriteLog(ex.Message, "BGDepartmentService--UpdDepSta");
            }
            return falg;
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
            bool flag = false;
            try
            {
                string sqlStr = "select Count(*) from BG_User where FaDepID=@FaDepID";
                SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@FaDepID", depid) };
                flag = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, pars)) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGDepartmentService--GetUseByDepID");
            }
            return flag;
        }
        #endregion

        #region 查询指定部门级别下的所有部门
        /// <summary>
        /// 查询指定部门级别下的所有部门
        /// </summary>
        /// <param name="depLev">部门级别</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDepBydepID(int depLev)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select *  from BG_Department where FaDepID ={0} order by DepCode desc";
                sqlStr = string.Format(sqlStr, depLev);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGDepartmentService--GetDepBydepLev");
            }
            return dt;
        }


        /// <summary>
        /// 查询指定部门级别下的所有部门
        /// </summary>
        /// <param name="depLev">部门级别</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDepBydepLev(int depLev)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select *  from BG_Department where DepLev ={0}";
                sqlStr = string.Format(sqlStr, depLev);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGDepartmentService--GetDepBydepLev");
            }
            return dt;
        }
        #endregion

        #region 获取所有部门信息
        /// <summary>
        /// 获取所有部门信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllDepInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select *  from BG_Department";
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BudgetSys.DAL.BGDepartmentService.GetDepBydepLev");
            }
            return dt;
        }

        #endregion

        #region 根据DepID查询BG_Department表(自身与子部门)
        /// <summary>
        /// 根据FaDepID查询BG_Department表
        /// </summary>
        /// <param name="fadepid">FaDepID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDepByDepid(int DepID)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = string.Format("select *  from BG_Department where FaDepID ={0} or DepID={0}", DepID);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGDepartmentService--GetDepByfadepid");
            }
            return dt;
        }
        #endregion

        #region 根据FaDepID查询BG_Department表
        /// <summary>
        /// 根据FaDepID查询BG_Department表
        /// </summary>
        /// <param name="fadepid">FaDepID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDepByfadepid(int fadepid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select *  from BG_Department where FaDepID ={0}";
                sqlStr = string.Format(sqlStr, fadepid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGDepartmentService--GetDepByfadepid");
            }
            return dt;
        }
        #endregion

        /// <summary>
        /// 查询所有的部门名称
        /// </summary>
        /// <param name="depname">depname</param>
        /// <returns>DataTable</returns>
        public static DataTable GetAllDepName(string depname)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_Department where DepName=@DepName";
                sqlStr = string.Format(sqlStr, depname);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGDepartmentService--GetAllDepName");
            }
            return dt;
        }


        public static string GetDepNameBydepid(int depid)
        {
            string dname = "";
            string sqlStr = "select DepName from BG_Department where DepID={0}";
            sqlStr = string.Format(sqlStr, depid);
            dname = DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null); 
            return dname;
        }
    }
}
