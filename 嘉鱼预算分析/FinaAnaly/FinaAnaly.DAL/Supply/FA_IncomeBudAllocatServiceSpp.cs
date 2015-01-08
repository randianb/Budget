using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using FinaAnaly.Model;

namespace FinaAnaly.DAL
{
    public static partial class FA_IncomeBudAllocatService
    {
        public static decimal GetIncomeBudAllocat()
        {
            decimal dcl = 0;
            try
            {
                string sqlStr = "select SUM(IBAMon)as IBAMon from FA_IncomeBudAllocat";
                string strTmp = DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null);
                dcl = ParseUtil.ToDecimal(strTmp, 0);

            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_IncomeBudAllocatService--GetIncomeBudAllocat");
            }
            return dcl;
        }


        public static FA_IncomeBudAllocat GetIncomeBudAllocatByIncome(int piid)
        {
            try
            {
                string sqlStr = "select * from FA_IncomeBudAllocat where PIID=" + piid;
                DataTable dt = DBUnity.AdapterToTab(sqlStr);
                if (dt.Rows.Count > 0)
                {
                    FA_IncomeBudAllocat fA_IncomeBudAllocat = new FA_IncomeBudAllocat();

                    fA_IncomeBudAllocat.IBAID = dt.Rows[0]["IBAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IBAID"];
                    fA_IncomeBudAllocat.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_IncomeBudAllocat.IBAMon = dt.Rows[0]["IBAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IBAMon"];
                    fA_IncomeBudAllocat.IBAYear = dt.Rows[0]["IBAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IBAYear"];

                    return fA_IncomeBudAllocat;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }


        public static bool GetIncomeBudAllocatBypiid(int piid)
        {
            bool flag = false;
            try
            {
                string sqlStr = string.Format("select count(*) from FA_IncomeBudAllocat where PIID={0} ", piid);
                flag = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null)) > 0;
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_IncomeBudAllocatService--GetIncomeBudAllocatByIncome");
            }
            return flag;
        }


        /// <summary>
        /// 根据ID字符串查询总预算金额
        /// </summary>
        /// <param name="idStrs"></param>
        /// <param name="ibyaer"></param>
        /// <returns></returns>
        public static decimal GetIncomeBudAllocatByIBAIDYear(string idStrs, int ibyaer)
        {
            decimal decTmp = 0;
            try
            {
                string sql = " select SUM(IBAMon) as IBAMon  from FA_IncomeBudAllocat where PIID in ({0}) and IBAYear={1}";
                sql = string.Format(sql, idStrs, ibyaer);
                decTmp = Convert.ToDecimal(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_IncomeBudAllocatService--GetIncomeBudAllocatByIBAIDYear");
            }
            return decTmp;
        }

        public static decimal GetIncomeBudAllocatByPIIDYear(int piid, int ibyaer)
        {
            decimal decTmp = 0;
            try
            {
                string sql = " select SUM(IBAMon) as IBAMon  from FA_IncomeBudAllocat where PIID ={0} and IBAYear={1}";
                sql = string.Format(sql, piid, ibyaer);
                decTmp = Convert .ToDecimal(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_IncomeBudAllocatService--GetIncomeBudAllocatByPIIDYear");
            }
            return decTmp;
        }

        public static DataTable GetIncomeMonAll()
        {
            DataTable dt = null;
            try
            {
                string sql = "SELECT  b.IBAMon , a.PIEcoSubName ,a.PIType  FROM  FA_PayIncome as a INNER JOIN FA_IncomeBudAllocat as b ON a.PIID  = b.PIID ";
                sql = string.Format(sql);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_IncomeBudAllocatService--GetIncomeMonAll");
            }
            return dt;
        }
    }
}
