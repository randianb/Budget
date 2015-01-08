using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using FinaAnaly.Model;

namespace FinaAnaly.DAL
{
    public static partial  class FA_DepBudAllocatService
    {

        /// <summary>
        /// 查询全部部门瞀预算金额 
        /// </summary>
        /// <returns>decimal</returns>
        public static decimal GetDepBudAllocat()
        {
            decimal dcl = 0;
            try
            {
                string sqlStr = "select SUM(DBAMON) as DBAMON from FA_DepBudAllocat ";
                string strTmp = DBUnity.ExecuteScalar(CommandType.Text,sqlStr,null);
                dcl = ParseUtil.ToDecimal(strTmp, 0); 
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_DepBudAllocatService--GetDepBudAllocat");    
            }
            return dcl;
        }

        /// <summary>
        /// 查询该年全部部门瞀预算金额 
        /// </summary>
        /// <returns>decimal</returns>
        public static decimal GetDepBudAllocatByYear(int year)
        {
            decimal dcl = 0;
            try
            {
                string sqlStr = "select SUM(DBAMON) as DBAMON from FA_DepBudAllocat  where  DBAYear={0}";
                sqlStr = string.Format(sqlStr, year);
                string strTmp = DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null);
                dcl = ParseUtil.ToDecimal(strTmp, 0);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_DepBudAllocatService--GetDepBudAllocatByYear");
            }
            return dcl;
        }

        public static bool GetDepBudAllocatByDepid(int depid)
        {
            bool flag = false;
            try
            {
                 string sqlStr = string.Format("select count(*) from FA_DepBudAllocat where DepID={0} ", depid);
                 flag = common.IntSafeConvert(DBUnity.ExecuteScalar(CommandType.Text, sqlStr, null)) > 0;
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_DepBudAllocatService--GetDepBudAllocatByDepid");              
            }
            return flag;
        }

        public static FA_DepBudAllocat GetDepMonByDepid(int depid)
        {
             try
            {
                string sqlStr = "select * from FA_DepBudAllocat where DepID="+depid;
                DataTable dt = DBUnity.AdapterToTab(sqlStr);
                if (dt.Rows.Count > 0)
                {
                    FA_DepBudAllocat fA_DepBudAllocat = new FA_DepBudAllocat();

                    fA_DepBudAllocat.DBAID = dt.Rows[0]["DBAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DBAID"];
                    fA_DepBudAllocat.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    fA_DepBudAllocat.DBAMon = dt.Rows[0]["DBAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DBAMon"];
                    fA_DepBudAllocat.DBAYear = dt.Rows[0]["DBAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DBAYear"];

                    return fA_DepBudAllocat;
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

        public static decimal GetDepMonBydepidYear(int depid, int ibyaer)
        {
            decimal decTmp = 0;
            try
            {
                string sql = " select DBAMon  from FA_DepBudAllocat where DepID={0} and DBAYear={1}";
                sql = string.Format(sql, depid, ibyaer);
                decTmp = Convert.ToDecimal(DBUnity.ExecuteScalar(CommandType.Text, sql, null));
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_DepBudAllocatService--GetDepMonBydepidYear");
            }
            return decTmp;
        }

        public static FA_DepBudAllocat GetDepMonBydepiddbayear(int depid, int ibyaer)
        {
            try
            {
                string sqlStr = "select *  from FA_DepBudAllocat where DepID={0} and DBAYear={1}";
                sqlStr = string.Format(sqlStr, depid, ibyaer);
                DataTable dt = DBUnity.AdapterToTab(sqlStr);
                if (dt.Rows.Count > 0)
                {
                    FA_DepBudAllocat fA_DepBudAllocat = new FA_DepBudAllocat();

                    fA_DepBudAllocat.DBAID = dt.Rows[0]["DBAID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DBAID"];
                    fA_DepBudAllocat.DepID = dt.Rows[0]["DepID"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DepID"];
                    fA_DepBudAllocat.DBAMon = dt.Rows[0]["DBAMon"] == DBNull.Value ? 0 : (decimal)dt.Rows[0]["DBAMon"];
                    fA_DepBudAllocat.DBAYear = dt.Rows[0]["DBAYear"] == DBNull.Value ? 0 : (int)dt.Rows[0]["DBAYear"];

                    return fA_DepBudAllocat;
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

        public static DataTable GetDepMonAll(int year)
        {
            DataTable dt = null;           
            try
            {
                string sql = "SELECT  b.DBAMon, a.DepName,a.DepID FROM  FA_Department as a INNER JOIN FA_DepBudAllocat as b ON a.DepID = b.DepID  where DBAYear={0}";
                sql = string.Format(sql, year);
                dt = DBUnity.AdapterToTab(sql);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message, "FA_DepBudAllocatService--GetDepMonAll");
            }
            return dt;
        }
    }
}
