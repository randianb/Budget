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
     public  class BGReimDocumentsService
     {
         #region 添加一条报销单据(通过测试)
         /// <summary>
         /// 添加一条报销单据
        /// </summary>
         /// <param name="arid">报销单据</param>
        /// <returns>bool</returns>
         public static bool AddARID(BG_ReimDocuments arid)
        {

            bool falg = false;
            try
            {
                string sqlStr = @"insert into BG_ReimDocuments(ARID,RDType,RDCont,RDTime)values(@ARID,@RDType,@RDCont,@RDTime)";
                SqlParameter[] Pars = new SqlParameter[] {
                        new SqlParameter("@ARID",arid.ARID),
                        new SqlParameter("@RDType",arid.RDType),
                        new SqlParameter("@RDCont",arid.RDCont),
                        new SqlParameter("@RDTime",arid.RDTime)
                        };
                falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
            }
            catch (Exception ex)
            {
                falg = false;
                Log.WriteLog(ex.Message, "BudgetSys.DAL.BGReimDocumentsService.AddARID");
            }
            return falg;
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
             BG_ReimDocuments rm = new BG_ReimDocuments();
             try
             {
                 string sqlStr = "select * from BG_ReimDocuments where ARID={0} ";
                 sqlStr = string.Format(sqlStr, arid);
                 DataTable dt = DBUnity.AdapterToTab(sqlStr);
                 if (dt.Rows.Count > 0)
                 {
                     rm.ARID = common.IntSafeConvert(dt.Rows[0]["ARID"]);
                     rm.RDCont = dt.Rows[0]["RdCont"].ToString();
                     rm.RDTime = DateTime.Parse(dt.Rows[0]["RDTime"].ToString());
                     rm.RDType = dt.Rows[0]["RdType"].ToString();
                 }
             }
             catch (Exception ex)
             {
                 rm = new BG_ReimDocuments();
                 Log.WriteLog(ex.Message, "BudgetSys.DAL.BGReimDocumentsService.GetReimDocByArid");
             }

             return rm;
         }
         #endregion


         #region 查询一条指定报销单据
         /// <summary>
         /// 查询一条指定报销单据
         /// </summary>
         /// <param name="arid">报销单据</param>
         /// <returns>BGUser</returns>
         public static DataTable GetReimDocuments(string arid)
         {
             DataTable dt = new DataTable();
             try
             {
                 string sqlStr = "select * from BG_ReimDocuments where ARID={0} ";
                 sqlStr = string.Format(sqlStr, arid);
                 dt = DBUnity.AdapterToTab(sqlStr);
             }
             catch (Exception ex)
             {
                 dt = new DataTable();
                 Log.WriteLog(ex.Message, "BudgetSys.DAL.BGReimDocumentsService.GetReimDocuments");
             }
             
             return dt;
         }
         #endregion

         #region 修改指定报销单据(通过测试)
         /// <summary>
         /// 修改指定报销单据
         /// </summary>
         /// <param name="arid">报销单据</param>
         /// <returns>bool</returns>
         public static bool UpdReimDocuments(BG_ReimDocuments arid)
         {
             bool flag = false;
             try
             {
                 string sqlStr = @"update BG_ReimDocuments set RDType=@RDType,RDCont=@RDCont,RDTime=@RDTime  where ARID=@ARID";
                 SqlParameter[] Pars = new SqlParameter[] {
                        new SqlParameter("@ARID",arid.ARID),
                        new SqlParameter("@RDType",arid.RDType),
                        new SqlParameter("@RDCont",arid.RDCont),
                        new SqlParameter("@RDTime",arid.RDTime)
                        };
                 flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, Pars) > 0;
             }
             catch (Exception ex)
             {
                 flag = false;
                 Log.WriteLog(ex.Message, "BudgetSys.DAL.BGReimDocumentsService.UpdReimDocuments");
             }

             return flag;
         }
         #endregion

         #region 删除指定报销单据(通过测试)
         /// <summary>
         ///删除指定报销单据
         /// </summary>
         /// <param name="arid">报销单据</param>
         /// <returns>bool</returns>
         public static bool DelReimDocuments(int  arid)
         {
             bool falg = false;
             try
             {
                 string sqlStr = "delete from  BG_ReimDocuments where ARID=@ARID";

                 SqlParameter[] Pars = new SqlParameter[]{
                       new SqlParameter("@ARID",arid)
                        };
                 falg = DBUnity.ExecuteNonQuery
                     (CommandType.Text, sqlStr, Pars) > 0;
             }
             catch (Exception ex)
             {
                 falg = false;
                 Log.WriteLog(ex.Message, "BudgetSys.DAL.BGReimDocumentsService.DelReimDocuments");
             }
             return falg;
         }
         #endregion
    }
}
