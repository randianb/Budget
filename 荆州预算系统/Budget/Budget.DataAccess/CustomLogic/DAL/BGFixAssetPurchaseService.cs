using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetWeb.Model;
using Common;
using System.Data;
using System.Data.SqlClient;

namespace BudgetWeb.DAL
{
    public class BGFixAssetPurchaseService
    {
        /// <summary>
        /// 查询固定资产的FAName,FAModel,FABrand,FAPrice,FANum,FATime
        /// </summary>
        /// <param name="budid"></param>
        /// <returns>DataTable</returns>
        public static DataTable GetFix(int budid)
        {
            DataTable dt = new DataTable();
            string sqlStr = "select FAID,FAName,FAModel,FABrand,FAPrice,FANum,FATime from BG_FixAssetPurchase where BudID={0}";
            sqlStr = string.Format(sqlStr, budid);
            dt = DBUnity.AdapterToTab(sqlStr);
            return dt;
        }

        /// <summary>
        /// 根据faid查询固定资产情况
        /// </summary>
        /// <param name="budid"></param>
        /// <returns>DataTable</returns>
        public static DataTable GetFixByFaid(int faid)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlStr = "select FAName,FAMon,FAModel,FABrand,FAPrice,FANum,FATime from BG_FixAssetPurchase where FAID={0}";
                sqlStr = string.Format(sqlStr, faid);
                dt = DBUnity.AdapterToTab(sqlStr);
            }
            catch (Exception ex)
            {
                dt = new DataTable();
                Log.WriteLog(ex.Message, "BGFixAssetPurchaseService--GetFixByBudid");
            }
            return dt;
        }

        /// <summary>
        /// 根据Faid查询到一条BGFixAssetPurchase记录
        /// </summary>
        /// <param name="faid">FAID</param>
        /// <returns>BGFixAssetPurchase</returns>
        public static BG_FixAssetPurchase GetFAPByFaid(int faid)
        {
            BG_FixAssetPurchase fap = new BG_FixAssetPurchase();
            string sqlStr = "select * from BG_FixAssetPurchase where FAID={0}";
            sqlStr = string.Format(sqlStr, faid);
            try
            {
                 SqlDataReader dr = DBUnity.ExecuteReader(CommandType.Text,sqlStr,null);
            while (dr.Read())
            {
                fap.FAID = common.IntSafeConvert(dr["FAID"]);
                fap.BudID = common.IntSafeConvert(dr["BudID"]);
                fap.FAName = dr["FAName"].ToString();
                fap.FAModel = dr["FAModel"].ToString();
                fap.FABrand = dr["FABrand"].ToString();
                fap.FAPrice = ParseUtil.ToDecimal(dr["FAPrice"].ToString(),0);
                fap.FANum =common.IntSafeConvert(dr["FANum"]);
                fap.FAMon = ParseUtil.ToDecimal(dr["FAMon"].ToString(), 0);
                fap.FAIsGovPur = dr["FAIsGovPur"].ToString();
                fap.FAConfig = dr["FAConfig"].ToString();
                fap.FARemark = dr["FARemark"].ToString();
                fap.FATime =ParseUtil.ToDateTime(dr["FATime"].ToString(),DateTime.Now);
            }
            dr.Close();
            }
            catch (Exception ex)
            {
                fap = null;
                Log.WriteLog(ex.Message, "BGFixAssetPurchaseService--GetFAPByFaid");
            }
            return fap;
        }




        /// <summary>
        /// 添加固定资产采购情况
        /// </summary>
        /// <param name="bfp"></param>
        /// <returns>bool</returns>
        public static bool AddFix(BG_FixAssetPurchase bfp)
        {
            bool flag = false;
            try
            {
                string sqlStr = @"insert into BG_FixAssetPurchase(FAName,FAModel,FABrand,FAPrice,FANum,FAMon,FAIsGovPur,FAConfig,FARemark,FATime,BudID) values 
                  (@FAName,@FAModel,@FABrand,@FAPrice,@FANum,@FAMon, @FAIsGovPur,@FAConfig,@FARemark,@FATime,@BudID)";
                SqlParameter[] pars = new SqlParameter[]{
                          new SqlParameter("@FAName",bfp.FAName),
                          new SqlParameter("@FAModel",bfp.FAModel),
                          new SqlParameter("@FABrand",bfp.FABrand),
                          new SqlParameter("@FAPrice",bfp.FAPrice),
                          new SqlParameter("@FANum",bfp.FANum),
                          new SqlParameter("@FAMon",bfp.FAMon),
                          new SqlParameter("@FAIsGovPur",bfp.FAIsGovPur),
                          new SqlParameter("@FAConfig",bfp.FAConfig),
                          new SqlParameter("@FARemark",bfp.FARemark),
                          new SqlParameter("@BudID",bfp.BudID),
                          new SqlParameter("@FATime",bfp.FATime)
                                  };
                flag = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, pars) > 0;
            }
            catch (Exception ex)
            {
                flag = false;
                Log.WriteLog(ex.Message, "BGFixAssetPurchaseService--AddFix");
            }
            return flag;
        }

        /// <summary>
        /// 修改一条固定资产
        /// </summary>
        /// <param name="fa"></param>
        /// <returns>bool</returns>
        public static bool UpdFix(BG_FixAssetPurchase bfp)
        {
            bool falg = false;
            try
            {
          string sqlStr = @"update BG_FixAssetPurchase set FAMon=@FAMon,FAName=@FAName,FAModel=@FAModel,
        FABrand=@FABrand,FAPrice=@FAPrice,FAIsGovPur=@FAIsGovPur,FARemark=@FARemark,FAConfig=@FAConfig,FANum=@FANum where FAID=@FAID";
            SqlParameter[] pars = new SqlParameter[]{
                          new SqlParameter("@FAName",bfp.FAName),
                          new SqlParameter("@FAModel",bfp.FAModel),
                          new SqlParameter("@FABrand",bfp.FABrand),
                          new SqlParameter("@FAPrice",bfp.FAPrice),
                          new SqlParameter("@FANum",bfp.FANum),
                          new SqlParameter("@FAMon",bfp.FAMon),
                          new SqlParameter("@FAIsGovPur",bfp.FAIsGovPur),
                          new SqlParameter("@FAConfig",bfp.FAConfig),
                          new SqlParameter("@FARemark",bfp.FARemark),
                          //new SqlParameter("@BudID",bfp.BudID),
                          //new SqlParameter("@FATime",bfp.FATime),
                          new SqlParameter("@FAID",bfp.FAID)
                           };
            falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, pars) > 0;
            }
            catch (Exception ex)
            {
                falg = false;
                Log.WriteLog(ex.Message, "BGFixAssetPurchaseService--UpdFix");
            }
            return falg;
        }

        /// <summary>
        /// 删除一条固定资产情况
        /// </summary>
        /// <param name="faid"></param>
        /// <returns>bool</returns>
        public static bool DelFix(int faid)
        {
            bool falg = false;
            try
            {
                string sqlStr = "delete from BG_FixAssetPurchase where FAID=@FAID";
            SqlParameter[] par = new SqlParameter[]{
            new SqlParameter("@FAID",faid)
            };
            falg = DBUnity.ExecuteNonQuery(CommandType.Text, sqlStr, par) > 0;
            }
            catch (Exception ex)
            {
                falg = false;
                Log.WriteLog(ex.Message, "BGFixAssetPurchaseService--DelFix");
            }
            return falg;
        }
    }
}
