//============================================================
// Coded by: bh  At: 2013/10/31 17:14
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
    public class BGApplyReimburService
    {
        #region 添加一条报销申请信息
        /// <summary>
        /// 添加一条报销申请信息
        /// </summary>
        /// <param name="ar">报销申请信息</param>
        /// <returns>bool</returns>
        public static int AddApplyReimbur(BG_ApplyReimbur ar)
        {

            int reIdentity = 0;
            try
            {
                string sqlStr = @"insert into BG_ApplyReimbur(ARTime,DepID,ARReiSinNum,ARExpType,PPID,ARRepDep,ARAgent,ARMon,ARExcu,ARListSta) 
            values(@ARTime,@DepID,@ARReiSinNum,@ARExpType,@PPID,@ARRepDep,@ARAgent,@ARMon,@ARExcu,@ARListSta);select IDENT_CURRENT('BG_ApplyReimbur')";//select @@identity;

                SqlParameter[] Pars = {
                        
                        new SqlParameter("@ARTime",ar.ARTime),
                        new SqlParameter("@DepID",ar.DepID),
                        new SqlParameter("@ARReiSinNum",ar.ARReiSinNum),
                        new SqlParameter("@ARExpType",ar.ARExpType),
                        //new SqlParameter("@ARExpPro",ar.ARExpPro),
                        new SqlParameter("@PPID",ar.PPID),
                        new SqlParameter("@ARRepDep",ar.ARRepDep),
                        new SqlParameter("@ARAgent",ar.ARAgent),
                        new SqlParameter("@ARMon",ar.ARMon),
                        new SqlParameter("@ARExcu",ar.ARExcu),
                        new SqlParameter("@ARListSta",ar.ARListSta)
                       
                       
                        };
                //falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
                string iden = DBUnity.ExecuteScalar(CommandType.Text, sqlStr, Pars);
                reIdentity = Utils.IntSafeConvert(iden);
            }
            catch (Exception ex)
            {
                reIdentity = 0;
                Log.WriteLog(ex.Message, "BudgetSys.DAL.BGApplyReimburService.AddApplyReimbur");
            }
            return reIdentity;

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
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_ApplyReimbur where ARID='{0}'";
                sqlStr = string.Format(sqlStr, arid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BudgetSys.DAL.BGApplyReimburService.GetApplyReimbur");
            }
            return dt;
        }
        #endregion

        #region 查询指定部门下所有报销(按状态查询的)信息
        /// <summary>
        /// 查询指定部门下所有报销(按状态查询的)信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburByDepID(int DepID, string yearmonth, string sta)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from vApplyDepPayPrj where DepID={0} and  convert(varchar(7),ARTime,120)='{1}' and ARListSta='{2}' order by ARID desc";
                sqlStr = string.Format(sqlStr, DepID, yearmonth, sta);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BudgetSys.DAL.GetApplyReimburByDepID.GetApplyReimbur");
            }
            return dt;
        }
        #endregion
        public static DataTable GetApplyReimburByDepIDExport(int DepID, string yearmonth, string sta)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select ARTime,ARReiSinNum,ARRepDep,ARAgent,ARMon,ARExcu,ARListSta from vApplyDepPayPrj where DepID={0} and  convert(varchar(7),ARTime,120)='{1}' and ARListSta='{2}' order by ARID desc";
                sqlStr = string.Format(sqlStr, DepID, yearmonth, sta);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BudgetSys.DAL.GetApplyReimburByDepID.GetApplyReimbur");
            }
            return dt;
        }
        #region 查询所有部门下所有报销(按状态查询的)信息
        /// <summary>
        /// 查询所有部门下所有报销(按状态查询的)信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburAll(string yearmonth, string sta)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from vApplyDepPayPrj where convert(varchar(7),ARTime,120)='{0}' and ARListSta='{1}' order by ARID desc";
                sqlStr = string.Format(sqlStr, yearmonth, sta);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BudgetSys.DAL.GetApplyReimburByDepID.GetApplyReimbur");
            }
            return dt;
        }
        #endregion
        public static DataTable GetApplyReimburAllExport(string yearmonth, string sta)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select ARTime,ARReiSinNum,ARRepDep,ARAgent,ARMon,ARExcu,ARListSta from vApplyDepPayPrj where convert(varchar(7),ARTime,120)='{0}' and ARListSta='{1}' order by ARID desc";
                sqlStr = string.Format(sqlStr, yearmonth, sta);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BudgetSys.DAL.GetApplyReimburByDepID.GetApplyReimbur");
            }
            return dt;
        }
        #region 修改指定报销申请信息
        /// <summary>
        /// 修改指定报销申请信息
        /// </summary>
        /// <param name="ar">报销申请信息</param>
        /// <returns>bool</returns>
        public static bool UpdApplyReimbur(BG_ApplyReimbur ar)
        {
            bool flag = false;
            try
            {
                string sqlStr = @"update  BG_ApplyReimbur set DepID=@DepID, ARTime=@ARTime,ARReiSinNum=@ARReiSinNum,ARExpType=@ARExpType,
                                 PPID=@PPID,ARRepDep=@ARRepDep,ARAgent=@ARAgent,ARMon=@ARMon,ARExcu=@ARExcu,ARListSta=@ARListSta where  ARID=@ARID";
                SqlParameter[] Pars = new SqlParameter[]{
                        new SqlParameter("@ARID",ar.ARID),
                        new SqlParameter("@DepID",ar.DepID),
                        new SqlParameter("@ARTime",ar.ARTime),
                        new SqlParameter("@ARReiSinNum",ar.ARReiSinNum),
                        new SqlParameter("@ARExpType",ar.ARExpType),
                        new SqlParameter("@PPID",ar.PPID),
                        new SqlParameter("@ARRepDep",ar.ARRepDep),
                        new SqlParameter("@ARAgent",ar.ARAgent),
                        new SqlParameter("@ARMon",ar.ARMon),
                        new SqlParameter("@ARExcu",ar.ARExcu),
                        new SqlParameter("@ARListSta",ar.ARListSta)
                       
                        };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BudgetSys.DAL.BGApplyReimburService.UpdApplyReimbur");
            }

            return flag;
        }
        #endregion

        #region 删除指定报销申请信息
        /// <summary>
        ///删除指定报销申请信息
        /// </summary>
        /// <param name="arreisinnum">报销申请信息</param>
        /// <returns>bool</returns>
        public static bool DelApplyReimbur(string arreisinnum)
        {
            bool falg = false;
            try
            {
                string sqlStr = "delete from  BG_ApplyReimbur where ARID=@ARID";

                SqlParameter[] Pars = new SqlParameter[]{
                       new SqlParameter("@ARID",arreisinnum)
                        };
                falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch (Exception ex)
            {
                falg = false;
                Log.WriteLog(ex.Message, "BudgetSys.DAL.BGApplyReimburService.DelApplyReimbur");
            }
            return falg;
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
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_ApplyReimbur where ARRepDep='{0}'";
                sqlStr = string.Format(sqlStr, arrepdep);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BudgetSys.DAL.BGApplyReimburService.SelApplyReimbur");
            }

            return dt;
        }
        #endregion

        #region 更改申请表状态
        /// <summary>
        /// 更改申请表状态
        /// </summary>
        /// <param name="arid">申请表ID</param>
        /// <param name="arliststa">申请表状态</param>
        /// <returns>bool</returns>
        public static bool UpdApplicationStatus(string status, string idStrs)
        {
            bool flag = false;
            try
            {
                string sqlStr = "update  BG_ApplyReimbur set ARListSta='{0}' where  ARID in ({1})";
                //SqlParameter[] Pars = new SqlParameter[]{
                //        new SqlParameter("@ARID",arid),
                //        new SqlParameter("@ARListSta",arliststa),
                //        };

                sqlStr = string.Format(sqlStr, status, idStrs);
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, null) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BudgetSys.DAL.BGApplyReimburService.UpdApplicationStatus");
            }

            return flag;
        }
        #endregion

        #region 更改申请表状态
        /// <summary>
        /// 更改申请表状态
        /// </summary>
        /// <param name="arid">申请表ID</param>
        /// <param name="arliststa">申请表状态</param>
        /// <returns>bool</returns>
        public static bool UpdApplicationStatus1(int PIID,string status, string arexptype, string idStrs)
        {
            bool flag = false;
            try
            {
                string sqlStr = "update  BG_ApplyReimbur set ARListSta='{0}' , ARExpType='{1}' ,PPID='{3}' where  ARID in ({2})";
                //SqlParameter[] Pars = new SqlParameter[]{
                //        new SqlParameter("@ARID",arid),
                //        new SqlParameter("@ARListSta",arliststa),
                //        };

                sqlStr = string.Format(sqlStr, status, arexptype, idStrs, PIID);
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, null) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BudgetSys.DAL.BGApplyReimburService.UpdApplicationStatus");
            }

            return flag;
        }
        #endregion

        #region 更改申请表状态
        /// <summary>
        ///显示退回原因
        /// </summary>
        /// <param name="arid">申请表ID</param>
        /// <param name="arliststa">申请表状态</param>
        /// <returns>bool</returns>
        public static bool UpdApplication(string status, string txt, string idStrs)
        {
            bool flag = false;
            try
            {
                string sqlStr = "update  BG_ApplyReimbur set ARListSta='{0}', ARReason='{1}' where ARID in ({2})";
                //SqlParameter[] Pars = new SqlParameter[]{
                //        new SqlParameter("@ARID",arid),
                //        new SqlParameter("@ARListSta",arliststa),
                //        };

                sqlStr = string.Format(sqlStr, status, txt, idStrs);
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, null) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BudgetSys.DAL.BGApplyReimburService.UpdApplication");
            }

            return flag;
        }
        #endregion
        #region 查询指定部门下所有报销(按状态查询的)信息
        /// <summary>
        /// 查询指定部门下所有报销(按状态查询的)信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetByDepID(int DepID, string yearmonth)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from vApplyDepPayPrj where DepID={0} and CONVERT(varchar(7),ARTime, 120 ) ='" + "{1}'" + " and ARListSta in ('未提交','退回') order by ARID desc";
                sqlStr = string.Format(sqlStr, DepID, yearmonth);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BudgetSys.DAL.GetApplyReimburByDepID.GetApplyReimbur");
            }
            return dt;
        }
        #endregion


        #region 查询指定部门下查询报销单据状态
        /// <summary>
        /// 查询指定部门下查询报销单据状态 
        /// </summary>
        /// <param name="arid">报销申请状态</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyStateByDepID(int DepID, string yearmonth)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from vApplyDepPayPrj where DepID={0} and convert(varchar(7),ARTime,120)='{1}' and ARListSta in ('提交','审核通过') order by ARID desc";
                sqlStr = string.Format(sqlStr, DepID, yearmonth);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BudgetSys.DAL.GetApplyReimburByDepID.GetApplyReimbur");
            }
            return dt;
        }
        #endregion
        public static DataTable GetApplyStateByDepIDExport(int DepID, string yearmonth)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select ARTime,ARReiSinNum,ARRepDep,ARAgent,ARMon,ARExcu,ARListSta from vApplyDepPayPrj where DepID={0} and convert(varchar(7),ARTime,120)='{1}' and ARListSta in ('提交','审核通过') order by ARID desc";
                sqlStr = string.Format(sqlStr, DepID, yearmonth);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BudgetSys.DAL.GetApplyReimburByDepID.GetApplyReimbur");
            }
            return dt;
        }
        #region 查询所有部门下所有报销(按状态查询的)信息
        /// <summary>
        /// 查询所有部门下所有报销(按状态查询的)信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetByAll(int year)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from vApplyDepPayPrj where year(ARTime)={0} and ARListSta in ('未提交','退回') order by ARID desc";
                sqlStr = string.Format(sqlStr, year);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BudgetSys.DAL.GetApplyReimburByDepID.GetApplyReimbur");
            }
            return dt;
        }
        #endregion

        #region 查询指定部门下所有报销(按状态查询的)信息
        /// <summary>
        /// 查询指定部门下所有报销(按状态查询的)信息
        /// </summary>
        /// <param name="arid">报销申请信息</param>
        /// <returns>BGUser</returns>
        public static DataTable GetApplyReimburByAll(string yearmonth, string sta)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from vApplyDepPayPrj where  convert(varchar(7),ARTime,120)='{0}' and ARListSta='{1}'";
                sqlStr = string.Format(sqlStr, yearmonth, sta);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BudgetSys.DAL.GetApplyReimburByDepID.GetApplyReimbur");
            }
            return dt;
        }
        #endregion
    }
}
