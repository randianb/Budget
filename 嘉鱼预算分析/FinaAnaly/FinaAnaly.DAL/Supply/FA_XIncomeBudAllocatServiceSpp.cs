using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using FinaAnaly.Model;

namespace FinaAnaly.DAL
{
    public static partial class FA_XIncomeBudAllocatService
    {
        /// <summary>
        /// 获取所有已分配的金额
        /// </summary>
        /// <returns></returns>
        public static decimal GetXIncomeBudAllocat()
        {
            decimal dcl = 0;
            try
            {
                string sqlStr = "select SUM(IBAMon)as IBAMon from FA_XIncomeBudAllocat";
                string strTmp = DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null);
                dcl = ParseUtil.ToDecimal(strTmp, 0);

            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XIncomeBudAllocatService--GetXIncomeBudAllocat");
            }
            return dcl;
        }

        /// <summary>
        /// 根据xpiid来查询
        /// </summary>
        /// <param name="xpiid">xpiid</param>
        /// <returns></returns>
        public static FA_XIncomeBudAllocat GetXIncomeBudAllocatByIncome(int xpiid, int year)
        {
            try
            {
                string sqlStr = "select * from FA_XIncomeBudAllocat where PIID={0} and IBAYear={1}";
                sqlStr = string.Format(sqlStr, xpiid, year);
                DataTable dt = DBUnity.AdapterToTab(sqlStr);
                if (dt.Rows.Count > 0)
                {
                    FA_XIncomeBudAllocat fA_XIncomeBudAllocat = new FA_XIncomeBudAllocat();

                    fA_XIncomeBudAllocat.IBAID = dt.Rows[0]["IBAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IBAID"];
                    fA_XIncomeBudAllocat.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_XIncomeBudAllocat.IBAMon = dt.Rows[0]["IBAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IBAMon"];
                    fA_XIncomeBudAllocat.IBAYear = dt.Rows[0]["IBAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IBAYear"];

                    return fA_XIncomeBudAllocat;
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


        public static decimal GetXIncomeBudAllocatByPIIDYear(int piid, int ibyaer)
        {
            decimal decTmp = 0;
            try
            {
                string sql = " select SUM(IBAMon) as IBAMon  from FA_XIncomeBudAllocat where PIID ={0} and IBAYear={1}";
                sql = string.Format(sql, piid, ibyaer);
                decTmp = Convert.ToDecimal(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XIncomeBudAllocatService--GetXIncomeBudAllocatByPIIDYear");
            }
            return decTmp;
        }

        public static FA_XIncomeBudAllocat GetXIncomeBudAllocatBypiidyear(int piid, int ibyaer)
        {
            try
            {
                string sql = " select *  from FA_XIncomeBudAllocat where PIID ={0} and IBAYear={1}";
                sql = string.Format(sql, piid, ibyaer);
                DataTable dt = DBUnity.AdapterToTab(sql);
                if (dt.Rows.Count > 0)
                {
                    FA_XIncomeBudAllocat fA_XIncomeBudAllocat = new FA_XIncomeBudAllocat();

                    fA_XIncomeBudAllocat.IBAID = dt.Rows[0]["IBAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IBAID"];
                    fA_XIncomeBudAllocat.PIID = dt.Rows[0]["PIID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["PIID"];
                    fA_XIncomeBudAllocat.IBAMon = dt.Rows[0]["IBAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["IBAMon"];
                    fA_XIncomeBudAllocat.IBAYear = dt.Rows[0]["IBAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["IBAYear"];

                    return fA_XIncomeBudAllocat;
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

        public static DataTable GetXIncomeMonAll()
        {
            DataTable dt = null;
            try
            {
                string sql = "SELECT  b.IBAMon , a.PIEcoSubName ,a.PIType  FROM  FA_XPayIncome as a INNER JOIN FA_XIncomeBudAllocat as b ON a.PIID  = b.PIID ";
                sql = string.Format(sql);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XIncomeBudAllocatService--GetXIncomeMonAll");
            }
            return dt;
        }

        public static bool GetXIncomeBudAllocatBypiid(int piid)
        {
            bool flag = false;
            try
            {
                string sqlStr = string.Format("select count(*) from FA_XIncomeBudAllocat where PIID={0} ", piid);
                flag = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null)) > 0;
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_XIncomeBudAllocatService--GetXIncomeBudAllocatByIncome");
            }
            return flag;
        }

        public static DataTable GetXIncomeBudAllocatByYear(int year)
        {
            string sql = string.Format("SELECT * FROM FA_XIncomeBudAllocat WHERE IBAYear = {0}", year);
            DataTable dt = null;
            try
            {
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception e)
            {
                dt = null;
            }
            return dt;
        }

        public static decimal GetSumIBAMon(int piid, int year)
        {
            string sql = string.Format("select Sum(IBAMon) from (select * from dbo.FA_XPayIncome where PIEcoSubParID={0})as a left join FA_XIncomeBudAllocat as b on a.PIID=b.PIID and b.IBAYear = {1}", piid, year);
            decimal t = 0;
            try
            {
                t = Common.ParseUtil.ToDecimal(DBUnity.ExecuteScalar(CommandType.Text, sql, null), 0);
            }
            catch (Exception e)
            {
                t = 0;
            }
            return t;
        }

        public static DataTable GetGroupPIID(int piid, int year)
        {
            string sql = string.Format("select a.PIID from (select * from dbo.FA_XPayIncome where PIEcoSubParID={0})as a left join FA_XIncomeBudAllocat as b on a.PIID=b.PIID and b.IBAYear = {1}", piid, year);
            DataTable dt = new DataTable();
            try
            {
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception e)
            {
                dt = null;
            }
            return dt;
        }

        public static decimal GetIBAMonByPIID(int tempiid, int year)
        {
            string sql = string.Format("select IBAMon from FA_XIncomeBudAllocat where PIID={0} and IBAYear = {1}", tempiid, year);
            decimal t = 0;
            try
            {
                t = Common.ParseUtil.ToDecimal(DBUnity.ExecuteScalar(CommandType.Text, sql, null), 0);
            }
            catch (Exception e)
            {
                t = 0;
            }
            return t;
        }
    }
}
