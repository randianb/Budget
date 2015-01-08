//============================================================
// Coded by: PF  At: 2013/10/31 15:17
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
    public class BGBudAppendixService
    {
        #region 添加预算项目附件信息
        /// <summary>
        /// 添加预算项目附件信息
        /// </summary>
        /// <returns>bool</returns>
        public static bool AddBudAppendix(BG_BudAppendix BudAppendix)
        {
            bool flag = false;
            try
            {
                string sqlStr = @"insert into BG_BudAppendix(BudID,APPath,ApName,ApTime) 
                values(@BudID,@APPath,@ApName,@ApTime)";

                SqlParameter[] Pars = new SqlParameter[]{
                        new SqlParameter("@BudID",BudAppendix.BudID),
                        new SqlParameter("@APPath",BudAppendix.APPath),
                        new SqlParameter("@ApName",BudAppendix.ApName),
                        new SqlParameter("@ApTime",BudAppendix.ApTime)
                        
                        };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGBudAppendixService--AddBudAppendix");
            }
            return flag;
        }
        #endregion
        #region 修改指定预算项目附件信息
        /// <summary>
        /// 修改指定预算项目附件信息
        /// </summary>
        /// <param name="BudAppendix">BGBudAppendix</param>
        /// <returns>bool</returns>
        public static bool UpdBudAppendix(BG_BudAppendix BudAppendix)
        {
            bool flag = false;
            try
            {
                string sqlStr = @"update from BG_BudAppendix set APID = @APID,BudID=@BudID,APPath=@APPath,
            ApName=@ApName,ApTime=@ApTime where APID = @APID";
                SqlParameter[] Pars = new SqlParameter[]{
                        new SqlParameter("@APID",BudAppendix.APID),
                        new SqlParameter("@BudID",BudAppendix.BudID),
                        new SqlParameter("@APPath",BudAppendix.APPath),
                        new SqlParameter("@ApName",BudAppendix.ApName),
                        new SqlParameter("@ApTime",BudAppendix.ApTime)
                        
                        };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGBudAppendixService--UpdBudAppendix");
            }
            return flag;
        }
        #endregion
        #region 查询指定一条预算项目附件信息
        /// <summary>
        /// 查询指定一条预算项目附件信息
        /// </summary>
        /// <param name="apid">预算项目附件ID</param>
        /// <returns>BGDepartment</returns>
        public static BG_BudAppendix GetBudAppendixByapid(int apid)
        {
            BG_BudAppendix BudAppendix = new BG_BudAppendix();
            string sqlStr = "select * from BG_BudAppendix where APID={0}";
            sqlStr = string.Format(sqlStr, apid);
            DataTable dt = DBUnity.AdapterToTab(sqlStr);
            if (dt.Rows.Count > 0)
            {
                BudAppendix.APID = (int)dt.Rows[0]["APID"];
                BudAppendix.BudID = (int)dt.Rows[0]["BudID"];
                BudAppendix.APPath = dt.Rows[0]["APPath"].ToString();
                BudAppendix.ApName = dt.Rows[0]["ApName"].ToString();
                BudAppendix.ApTime = (DateTime)dt.Rows[0]["ApTime"];

            }
            return BudAppendix;
        }
        #endregion
        #region 删除指定预算项目附件信息
        /// <summary>
        /// 删除指定预算项目附件信息
        /// </summary>
        /// <param name="aid">APID</param>
        /// <returns>bool</returns>
        public static bool DelBudAppendix(int aid)
        {
            bool flag = false;
            try
            {
                string sqlStr = "delete from  BG_BudAppendix where APID = @APID";

                SqlParameter[] Pars = new SqlParameter[]{
                       new SqlParameter("@APID",aid)
                        };
                flag = DBUnity.ExecuteNonQuery
                    (CommandType.Text, sqlStr, Pars) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGBudAppendix--DelBudAppendix");
            }
            return flag;
        }
        #endregion
        #region 查询指定项目下的所有附件信息列表
        /// <summary>
        /// 查询指定项目下的所有附件信息列表
        /// </summary>
        /// <param name="apid">附件ID</param>
        /// <returns>DataTable</returns>
        public static DataTable GetBudAppendixListByApid(int apid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_BudAppendix where APID={0}";
                sqlStr = string.Format(sqlStr, apid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudAppendix--GetBudAppendixListByApid");
            }
            return dt;
        }
        #endregion


        public static DataTable GetBudAppListByBudid(int budid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select * from BG_BudAppendix where BudID={0}";
                sqlStr = string.Format(sqlStr, budid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGBudAppendix--GetBudAppListByBudid");
            }
            return dt;
        }
    }
}
